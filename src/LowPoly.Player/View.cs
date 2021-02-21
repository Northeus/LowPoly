using LowPoly.Graphic;

using OpenTK.Mathematics;


namespace LowPoly.Player
{
    public class View
    {
        private Camera _camera;


        private static float _speed = 5.0f;


        public Camera Camera => _camera;


        public View( int width, int height )
        {
            _camera = new Camera( width, height );
        }


        public void Move( Direction direction, float time ) =>
# pragma warning disable CS8524
            _camera.Position += direction switch
            {
                Direction.Front =>   _camera.FrontHorizontal * _speed * time,
                Direction.Back  => - _camera.FrontHorizontal * _speed * time,
                Direction.Left  => - _camera.RightHorizontal * _speed * time,
                Direction.Right =>   _camera.RightHorizontal * _speed * time,
                Direction.Up    =>   Vector3.UnitY           * _speed * time,
                Direction.Down  => - Vector3.UnitY           * _speed * time,
            };
# pragma warning restore CS8524


        public void Rotate( float rotationX, float rotationY )
        {
            _camera.RotationX += rotationX;
            _camera.RotationY -= rotationY;
        }


        public enum Direction
        {
            Front,
            Back,
            Left,
            Right,
            Up,
            Down,
        }
    }
}
