using Godot;
using System.Linq;
using System.Collections.Generic;

//TODO: Each block as a surface with a name?
public partial class ArrayMeshGenerator : MeshInstance3D
{

	bool[] vis = { true, true, true, true, true, true };

	public Mesh Generate(Block[,,] chunk, int chunkOffset)
	{
		LinkedList<Vector3> verts = new LinkedList<Vector3>();
		LinkedList<Vector3> normals = new LinkedList<Vector3>();
		LinkedList<Vector2> uv = new LinkedList<Vector2>();
		int idx = 0;
		LinkedList<int> index = new LinkedList<int>();

		for (int i = 0; i < chunk.GetLength(0); i++)
		{
			for (int j = 0; j < chunk.GetLength(1); j++)
			{
				for (int k = 0; k < chunk.GetLength(2); k++)
				{
					if (chunk[i, j, k] != null)
					{
						Vector3 offset = new Vector3(i, j, k);
						MakeFaces(verts, normals, uv, ref idx, index, chunk[i, j, k].visArray, offset, .65f);
					}
				}
			}
		}

		ArrayMesh arrMesh = new ArrayMesh();
		Godot.Collections.Array arrays = new Godot.Collections.Array();
		arrays.Resize((int)ArrayMesh.ArrayType.Max);

		arrays[(int)ArrayMesh.ArrayType.Vertex] = verts.ToArray<Vector3>();
		arrays[(int)ArrayMesh.ArrayType.Normal] = normals.ToArray<Vector3>();
		arrays[(int)ArrayMesh.ArrayType.TexUV] = uv.ToArray<Vector2>();
		arrays[(int)ArrayMesh.ArrayType.Index] = index.ToArray<int>();

		arrMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
		return arrMesh;
	}

	//For loop with manually index and checking which face to create
	//To massively refactor this code?
	//Face reduction with multiple colliders?
	private void MakeFaces(LinkedList<Vector3> verts, LinkedList<Vector3> normals, LinkedList<Vector2> uv, ref int idx, LinkedList<int> index, bool[] vis, Vector3 offset, float scale = 1)
	{
		offset = offset * scale;
		//TODO : ADD UV
		//0X
		if (vis[0])
		{
			verts.AddLast(new Vector3(0, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, -1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, -1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, -1));
			index.AddLast(idx);
			idx++;
			//NEXT TRI
			verts.AddLast(new Vector3(0, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, -1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, -1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, -1));
			index.AddLast(idx);
			idx++;
		}
		//1X
		if (vis[1])
		{
			verts.AddLast(new Vector3(scale, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, 1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, 1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, 1));
			index.AddLast(idx);
			idx++;
			//NEXT TRI
			verts.AddLast(new Vector3(scale, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, 1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, 1));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 0, 1));
			index.AddLast(idx);
			idx++;
		}
		//0Y
		if (vis[2])
		{
			verts.AddLast(new Vector3(scale, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, -1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, -1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, -1, 0));
			index.AddLast(idx);
			idx++;
			//NEXT TRI
			verts.AddLast(new Vector3(0, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, -1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, -1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, -1, 0));
			index.AddLast(idx);
			idx++;

		}
		//1Y
		if (vis[3])
		{
			verts.AddLast(new Vector3(0, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 1, 0));
			index.AddLast(idx);
			idx++;


			verts.AddLast(new Vector3(scale, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 1, 0));
			index.AddLast(idx);
			idx++;

			//NEXT TRI
			verts.AddLast(new Vector3(0, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 1, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(0, 1, 0));
			index.AddLast(idx);
			idx++;
		}
		//0Z
		if (vis[4])
		{
			verts.AddLast(new Vector3(scale, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(-1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(-1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(-1, 0, 0));
			index.AddLast(idx);
			idx++;
			//NEXT TRI
			verts.AddLast(new Vector3(scale, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(-1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, scale, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(-1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, 0, 0) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(-1, 0, 0));
			index.AddLast(idx);
			idx++;
		}
		//1Z
		if (vis[5])
		{
			verts.AddLast(new Vector3(0, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(1, 0, 0));
			index.AddLast(idx);
			idx++;
			//NEXT TRI
			verts.AddLast(new Vector3(scale, 0, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(0, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(1, 0, 0));
			index.AddLast(idx);
			idx++;

			verts.AddLast(new Vector3(scale, scale, scale) + offset);
			uv.AddLast(new Vector2(0, 0));
			normals.AddLast(new Vector3(1, 0, 0));
			index.AddLast(idx);
			idx++;
		}
	}
}