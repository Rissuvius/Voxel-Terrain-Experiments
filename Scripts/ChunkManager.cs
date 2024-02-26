using Godot;
using System;

public partial class ChunkManager : Node3D
{

    WorldGenerator generator = new WorldGenerator();

    public override void _Ready()
    {
        //Create datachunks first
        //Once datachunks are done, 
        //Create livechunk pairs which communicate
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                Vector3 offset = new Vector3(i, 0, j) * 16;

                ChunkStore chunk = new ChunkStore(offset, generator);
                // chunk.Position = offset;
                // chunk.Name = "chunk_" + i + "_" + j;
                AddChild(chunk);
            }
        }
    }
}
