using Godot;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

//Make my OWN array mesh?
public partial class LiveMeshEdit : MeshInstance3D
{
	//Have a block which stores its own mesh array data
	//Modify it on the block
	//Then use that to readd to the new mesh output
	bool[] vis = { true, true, true, true, true, true };

	List<Vector3> vertices = new List<Vector3>();
	List<Vector3> normals = new List<Vector3>();
	List<Vector2> uv = new List<Vector2>();
	List<Vector2> uv2 = new List<Vector2>();
	List<int> indices = new List<int>();
	int idx = 0;

	public override void _Ready()
	{
		MakeMesh();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("test_key"))
		{
			TryRemoveFaces();
		}
	}

	private void MakeMesh()
	{
		// 180 , 182
		for (int i = 0; i < 48; i++)
		{
			for (int j = 0; j < 48; j++)
			{
				MakeFaces(new Vector3(i, 0, j), .5f);
			}
		}
		SetMesh();
	}

	private void TryRemoveFaces()
	{
		vertices.RemoveRange(0, 18);
		normals.RemoveRange(0, 18);
		uv.RemoveRange(0, 18);
		uv2.RemoveRange(0, 18);
		indices.RemoveRange(0, 18);
		SetMesh();
	}

	//For loop with manually indices and checking which face to create
	//To massively refactor this code?
	private void MakeFaces(Vector3 offset, float scale = 1)
	{
		// offset = offset * scale;
		//TODO : ADD UV
		//0X
		if (vis[0])
		{
			vertices.Add(new Vector3(0, scale, 0) + offset);
			normals.Add(new Vector3(0, 0, 0));
			uv.Add(new Vector2(0, 0));
			uv2.Add(new Vector2(0, 0));
			indices.Add(idx);
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

			vertices.Add(new Vector3(0, scale, 0) + offset);
			indices.Add(idx);
			normals.Add(new Vector3(0, 0, 0));
			uv.Add(new Vector2(0, 0));
			uv2.Add(new Vector2(0, 0));
			idx++;
		}
		//1X
		if (vis[1])
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
		//0Y
		if (vis[2])
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
		//1Y
		if (vis[3])
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
		//0Z
		if (vis[4])
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
		//1Z
		if (vis[5])
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

			vertices.Add(new Vector3(scale, 0, scale) + offset);
			indices.Add(idx);
			normals.Add(new Vector3(0, 0, 0));
			uv.Add(new Vector2(0, 0));
			uv2.Add(new Vector2(0, 0));
			idx++;
			//NEXT TRI
			vertices.Add(new Vector3(scale, 0, scale) + offset);
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
		}
	}

	private void SetMesh()
	{
		ArrayMesh arrayMesh = new ArrayMesh();
		Godot.Collections.Array arrays = new Godot.Collections.Array();
		arrays.Resize((int)ArrayMesh.ArrayType.Max);

		Stopwatch st = new Stopwatch();

		st.Start();
		arrays[(int)ArrayMesh.ArrayType.Vertex] = vertices.ToArray();
		arrays[(int)ArrayMesh.ArrayType.Normal] = normals.ToArray();
		arrays[(int)ArrayMesh.ArrayType.TexUV] = uv.ToArray();
		arrays[(int)ArrayMesh.ArrayType.TexUV2] = uv2.ToArray();
		arrays[(int)ArrayMesh.ArrayType.Index] = indices.ToArray();
		GD.Print("List -> Array : " + st.ElapsedMilliseconds);

		arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
		GD.Print("Add Surface : " + st.ElapsedMilliseconds);
		Mesh = arrayMesh;
		GD.Print("Set Mesh : " + st.ElapsedMilliseconds);
	}

	private void PrintMemory()
	{
		GD.Print();
	}
}
