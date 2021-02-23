using LowPoly.World;

using System;
using System.Linq;


namespace LowPoly.Graphic.Model
{
    public class SurfaceModel : Mesh
    {
        private static Random _randomGenerator = new Random();


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
            float gapX = Surface.Distance;
            float gapY = Surface.Distance;

            float offsetX = - ( Surface.Width / 2.0f ) * gapX;
            float offsetY = - ( Surface.Height / 2.0f ) * gapY;

            bool isEvenSquare = ( x + y ) % 2 == 0;

            var color = GetColor();

            /* Some nasty 5h1t code */
            vertices[ index++ ] = new Vertex(
                offsetX + x * gapX,
                surface.HeightMap[ x, y ],
                offsetY + y * gapY,
                color.Red,
                color.Green,
                color.Blue
            );
            vertices[ index++ ] = new Vertex(
                offsetX + x * gapX,
                surface.HeightMap[ x, y + 1 ],
                offsetY + ( y + 1 ) * gapY,
                color.Red,
                color.Green,
                color.Blue
            );
            vertices[ index++ ] = new Vertex(
                offsetX + ( x + 1 ) * gapX,
                surface.HeightMap[ x + 1, ( isEvenSquare ? y : y + 1 ) ],
                offsetY + ( isEvenSquare ? y : y + 1 ) * gapY,
                color.Red,
                color.Green,
                color.Blue
            );

            color = GetColor();

            vertices[ index++ ] = new Vertex(
                offsetX + ( x + 1 ) * gapX,
                surface.HeightMap[ x + 1, y ],
                offsetY + y * gapY,
                color.Red,
                color.Green,
                color.Blue
            );
            vertices[ index++ ] = new Vertex(
                offsetX + ( x + 1 ) * gapX,
                surface.HeightMap[ x + 1, y + 1 ],
                offsetY + ( y + 1 ) * gapY,
                color.Red,
                color.Green,
                color.Blue
            );
            vertices[ index ] = new Vertex(
                offsetX + x * gapX,
                surface.HeightMap[ x, ( isEvenSquare ? y + 1 : y ) ],
                offsetY + ( isEvenSquare ? y + 1 : y ) * gapY,
                color.Red,
                color.Green,
                color.Blue
            );
        }


        private static uint[] GenerateIndices()
            => Enumerable
                    .Range( 0, ( Surface.Width - 1 ) * ( Surface.Height - 1 ) * 6 )
                    .Select( x => ( uint ) x )
                    .ToArray();


        private static ( float Red, float Green, float Blue ) GetColor()
            => ( 0.4f + RandFloat( 0.05f ), 0.6f + RandFloat( 0.05f ), 0.0f + RandFloat( 0.05f ) );


        private static float RandFloat( float radius )
            => ( ( float ) _randomGenerator.NextDouble() * 2 - 1 ) * radius;
    }
}
