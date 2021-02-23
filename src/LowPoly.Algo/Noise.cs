namespace LowPoly.Algo
{
    public static class Noise
    {
        public const float Height = 1.0f;


        public const float Smoothness = 0.05f;


        public static float[,] GenerateNoise( int width, int height )
        {
            return Scale( SimplexNoise.Noise.Calc2D( width, height, Smoothness ) );
        }


        private static float[,] Scale( float[,] noise )
        {
            for ( int x = 0; x < noise.GetLength( 0 ); x++ )
            {
                for ( int y = 0; y < noise.GetLength( 1 ); y++ )
                {
                    noise[ x, y ] = ( noise[ x, y ] - 128 ) / ( 128.0f / Height ) ;
                }
            }

            return noise;
        }
    }
}
