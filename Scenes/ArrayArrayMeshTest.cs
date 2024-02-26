using Godot;
using System;

public partial class ArrayArrayMeshTest : MeshInstance3D
{
    static int arraySize = 36 * 4*4;
    Vector3[] vertices = new Vector3[arraySize];
    int[] indices = new int[arraySize];
    int index = 0;

    public override void _Ready()
    {
        for (int x = 0; x < 4; x++) {
            for (int z = 0; z < 4; z++) {
                MakeMeshArrays(new Vector3(x,0,z));
            }
        }   
        ApplyMesh();
    }

    private void TestRemove(int blockNumber) {
        int startPos = blockNumber * 36;
		for (int i = startPos; i < vertices.Length; i++) {

		}
        // for (int i = startPos; i < vertices.Length; i++) {
        //     vertices[i] = null;
        //     int[i] = null;
        // }
    }

    private void MakeMeshArrays(Vector3 offset) {
		vertices[index] = new Vector3(0,1,0) + offset; 
		indices[index] = index;
		index++; 

		vertices[index] = new Vector3(0,0,1) + offset; 
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,0,0) + offset;
		indices[index] = index; 
		index++; 
		//NEXT TRI
		vertices[index] = new Vector3(0,1,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,0) + offset;		
		indices[index] = index; 
		index++; 
        //1X
		vertices[index] = new Vector3(1,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,0,0) + offset;
		indices[index] = index;
		index++; 
		//NEXT TRI
		vertices[index] = new Vector3(1,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,1,1) + offset;
		indices[index] = index; 
		index++; 
		//0Y
		vertices[index] = new Vector3(1,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,0,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,0,0) + offset;
		indices[index] = index; 
		index++; 
		//NEXT TRI
		vertices[index] = new Vector3(0,0,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,0,1) + offset;
		indices[index] = index; 
		index++; 
		//1Y
		vertices[index] = new Vector3(0,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,1,1) + offset;
		indices[index] = index; 
		index++; 
		//NEXT TRI	
		vertices[index] = new Vector3(1,1,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,0) + offset;
		indices[index] = index;
		index++; 
		//0Z
		vertices[index] = new Vector3(1,0,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,0,0) + offset;
		indices[index] = index; 
		index++; 
		//NEXT TRI
		vertices[index] = new Vector3(1,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,0) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,0,0) + offset;
		indices[index] = index; 
		index++; 
		//1Z
		vertices[index] = new Vector3(0,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(1,0,1) + offset;
		indices[index] = index; 
		index++; 
		//NEXT TRI
		vertices[index] = new Vector3(1,0,1) + offset;
		indices[index] = index; 
		index++; 

		vertices[index] = new Vector3(0,1,1) + offset;
		indices[index] = index; 	
		index++; 

		vertices[index] = new Vector3(1,1,1) + offset;
		indices[index] = index;
		index++; 
    }

    private void ApplyMesh() {
        ArrayMesh arrayMesh = new ArrayMesh();
        Godot.Collections.Array arrays = new Godot.Collections.Array();
        arrays.Resize((int)ArrayMesh.ArrayType.Max);

        arrays[(int)ArrayMesh.ArrayType.Vertex] = vertices;
        // arrays[(int)ArrayMesh.ArrayType.Index] = indices;

        arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
        Mesh = arrayMesh;
    }
}
