using Godot;
using System;

//Overlay several layers of different generational types
//takes arguments from ChunkStore and returns 2d-3d arrays 
//of generated terrain
public partial class WorldGenerator
{
    static FastNoiseLite noise = new FastNoiseLite();

    public WorldGenerator()
    {
        noise.Seed = System.Environment.TickCount;
        noise.FractalOctaves = 6;
        noise.FractalLacunarity = 2.0f;
        noise.FractalGain = 0.5f;
        noise.FractalWeightedStrength = 0.0f;
        noise.FractalPingPongStrength = 2.0f;
        // noise.Period = 60f; not used anymore?
        // noise.Persistence = 0.2f;
    }

    public WorldGenerator(int seed, int octaves, float lacunarity, float gain, float weightedStrength, float pingPongStrength)
    {
        noise.Seed = seed;
        noise.FractalOctaves = octaves;
        noise.FractalLacunarity = lacunarity;
        noise.FractalGain = gain;
        noise.FractalWeightedStrength = weightedStrength;
        noise.FractalPingPongStrength = pingPongStrength;
        // noise.Period = period;
        // noise.Persistence = persistence;
    }

    public int[,] GetHeightMap(Vector3 chunkOffset)
    {
        int[,] heightMap = new int[ChunkStore.width, ChunkStore.length];
        for (int i = 0; i < ChunkStore.width; i++)
        {
            for (int j = 0; j < ChunkStore.length; j++)
            {

                float val = noise.GetNoise2D(i + chunkOffset.X, j + chunkOffset.Z);
                val += 1;
                val *= 30;
                if (val > ChunkStore.height - 1) val = ChunkStore.height - 1;
                else if (val < 0) val = 0;

                heightMap[i, j] = (int)val;
            }
        }
        return heightMap;
    }

    //Create bottom unbreakable layer of blocks
    public void CreateBedrock()
    {

    }

    //Fill all blocks under top level as stone
    public Block[,,] Fill(Block[,,] chunk)
    {
        bool fillDown = false;
        for (int x = 0; x < chunk.GetLength(0); x++)
        {
            fillDown = false;
            for (int z = 0; z < chunk.GetLength(2); z++)
            {
                fillDown = false;
                for (int y = chunk.GetLength(1) - 1; y > 0; y--)
                {
                    if (chunk[x, y, z] != null)
                    {
                        fillDown = true;
                    }
                    if (fillDown)
                    {
                        chunk[x, y, z] = new Block(new Vector3(x, y, z));
                    }
                }
            }
        }
        return chunk;
    }
}
