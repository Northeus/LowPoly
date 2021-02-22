namespace LowPoly.Graphic.Model
{
    public class Vertex
    {
        public const int Size = sizeof( float ) * 6;


        public const int ColorOffset = sizeof( float ) * 3;


        public readonly float[] Data;


        public Vertex( float x, float y, float z )
        {
            Data = new float[] { x, y, z, 1.0f, 0.5f + y / 2, 0.0f + y };
        }
    }
}
