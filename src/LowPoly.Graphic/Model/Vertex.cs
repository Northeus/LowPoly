namespace LowPoly.Graphic.Model
{
    public class Vertex
    {
        public const int Size = sizeof( float ) * 6;


        public const int ColorOffset = sizeof( float ) * 3;


        public readonly float[] Data;


        public Vertex( float x, float y, float z )
            : this( x, y, z, 1.0f, 1.0f, 1.0f )
        {

        }


        public Vertex( float x, float y, float z, float r, float g, float b )
        {
            Data = new float[] { x, y, z, r, g, b };
        }
    }
}
