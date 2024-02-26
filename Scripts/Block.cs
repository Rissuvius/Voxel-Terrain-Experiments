using Godot;
using System;

//Three blocks classes for full implementation
//BlockModel, BlockData, BlockLive
//^Stores fields such as: Name, TexData, Sound, types, etc <-- The model
//BlockData: Stores position, orientation, state, lightlevel <-- What is saved
//BlockLive: Stores same data as BlockData + mesh information <-- What is loaded
public partial class Block {
    
    //tex name, block name, block id
    Vector3 ChunkPosition; //Position is localized to max array index of Chunk.Blocks
    
    public int index; //Starting offset within the mesh array
    //Z-ZY-YX-X
    public bool[] visArray = {true, true, true, true, true, true};
    public bool visible;
    
    public Block(Vector3 chunkPosition) {
        this.ChunkPosition = chunkPosition;
    }

    public bool CheckVisible() {
        foreach (bool face in visArray){
            if (face) return true;
        }
        return false;
    }
}
