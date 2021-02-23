using LowPoly.Algo;


namespace LowPoly.World
{
    public class Surface
    {
        public const int Width = 64;


        public const int Height = 64;


        public const float Distance = 0.5f;


        public readonly float[,] HeightMap;


        public Surface()
        {
            HeightMap = Noise.GenerateNoise( Width, Height );
        }
    }
}
