using OpenTK.Mathematics;

using System;


namespace LowPoly.Graphic
{
    public class Camera
    {
        public Vector3 Position = Vector3.Zero;


        private Vector3 _front = -Vector3.UnitZ;


        private Vector3 _right = Vector3.UnitX;


        private Vector3 _up = Vector3.UnitY;


        private float _rotationX = -MathHelper.PiOver2;


        private float _rotationY;


        private float _fov = MathHelper.PiOver2;


        public float _aspectRatio;


        public Vector3 FrontHorizontal => new Vector3( _front.X, 0.0f, _front.Z ).Normalized();


        public Vector3 Front => _front;


        public Vector3 RightHorizontal => new Vector3( _right.X, 0.0f, _right.Z );


        public Vector3 Right => _right;


        public Vector3 Up => _up;


        public float RotationX
        {
            get => MathHelper.RadiansToDegrees( _rotationX );

            set
            {
                _rotationX = MathHelper.DegreesToRadians( value );

                Update();
            }
        }


        public float RotationY
        {
            get => MathHelper.RadiansToDegrees( _rotationY );

            set
            {
                // Do not allow to rotate camera upside down
                float angle = MathHelper.Clamp( value, -89.0f, 89.0f );

                _rotationY = MathHelper.DegreesToRadians( angle );

                Update();
            }
        }


        public Matrix4 ViewMatrix => Matrix4.LookAt( Position, Position + _front, _up );


        public Matrix4 ProjectionMatrix => Matrix4.CreatePerspectiveFieldOfView(
            _fov, _aspectRatio, 0.01f, 100.0f
        );


        public Camera( int width, int height )
        {
            AdjustAspectRatio( width, height );
        }


        public void AdjustAspectRatio( int width, int height )
        {
            _aspectRatio = ( float ) width / height;
        }


        private void Update()
        {
            _front.X = ( float ) Math.Cos( _rotationY ) * ( float ) Math.Cos( _rotationX );
            _front.Y = ( float ) Math.Sin( _rotationY );
            _front.Z = ( float ) Math.Cos( _rotationY ) * ( float ) Math.Sin( _rotationX );

            _front.Normalize();

            _right = Vector3.Normalize( Vector3.Cross( _front, Vector3.UnitY ) );
            _up = Vector3.Normalize( Vector3.Cross( _right, _front ) );
        }
    }
}
