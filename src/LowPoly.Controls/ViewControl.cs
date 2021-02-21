using LowPoly.Player;

using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;


namespace LowPoly.Control
{
    public static class ViewControl
    {
        public static View _view;


        private static float _sensitivity = 1.0f * 100.0f;


        private static Vector2 _mousePos;


        private static bool _isFirstMouseMove;


        private static int _width;


        private static int _height;


        public static void BindView( View view )
        {
            _view = view;

            _mousePos = new Vector2( 0.0f, 0.0f );

            _isFirstMouseMove = true;
        }


        public static void ScreenSize( int width, int height )
        {
            _width = width;
            _height = height;
        }


        public static void Update( KeyboardState keyboard, MouseState mouse, float time )
        {
            if ( keyboard.IsKeyDown( Keys.W ) )
            {
                _view.Move( View.Direction.Front, time );
            }

            if ( keyboard.IsKeyDown( Keys.S ) )
            {
                _view.Move( View.Direction.Back, time );
            }

            if ( keyboard.IsKeyDown( Keys.A ) )
            {
                _view.Move( View.Direction.Left, time );
            }

            if ( keyboard.IsKeyDown( Keys.D ) )
            {
                _view.Move( View.Direction.Right, time );
            }

            if ( keyboard.IsKeyDown( Keys.Space ) )
            {
                _view.Move( View.Direction.Up, time );
            }

            if ( keyboard.IsKeyDown( Keys.LeftShift ) )
            {
                _view.Move( View.Direction.Down, time );
            }

            if ( ! _isFirstMouseMove )
            {
                _view.Rotate(
                    ( mouse.X - _mousePos.X ) / _width * _sensitivity,
                    ( mouse.Y - _mousePos.Y ) / _height * _sensitivity
                );
            }
            else
            {
                _isFirstMouseMove = false;
            }

            _mousePos.X = mouse.X;
            _mousePos.Y = mouse.Y;
        }
    }
}
