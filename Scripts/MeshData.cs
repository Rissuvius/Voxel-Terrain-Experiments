using Godot;
using System.Collections.Generic;
using System.Diagnostics;

//TODO: Look into using surface tool to create collision shapes
public partial class MeshData
{
	//TURN THESE INTO ARRAYS
	public List<Vector3> vertices = new List<Vector3>();
	public List<Vector3> normals = new List<Vector3>();
	public List<Vector2> uv = new List<Vector2>();
	public List<Vector2> uv2 = new List<Vector2>();
	public List<int> indices = new List<int>();

	//Store block mesh data in its own place so we can do a look up
	//Issue is all further blocks idx are now off
	//Fix: Create a static idx reference for the chunk that the blocks
	//all reference off of
	//Changing one results in a change of the static reference 

	//TODO: out bool success? Make sure block exists
	public Mesh RemoveBlock(WorldBlock block, ref ConcavePolygonShape3D shape)
	{
		int dist = (1 + block.endIndex - block.startIndex) / 2;
		vertices.RemoveRange(block.startIndex, dist);
		normals.RemoveRange(block.startIndex, dist);
		uv.RemoveRange(block.startIndex, dist);
		uv2.RemoveRange(block.startIndex, dist);
		indices.RemoveRange(block.startIndex, dist);

		// int size = indices.Count;
		// indices = new List<int>();
		// for (int i =0; i < size - dist; i++) {
		// 	indices.Add(i);
		// }
		return SetMesh(ref shape);
	}

	public Mesh MakeMesh(WorldBlock[,] blocks, ref int idx, ref ConcavePolygonShape3D shape)
	{
		for (int i = 0; i < blocks.GetLength(0); i++)
		{
			for (int j = 0; j < blocks.GetLength(1); j++)
			{
				Vector3 offset = new Vector3(i, 0, j);
				blocks[i, j].startIndex = idx;

				if (blocks[i, j].visArray[(int)WorldBlock.Faces.North])
				{
					MakeNorthFace(ref idx, offset);
				}
				if (blocks[i, j].visArray[(int)WorldBlock.Faces.South])
				{
					MakeSouthFace(ref idx, offset);
				}
				if (blocks[i, j].visArray[(int)WorldBlock.Faces.East])
				{
					MakeEastFace(ref idx, offset);
				}
				if (blocks[i, j].visArray[(int)WorldBlock.Faces.West])
				{
					MakeWestFace(ref idx, offset);
				}
				if (blocks[i, j].visArray[(int)WorldBlock.Faces.Up])
				{
					MakeUpFace(ref idx, offset);
				}
				if (blocks[i, j].visArray[(int)WorldBlock.Faces.Down])
				{
					MakeDownFace(ref idx, offset);
				}
				blocks[i, j].endIndex = idx - 1;
			}
		}
		return SetMesh(ref shape);
	}

	//TODO: TWO FACES are built wrong! Change direction 
	//1 Z
	private void MakeNorthFace(ref int idx, Vector3 offset, float scale = 1)
	{
		vertices.Add(new Vector3(0, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
		//NEXT TRI
		vertices.Add(new Vector3(scale, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
	}
	//0 Z
	private void MakeSouthFace(ref int idx, Vector3 offset, float scale = 1)
	{
		vertices.Add(new Vector3(scale, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
		//NEXT TRI
		vertices.Add(new Vector3(scale, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
	}
	//0 X
	private void MakeEastFace(ref int idx, Vector3 offset, float scale = 1)
	{
		vertices.Add(new Vector3(0, scale, scale) + offset);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		indices.Add(idx);
		idx++;

		vertices.Add(new Vector3(0, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
		//NEXT TRI
		vertices.Add(new Vector3(0, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
	}
	//1 X
	private void MakeWestFace(ref int idx, Vector3 offset, float scale = 1)
	{
		vertices.Add(new Vector3(scale, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
		//NEXT TRI
		vertices.Add(new Vector3(scale, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
	}
	//1 Y
	private void MakeUpFace(ref int idx, Vector3 offset, float scale = 1)
	{
		vertices.Add(new Vector3(0, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;


		vertices.Add(new Vector3(scale, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
		//NEXT TRI	
		vertices.Add(new Vector3(scale, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, scale, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, scale, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
	}
	//0 Y
	private void MakeDownFace(ref int idx, Vector3 offset, float scale = 1)
	{
		vertices.Add(new Vector3(scale, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
		//NEXT TRI
		vertices.Add(new Vector3(0, 0, 0) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(0, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;

		vertices.Add(new Vector3(scale, 0, scale) + offset);
		indices.Add(idx);
		normals.Add(new Vector3(0, 0, 0));
		uv.Add(new Vector2(0, 0));
		uv2.Add(new Vector2(0, 0));
		idx++;
	}

	private Mesh SetMesh(ref ConcavePolygonShape3D shape)
	{
		ArrayMesh arrayMesh = new ArrayMesh();
		Godot.Collections.Array arrays = new Godot.Collections.Array();
		arrays.Resize((int)ArrayMesh.ArrayType.Max);

		Stopwatch st = new Stopwatch();

		Vector3[] verts = vertices.ToArray();
		shape.Data = verts;

		arrays[(int)ArrayMesh.ArrayType.Vertex] = verts;
		arrays[(int)ArrayMesh.ArrayType.Normal] = normals.ToArray();
		arrays[(int)ArrayMesh.ArrayType.TexUV] = uv.ToArray();
		arrays[(int)ArrayMesh.ArrayType.TexUV2] = uv2.ToArray();
		// arrays[(int)ArrayMesh.ArrayType.Index] = indices.ToArray();
		GD.Print(st.ElapsedMilliseconds);
		arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
		GD.Print(st.ElapsedMilliseconds);
		return arrayMesh;
	}
}