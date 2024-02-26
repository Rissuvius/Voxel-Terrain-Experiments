using Godot;

public partial class LiveBlock
{
    Block block;
    ///<summary>Local Position in Chunk</summary>
	public Vector3 position;
	public Vector3[] vertices;
	public int[] indices;
	
    public LiveBlock() {}

    public LiveBlock(int[] indices){
        this.indices= indices;
    }

    public LiveBlock(Vector3 position, Vector3[] vertices, int[] indices) {
        this.position = position;
        this.vertices = vertices;
        this.indices = indices;
    }
}
