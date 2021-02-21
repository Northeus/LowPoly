using LowPoly.Control;
using LowPoly.Graphic;
using LowPoly.Player;

using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;


namespace LowPoly.Engine
{
    public class Game : GameWindow
    {
        private static View _view;


        public Game()
            : base( GameSettings.Game, GameSettings.Native )
        {
            VSync = VSyncMode.On;

            CursorGrabbed = true;
        }


        protected override void OnLoad()
        {
            Renderer.Load( Size.X, Size.Y );

            _view = new View( Size.X, Size.Y );

            ViewControl.BindView( _view );
            ViewControl.ScreenSize( Size.X, Size.Y );

            base.OnLoad();
        }


        protected override void OnUpdateFrame( FrameEventArgs args )
        {
            if ( IsFocused )
            {
                if ( KeyboardState.IsKeyDown( Keys.Escape ) )
                {
                    Close(); /* Dont forget remove using GraphLibFram */
                }

                ViewControl.Update( KeyboardState, MouseState, ( float ) args.Time );
            }

            base.OnUpdateFrame( args );
        }


        protected override void OnRenderFrame( FrameEventArgs args )
        {
            Renderer.ClearScreen();

            Renderer.Render();

            SwapBuffers();

            base.OnRenderFrame( args );
        }


        protected override void OnResize( ResizeEventArgs args )
        {
            Renderer.Resize( Size.X, Size.Y );

            _view.Camera.AdjustAspectRatio( Size.X, Size.Y );

            base.OnResize( args );
        }
    }
}
