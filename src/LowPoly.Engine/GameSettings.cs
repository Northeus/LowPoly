using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;


namespace LowPoly.Engine
{
    public static class GameSettings
    {
        public static readonly GameWindowSettings Game = new GameWindowSettings()
        {
            IsMultiThreaded = false,
            RenderFrequency = 0.0,      /* Unlimited */
            UpdateFrequency = 0.0       /* Unlimited */
        };

        public static readonly NativeWindowSettings Native = new NativeWindowSettings()
        {
            Title = "LowPoly",
            Size = new Vector2i( 800, 600 ),
            IsFullscreen = false
        };
    }
}
