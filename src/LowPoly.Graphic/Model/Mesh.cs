using OpenTK.Graphics.OpenGL4;


namespace LowPoly.Graphic.Model
{
    public class Mesh
    {
        private static readonly Shader _shader = new Shader(
            "LowPoly.Graphic/Shader/DefaultShader.vert",
            "LowPoly.Graphic/Shader/DefaultShader.frag"
        );


        private readonly int _vertexArrayObject;


        private readonly int _vertexBufferObject;


        private readonly int _elementBufferObject;


        private readonly float[] _vertices;


        private readonly uint[] _indices;


        // TODO input vertices etc.
        public Mesh( float[] vertices, uint[] indices )
        {
            _vertices = vertices;
            _indices = indices;

            _vertexArrayObject = GL.GenVertexArray();
            _vertexBufferObject = GL.GenBuffer();
            _elementBufferObject = GL.GenBuffer();

            GL.BindVertexArray( _vertexArrayObject );
            GL.BindBuffer( BufferTarget.ArrayBuffer, _vertexBufferObject );
            GL.BindBuffer( BufferTarget.ElementArrayBuffer, _elementBufferObject );

            GL.VertexAttribPointer(
                0,
                3,
                VertexAttribPointerType.Float,
                false,
                sizeof( float ) * 6,
                0
            );

            GL.VertexAttribPointer(
                1,
                3,
                VertexAttribPointerType.Float,
                false,
                sizeof( float ) * 6,
                sizeof( float ) * 3
            );

            GL.EnableVertexAttribArray( 0 );
            GL.EnableVertexAttribArray( 1 );

            GL.BufferData(
                BufferTarget.ArrayBuffer,
                sizeof( float ) * _vertices.Length,
                _vertices,
                BufferUsageHint.StaticDraw
            );

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                sizeof( float ) * _indices.Length,
                _indices,
                BufferUsageHint.StaticDraw
            );

            GL.BindVertexArray( 0 );
            GL.BindBuffer( BufferTarget.ArrayBuffer, 0 );
            GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );
        }


        ~Mesh()
        {
            GL.DeleteVertexArray( _vertexArrayObject );
            GL.DeleteBuffer( _vertexBufferObject );
            GL.DeleteBuffer( _elementBufferObject );
        }


        public static void Bind()
        {
            Mesh._shader.Use();
        }


        public void Draw()
        {
            GL.BindVertexArray( _vertexArrayObject );

            GL.DrawElements(
                PrimitiveType.Triangles,
                _indices.Length,
                DrawElementsType.UnsignedInt,
                0
            );

            GL.BindVertexArray( 0 );
        }


        public static void AdjustView( Camera _camera )
        {
            _shader.LoadMatrix4( "view", _camera.ViewMatrix );
            _shader.LoadMatrix4( "projection", _camera.ProjectionMatrix );
        }
    }
}
