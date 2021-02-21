using OpenTK.Graphics.OpenGL4;


namespace LowPoly.Graphic
{
    public static class Renderer
    {
        public static void Load( int width, int height )
        {
            GL.ClearColor( 0.0f, 0.0f, 0.3f, 1.0f );

            GL.Enable( EnableCap.DepthTest );
        }


        public static void Render()
        {
            AdjustView();
        }


        public static void ClearScreen()
        {
            GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        }


        public static void Resize( int width, int height )
        {
            GL.Viewport( 0, 0, width, height );
        }


        private static void AdjustView()
        {
            //Mesh.AdjustView( _camera );
        }
    }
}
