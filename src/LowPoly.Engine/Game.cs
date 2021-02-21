using LowPoly.Control;
using LowPoly.Graphic;

using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework; // TODO remove (keys)


namespace LowPoly.Engine
{
    public class Game : GameWindow
    {
        public Game()
            : base( GameSettings.Game, GameSettings.Native )
        {
            VSync = VSyncMode.On;

            CursorGrabbed = true;
        }


        protected override void OnLoad()
        {
            Renderer.Load( Size.X, Size.Y );

            base.OnLoad();
        }


        protected override void OnUpdateFrame( FrameEventArgs args )
        {
            if ( IsFocused )
            {
                // TODO remove
                if ( KeyboardState.IsKeyDown( Keys.Escape ) )
                {
                    Close();
                }

                CameraControl.Update( KeyboardState, MouseState, ( float ) args.Time );
            }

            base.OnUpdateFrame( args );
        }


        protected override void OnRenderFrame( FrameEventArgs args )
        {
            // TODO rendering here
            Renderer.Draw();

            SwapBuffers();

            base.OnRenderFrame( args );
        }


        protected override void OnResize( ResizeEventArgs args )
        {
            Renderer.Resize( Size.X, Size.Y );

            base.OnResize( args );
        }
    }
}
