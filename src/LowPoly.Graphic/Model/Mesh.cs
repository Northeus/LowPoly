using OpenTK.Graphics.OpenGL4;

using System.Linq;


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


        private int _indicesCount;


        public Mesh( Vertex[] vertices, uint[] indices )
        {
            System.Console.WriteLine("VERTICES:");
            foreach(Vertex v in vertices)System.Console.WriteLine(string.Join(" ", v.Data));

            System.Console.WriteLine("INDICES:");
            for(int i = 0; i < indices.Length; i += 3)System.Console.WriteLine($"{indices[i]} {indices[i+1]} {indices[i+2]}");

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

            GL.BindVertexArray( 0 );
            GL.BindBuffer( BufferTarget.ArrayBuffer, 0 );
            GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );

            LoadVertices( vertices );
            LoadIndices( indices );
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


        public static void AdjustView( Camera _camera )
        {
            _shader.LoadMatrix4( "view", _camera.ViewMatrix );
            _shader.LoadMatrix4( "projection", _camera.ProjectionMatrix );
        }


        public void Draw()
        {
            GL.BindVertexArray( _vertexArrayObject );

            GL.DrawElements(
                PrimitiveType.Triangles,
                _indicesCount,
                DrawElementsType.UnsignedInt,
                0
            );

            GL.BindVertexArray( 0 );
        }


        public void LoadVertices( Vertex[] vertices )
        {
            GL.BindBuffer( BufferTarget.ArrayBuffer, _vertexBufferObject );

            GL.BufferData(
                BufferTarget.ArrayBuffer,
                vertices.Length * Vertex.Size,
                vertices.SelectMany( vertex => vertex.Data ).ToArray(),
                BufferUsageHint.StaticDraw
            );

            GL.BindBuffer( BufferTarget.ArrayBuffer, 0 );
        }


        public void LoadIndices( uint[] indices )
        {
            _indicesCount = indices.Length;

            GL.BindBuffer( BufferTarget.ElementArrayBuffer, _elementBufferObject );

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                _indicesCount * sizeof( uint ),
                indices,
                BufferUsageHint.StaticDraw
            );

            GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );
        }
    }
}
