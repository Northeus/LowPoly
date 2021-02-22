using LowPoly.Algo;


namespace LowPoly.World
{
    public class Surface
    {
        public const int Width = 32;


        public const int Height = 32;


        public readonly float[,] HeightMap;


        public Surface()
        {
            HeightMap = Noise.GenerateNoise( Width, Height );
        }
    }
}
