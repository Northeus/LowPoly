namespace LowPoly.Graphic.Model
{
    public class Vertex
    {
        public const int Size = sizeof( float ) * 3;


        public const int ColorOffset = sizeof( float ) * 3;


        public readonly float[] Data;


        public Vertex( float x, float y, float z )
        {
            Data = new float[] { x, y, z, 0.5f, 0.5f, 0.0f };
        }
    }
}
