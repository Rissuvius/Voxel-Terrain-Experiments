using Godot;

/*
PHASES:
1) Initial Chunk Create. 
    -Setup chunk via generation object
    -After generation object is done calculate block metadata
        (Visible, orientation, etc...)
2) Exists in life cycle and coordinates with LiveChunks to modify and update
3) Save and Load
*/

//Track some data for faster loads, etc
//Highest stored block for example
//Read chunks bottom up as the top will likely be empty
public partial class ChunkStore : MeshInstance3D
{
    readonly static public int width = 16;
    readonly static public int height = 256;
    readonly static public int length = 16;

    public Vector3 regionPosition;
    public Block[,,] dataChunk = new Block[width, height, length];

    public ChunkStore() { }

    public ChunkStore(Vector3 regionPos, WorldGenerator gen)
    {
        regionPosition = regionPos;
        CreateChunk(gen);
        // dataChunk = gen.Fill(dataChunk);
        CheckFaceVisibility(dataChunk);
    }

    private void CreateChunk(WorldGenerator gen)
    {
        int[,] heightMap = new int[width, length];
        heightMap = gen.GetHeightMap(regionPosition);
        SetHeightMap(heightMap);
    }

    //Only needs 1 face to return true
    private void CheckVisibility(Block[,,] chunk)
    {

    }

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

    private void SetHeightMap(int[,] heightMap)
    {
        for (int x = 0; x < dataChunk.GetLength(0); x++)
        {
            for (int z = 0; z < dataChunk.GetLength(2); z++)
            {
                int y = heightMap[x, z];
                dataChunk[x, y, z] = new Block(new Vector3(x, y, z));
            }
        }
    }

    private Vector2 GetChunkOffset(Vector2 regionPosition)
    {
        Vector2 offset = new Vector2(regionPosition.X * width, regionPosition.Y * length);
        return offset;
    }
}
