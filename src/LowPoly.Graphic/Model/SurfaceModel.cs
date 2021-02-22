using LowPoly.World;


namespace LowPoly.Graphic.Model
{
    public class SurfaceModel : Mesh
    {
        public SurfaceModel( Surface surface )
            : base( GenerateVertices( surface ), GenerateIndices() )
        {

        }


        /* TODO might be optimalized to reuse points */
        private static Vertex[] GenerateVertices( Surface surface )
        {
            Vertex[] vertices = new Vertex[ Surface.Width * Surface.Height * 6 ];

            int index = 0;

            for ( int x = 0; x < Surface.Width; x++ )
            {
                for ( int y = 0; y < Surface.Height; y++ )
                {
                    index++; /* TODO */
                }
            }

            return vertices;
        }


        private static uint[] GenerateIndices()
        {
            uint[] indices = new uint[ Surface.Width * Surface.Height * 6 ];


            return indices;
        }
    }
}
