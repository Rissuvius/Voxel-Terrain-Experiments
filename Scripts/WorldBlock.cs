using Godot;
using System;

public partial class WorldBlock
{
    Block block;

    //TODO: TEX REFERENCE OBJ, Prob should exist within Block
    //Tex reference stores, UV_Name, UV_Row, UV_Column, UV_Page
    //Mesh Data, Size of each array is visSides * 6
    
    public Vector3 position;
    
    public int visibleFaces = 6;
    public bool visible = true;
    public bool[] visArray = {true, true, true, true, true, true};
    public int startIndex;
    public int endIndex;

    public int surface;
    public int meshLength; // = visibleFaces * 6;
    struct MeshArrays {
        public Vector3[] vertices;
        public Vector3[] normals;
        public Vector3[] tangents;
        public Vector2[] uv1;
        public Vector2[] uv2;
    }

    public enum Faces {
        North = 0,
        South = 1,
        East = 2,
        West = 3,
        Up = 4,
        Down = 5
    }

    public WorldBlock(Vector3 pos) {
        position = pos;
    }

    public int GetVisibleFaceCount() {
        int count = 0;
        for(int i = 0; i < visArray.Length; i++) {
            if (visArray[i]) count++;
        }
        visibleFaces = count;
        return count;
    }

    //TODO: Implement
    public void BlockUpdate() {}

    public bool CheckVisible() {
        foreach(bool vis in visArray) {
            if(vis) {
                return true;
            }
        }
        return false;
    }
}
