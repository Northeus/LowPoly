using LowPoly.Algo;


namespace LowPoly.World
{
    public class Surface
    {
        public const int Width = 10;


        public const int Height = 10;


        public readonly float[,] HeightMap;


        public Surface()
        {
            HeightMap = Noise.GenerateNoise( Width, Height, 0.5f );
        }
    }
}
