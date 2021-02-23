using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LowPoly.Graphic.Model
{
    public static class Loader
    {
        public static Mesh LoadModel( string path )
        {
            string[] text = File.ReadAllLines( path );

            int numberOfTriangles = -1;

            int endOfHeader = -1;

            for ( int i = 0; i < text.Length; i++ )
            {
                if ( text[ i ].Equals( "end_header" ) )
                {
                    endOfHeader = i;

                    break;
                }

                if ( text[ i ].Length > 13 && text[ i ].Substring( 0, 12 ).Equals( "element face" ) )
                {
                    numberOfTriangles = Int32.Parse( text[ i ].Substring( 13 ) );
                }
            }

            if ( numberOfTriangles == -1 || endOfHeader == -1 )
            {
                throw new Exception( "Unable to load model" );
            }

            return new Mesh(
                GetVertices( text[ ( endOfHeader + 1 ) .. ( text.Length - numberOfTriangles ) ] ),
                GetIndices( text[ ^numberOfTriangles .. ] )
            );
        }


        private static Vertex[] GetVertices( string[] text )
        {
            Vertex[] vertices = new Vertex[ text.Length ];

            int index = 0;

            foreach ( string line in text )
            {
                string[] tokens = line.Split( ' ' );

                IEnumerable< float > coords = tokens[ 0 .. 3 ].Select( value => ( float ) Double.Parse( value ) );

                IEnumerable< float > color = tokens[ 3 .. 6 ].Select( value => Int32.Parse( value ) / 255.0f );

                vertices[ index++ ] = new Vertex(
                    coords.Concat( color ).ToArray()
                );
            }

            return vertices;
        }


        private static uint[] GetIndices( string[] text )
        {
            uint[] indices = new uint[ text.Length * 3 ];

            int index = 0;

            foreach ( string line in text )
            {
                string[] tokens = line.Split( ' ' );

                indices[ index++ ] = UInt32.Parse( tokens[ 1 ] );
                indices[ index++ ] = UInt32.Parse( tokens[ 2 ] );
                indices[ index++ ] = UInt32.Parse( tokens[ 3 ] );
            }

            return indices;
        }
    }
}
