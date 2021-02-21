using LowPoly.Graphic;

using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;


namespace LowPoly.Control
{
    // TODO wrap up
    public static class CameraControl
    {
        public static Camera _camera; /* TODO different binding */


        private static float _sensitivity = 1.0f * 100.0f;


        private static Vector2 _mousePos = new Vector2( 0.0f, 0.0f );


        private static bool _isFirstMouseMove = true;


        private static int _width;


        private static int _height;


        private static float _speed = 5.0f;


        public static void ScreenSize( int width, int height )
        {
            _width = width;
            _height = height;
        }


        public static void Update( KeyboardState keyboard, MouseState mouse, float time )
        {
            if ( keyboard.IsKeyDown( Keys.W ) )
            {
                _camera.Position +=  _camera.FrontHorizontal * _speed * time;
            }

            if ( keyboard.IsKeyDown( Keys.S ) )
            {
                _camera.Position -= _camera.FrontHorizontal * _speed * time;
            }

            if ( keyboard.IsKeyDown( Keys.A ) )
            {
                _camera.Position -= _camera.RightHorizontal * _speed * time;
            }

            if ( keyboard.IsKeyDown( Keys.D ) )
            {
                _camera.Position += _camera.RightHorizontal * _speed * time;
            }

            if ( keyboard.IsKeyDown( Keys.Space ) )
            {
                _camera.Position += Vector3.UnitY * _speed * time;
            }

            if ( keyboard.IsKeyDown( Keys.LeftShift ) )
            {
                _camera.Position -= Vector3.UnitY * _speed * time;
            }

            if ( ! _isFirstMouseMove )
            {
                _camera.RotationX += ( mouse.X - _mousePos.X ) / _width * _sensitivity;
                _camera.RotationY -= ( mouse.Y - _mousePos.Y ) / _height * _sensitivity;
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
