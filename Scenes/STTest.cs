using Godot;
using System;

public partial class STTest : MeshInstance3D
{
    public override void _Ready()
    {
        MakeMesh();
        StandardMaterial3D mat = new StandardMaterial3D();
        mat.VertexColorUseAsAlbedo = true;
        Mesh.SurfaceSetMaterial(0, mat);
    }
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("test_key"))
        {
            TryRemoveFaces();
        }
    }

    private void TryRemoveFaces()
    {
        SurfaceTool st = new SurfaceTool();
        st.Begin(Mesh.PrimitiveType.Triangles);

        st.CreateFrom(Mesh, 0);
    }

    private void MakeMesh()
    {
        SurfaceTool st = new SurfaceTool();
        st.Begin(Mesh.PrimitiveType.Triangles);

        for (int i = 0; i < 500; i++)
        {
            for (int j = 0; j < 500; j++)
            {
                MakeFaces(ref st, new Vector3(i, 0, j));
            }
        }

        st.Index();
        Mesh = st.Commit();
    }

    private void MakeFaces(ref SurfaceTool st, Vector3 offset, float s = .5f)
    {
        //offset = offset * s;
        //0 Z , front Z
        st.SetColor(new Color(1, 0, 0));
        st.AddVertex(new Vector3(0, 0, 0) + offset);
        st.AddVertex(new Vector3(s, 0, 0) + offset);
        st.AddVertex(new Vector3(0, s, 0) + offset);

        st.AddVertex(new Vector3(0, s, 0) + offset);
        st.AddVertex(new Vector3(s, 0, 0) + offset);
        st.AddVertex(new Vector3(s, s, 0) + offset);

        //s Z , back Z
        st.SetColor(new Color(0, 1, 0));
        st.AddVertex(new Vector3(0, s, s) + offset);
        st.AddVertex(new Vector3(s, 0, s) + offset);
        st.AddVertex(new Vector3(0, 0, s) + offset);

        st.AddVertex(new Vector3(s, s, s) + offset);
        st.AddVertex(new Vector3(s, 0, s) + offset);
        st.AddVertex(new Vector3(0, s, s) + offset);

        //0 Y , bottom Y
        st.SetColor(new Color(0, 0, 1));
        st.AddVertex(new Vector3(0, 0, s) + offset);
        st.AddVertex(new Vector3(s, 0, 0) + offset);
        st.AddVertex(new Vector3(0, 0, 0) + offset);

        st.AddVertex(new Vector3(s, 0, s) + offset);
        st.AddVertex(new Vector3(s, 0, 0) + offset);
        st.AddVertex(new Vector3(0, 0, s) + offset);

        //s Y , top Y
        st.SetColor(new Color(1, 1, 0));
        st.AddVertex(new Vector3(0, s, 0) + offset);
        st.AddVertex(new Vector3(s, s, 0) + offset);
        st.AddVertex(new Vector3(0, s, s) + offset);

        st.AddVertex(new Vector3(0, s, s) + offset);
        st.AddVertex(new Vector3(s, s, 0) + offset);
        st.AddVertex(new Vector3(s, s, s) + offset);

        //0 Z, left X
        st.SetColor(new Color(1, 0, 1));
        st.AddVertex(new Vector3(0, s, s) + offset);
        st.AddVertex(new Vector3(0, 0, s) + offset);
        st.AddVertex(new Vector3(0, s, 0) + offset);

        st.AddVertex(new Vector3(0, 0, s) + offset);
        st.AddVertex(new Vector3(0, 0, 0) + offset);
        st.AddVertex(new Vector3(0, s, 0) + offset);

        //s Z, right X
        st.SetColor(new Color(0, 1, 1));
        st.AddVertex(new Vector3(s, s, 0) + offset);
        st.AddVertex(new Vector3(s, 0, s) + offset);
        st.AddVertex(new Vector3(s, s, s) + offset);

        st.AddVertex(new Vector3(s, s, 0) + offset);
        st.AddVertex(new Vector3(s, 0, 0) + offset);
        st.AddVertex(new Vector3(s, 0, s) + offset);
    }
}
