using Godot;
using System.Collections.Generic;

//Mesh Instance with chunk characteristics
//Refactor IDX, Collision shape updates, etc
public partial class Chunk : MeshInstance3D
{
    StaticBody3D body = new StaticBody3D();
    CollisionShape3D colShape = new CollisionShape3D();
    StandardMaterial3D mat = new StandardMaterial3D();
    ConcavePolygonShape3D shape = new ConcavePolygonShape3D();

    LinkedList<Vector2> blockCoords = new LinkedList<Vector2>();
    //Rather than setting IDX on block, set it on the blockCoords here
    //Then update all blocks after an index edit
    WorldBlock[,] blocks = new WorldBlock[5, 5];
    MeshData meshData = new MeshData();

    int idx = 0;
    Vector3 offset;
    //WorldGenerator generator;

    public Chunk(Vector3 offset)
    {
        this.offset = offset;
        //this.generator = gen;
    }

    public override void _Ready()
    {
        body.AddChild(colShape);
        colShape.Shape = shape;
        body.Name = Name + "_col";
        AddChild(body);

        //int[,] heightMap = generator.GetHeightMap(offset);

        //First pass, fill with blocks on flat plane
        for (int x = 0; x < blocks.GetLength(0); x++)
        {
            for (int z = 0; z < blocks.GetLength(1); z++)
            {
                blocks[x, z] = new WorldBlock(new Vector3(x, 0, z));
            }
        }
        //Second pass, calculate visible faces
        // for (int i = 0; i < blocks.GetLength(0); i++) {
        //     for (int j = 0; j < blocks.GetLength(1); j++) { 

        //     }
        // }
        Mesh = meshData.MakeMesh(blocks, ref idx, ref shape);
        SetMaterials();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("test_key"))
        {
            if (blocks[2, 6] != null)
            {
                Mesh = meshData.RemoveBlock(blocks[2, 6], ref shape);
                blocks[2, 6] = null;
                SetMaterials();
            }
        }
    }

    private void SetMaterials()
    {
        mat.AlbedoColor = new Color(0, 0, 0);
        SetSurfaceOverrideMaterial(0, mat);
    }

    //TODO: Make this work when I wake up
    //Maybe reference this from somewhere else in future
    //In future will need to check cross chunk
    private void CheckFaceVisibility(Block[,,] chunk)
    {
        for (int x = 0; x < chunk.GetLength(0); x++)
        {
            for (int y = 0; y < chunk.GetLength(1); y++)
            {
                for (int z = 0; z < chunk.GetLength(2); z++)
                {
                    if (chunk[x, y, z] != null)
                    {
                        //If no block left then must be visible
                        //Will change once we have chunk cooridination

                        #region Check left x
                        if (x == 0)
                        {
                            chunk[x, y, z].visArray[0] = true;
                        }
                        else
                        {
                            if (chunk[x - 1, y, z] == null)
                            {
                                chunk[x, y, z].visArray[0] = true;
                            }
                            else
                            {
                                chunk[x, y, z].visArray[0] = false;
                            }
                        }
                        #endregion
                        #region Check right x
                        if (x == chunk.GetLength(0) - 1)
                        {
                            chunk[x, y, z].visArray[1] = true;
                        }
                        else
                        {
                            if (chunk[x + 1, y, z] == null)
                            {
                                chunk[x, y, z].visArray[1] = true;
                            }
                            else
                            {
                                chunk[x, y, z].visArray[1] = false;
                            }
                        }
                        #endregion
                        #region check up y
                        if (y == chunk.GetLength(0) - 1)
                        {
                            chunk[x, y, z].visArray[3] = true;
                        }
                        else
                        {
                            if (chunk[x, y + 1, z] == null)
                            {
                                chunk[x, y, z].visArray[3] = true;
                            }
                            else
                            {
                                chunk[x, y, z].visArray[3] = false;
                            }
                        }
                        #endregion
                        #region check down y
                        if (y == 0)
                        {
                            chunk[x, y, z].visArray[2] = true;
                        }
                        else
                        {
                            if (chunk[x, y - 1, z] == null)
                            {
                                chunk[x, y, z].visArray[2] = true;
                            }
                            else
                            {
                                chunk[x, y, z].visArray[2] = false;
                            }
                        }
                        #endregion 
                        #region check forward z
                        if (z == chunk.GetLength(0) - 1)
                        {
                            chunk[x, y, z].visArray[5] = true;
                        }
                        else
                        {
                            if (chunk[x, y, z + 1] == null)
                            {
                                chunk[x, y, z].visArray[5] = true;
                            }
                            else
                            {
                                chunk[x, y, z].visArray[5] = false;
                            }
                        }
                        #endregion
                        #region check backward z
                        if (z == 0)
                        {
                            chunk[x, y, z].visArray[4] = true;
                        }
                        else
                        {
                            if (chunk[x, y, z - 1] == null)
                            {
                                chunk[x, y, z].visArray[4] = true;
                            }
                            else
                            {
                                chunk[x, y, z].visArray[4] = false;
                            }
                        }
                        #endregion
                    }
                }
            }
        }
    }
}
