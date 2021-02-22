using LowPoly.Graphic.Model;

using OpenTK.Graphics.OpenGL4;

using System.Collections.Generic;


namespace LowPoly.Graphic
{
    public static class Renderer
    {
        private static List< Mesh > _toRender = new List< Mesh >();


        private static Camera _camera;


        public static void Load( int width, int height )
        {
            GL.ClearColor( 0.0f, 0.0f, 0.3f, 1.0f );

            GL.Enable( EnableCap.DepthTest );
        }


        public static void Render()
        {
            Mesh.AdjustView( _camera );

            Mesh.Bind();

            foreach ( Mesh mesh in _toRender )
            {
                mesh.Draw();
            }
        }


        public static void ClearScreen()
        {
            GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        }


        public static void Resize( int width, int height )
        {
            GL.Viewport( 0, 0, width, height );
        }


        public static void AddModel( Mesh mesh )
        {
            _toRender.Add( mesh );
        }

        public static void BindCamera( Camera camera ) => _camera = camera;
    }
}
