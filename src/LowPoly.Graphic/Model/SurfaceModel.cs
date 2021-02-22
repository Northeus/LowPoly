using LowPoly.World;

using System.Linq;


namespace LowPoly.Graphic.Model
{
    public class SurfaceModel : Mesh
    {
        public SurfaceModel( Surface surface )
            : base( GenerateVertices( surface ), GenerateIndices() )
        {

        }


        private static Vertex[] GenerateVertices( Surface surface )
        {
            Vertex[] vertices = new Vertex[ ( Surface.Width - 1 ) * ( Surface.Height - 1 ) * 6 ];

            int index = 0;

            for ( int x = 0; x < Surface.Width - 1; x++ )
            {
                for ( int y = 0; y < Surface.Height - 1; y++ )
                {
                    AddVertices( vertices, x, y, index, surface );

                    index += 6;
                }
            }


            return vertices;
        }


        private static void AddVertices( Vertex[] vertices, int x, int y, int index, Surface surface )
        {
            float gapX = 0.4f;
            float gapY = 0.4f;

            float offsetX = - ( Surface.Width / 2.0f ) * gapX;
            float offsetY = - ( Surface.Height / 2.0f ) * gapY;

            bool isEvenSquare = ( x + y ) % 2 == 0;

            /* Some nasty 5h1t code */
            vertices[ index++ ] = new Vertex(
                offsetX + x * gapX,
                surface.HeightMap[ x, y ],
                offsetY + y * gapY
            );
            vertices[ index++ ] = new Vertex(
                offsetX + x * gapX,
                surface.HeightMap[ x, y + 1 ],
                offsetY + ( y + 1 ) * gapY
                );
            vertices[ index++ ] = new Vertex(
                offsetX + ( x + 1 ) * gapX,
                surface.HeightMap[ x + 1, ( isEvenSquare ? y : y + 1 ) ],
                offsetY + ( isEvenSquare ? y : y + 1 ) * gapY
            );

            vertices[ index++ ] = new Vertex(
                offsetX + ( x + 1 ) * gapX,
                surface.HeightMap[ x + 1, y ],
                offsetY + y * gapY );
            vertices[ index++ ] = new Vertex(
                offsetX + ( x + 1 ) * gapX,
                surface.HeightMap[ x + 1, y + 1 ],
                offsetY + ( y + 1 ) * gapY
            );
            vertices[ index ] = new Vertex(
                offsetX + x * gapX,
                surface.HeightMap[ x, ( isEvenSquare ? y + 1 : y ) ],
                offsetY + ( isEvenSquare ? y + 1 : y ) * gapY
            );
        }

        private static uint[] GenerateIndices()
            => Enumerable
                    .Range( 0, ( Surface.Width - 1 ) * ( Surface.Height - 1 ) * 6 )
                    .Select( x => ( uint ) x )
                    .ToArray();
    }
}
