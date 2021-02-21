using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using System;
using System.IO;
using System.Collections.Generic;


namespace LowPoly.Graphic
{
    public class Shader
    {
        private readonly int _handle;


        private Dictionary< string, int > _uniformLocations;


        public Shader( string vertexShaderPath, string fragmentShaderPath )
        {
            int vertexShader = CreateShader( vertexShaderPath, ShaderType.VertexShader );

            int fragmentShader = CreateShader( fragmentShaderPath, ShaderType.FragmentShader );

            _handle = LinkShaders( vertexShader, fragmentShader );

            FreeShader( _handle, vertexShader );
            FreeShader( _handle, fragmentShader );

            _uniformLocations = GetUniformLocations( _handle );
        }


        ~Shader()
        {
            GL.DeleteProgram( _handle );
        }


        public void Use()
        {
            GL.UseProgram( _handle );
        }


        public void LoadMatrix4( string name, Matrix4 matrix )
        {
            GL.UseProgram( _handle );

            GL.UniformMatrix4( _uniformLocations[ name ], true, ref matrix );
        }


        private static int CreateShader( string shaderPath, ShaderType shaderType )
        {
            string shaderCode = File.ReadAllText( shaderPath, System.Text.Encoding.UTF8 );

            int shader = GL.CreateShader( shaderType );

            GL.ShaderSource( shader, shaderCode );

            CompileShader( shader );

            return shader;
        }


        private static void CompileShader( int shader )
        {
            GL.CompileShader( shader );

            GL.GetShader( shader, ShaderParameter.CompileStatus, out int errorCode );

            if ( ! IsSuccessful( errorCode ) )
            {
                string errorLog = GL.GetShaderInfoLog( shader );

                throw new Exception(
                    $"Error occured durning compilation of shader ({ shader }): \n" + errorLog
                );

            }
        }


        private static int LinkShaders( int vertexShader, int fragmentShader )
        {
            int handle = GL.CreateProgram();

            GL.AttachShader( handle, vertexShader );
            GL.AttachShader( handle, fragmentShader );

            GL.LinkProgram( handle );

            GL.GetProgram( handle, GetProgramParameterName.LinkStatus, out int errorCode );

            if ( ! IsSuccessful( errorCode ) )
            {
                throw new Exception( $"Error occured durning shader linking ({ handle })" );
            }

            return handle;
        }


        private static void FreeShader( int handle, int shader )
        {
            GL.DetachShader( handle, shader );
            GL.DeleteShader( shader );
        }


        private static bool IsSuccessful( int errorCode ) => errorCode == ( ( int ) All.True );


        private static Dictionary< string, int > GetUniformLocations( int handle )
        {
            var locations = new Dictionary< string, int >();

            GL.GetProgram(
                handle,
                GetProgramParameterName.ActiveUniforms,
                out int numberOfUniforms
            );

            for ( int i = 0; i < numberOfUniforms; i++ )
            {
                string name = GL.GetActiveUniform( handle, i, out _, out _ );

                int location = GL.GetUniformLocation( handle, name );

                locations.Add( name, location );
            }

            return locations;
        }
    }
}
