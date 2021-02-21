using LowPoly.Graphic.Model; // TODO remove

using OpenTK.Graphics.OpenGL4;


namespace LowPoly.Graphic
{
    public static class Renderer
    {
        public static Camera _camera;


        public static void Load( int width, int height )
        {
            GL.ClearColor( 0.0f, 0.0f, 0.3f, 1.0f );

            GL.Enable( EnableCap.DepthTest );

            _camera = new Camera( width, height );

            LowPoly.Control.CameraControl._camera = _camera; /* TODO find it more suitible place */

            LowPoly.Control.CameraControl.ScreenSize( width, height );
        }


        // TODO remove
        private static Mesh _mesh = new Mesh(
            new float[] {
                -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f,
                -0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0f,
                0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 1.0f,
                0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f
            },
            new uint[] {
                0, 1, 2,
                0, 2, 3
            }
        );

        // TODO remove
        public static void Draw()
        {
            AdjustView();
            Mesh.Bind();
            ClearScreen();
            _mesh.Draw();
        }


        public static void ClearScreen()
        {
            GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        }


        public static void Resize( int width, int height )
        {
            GL.Viewport( 0, 0, width, height );

            _camera.AdjustAspectRatio( width, height );
        }


        private static void AdjustView()
        {
            Mesh.AdjustView( _camera );
        }
    }
}
