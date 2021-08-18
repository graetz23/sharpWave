///
/// SharpWave - A refactored port of JWave
/// https://github.com/graetz23/JWave
///
/// MIT License
///
/// Copyright (c) 2020 Christian (graetz23@gmail.com)
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
///
using System;
using SharpWave;

namespace Program
{

  class MainClass
  {
    public static void Main (string[] args)
    {
      try {

        Wavelet wavelet = null;
        wavelet = new Haar1Orthogonal( );
        // wavelet = new Haar1( );
        // wavelet = new Coiflet1( );
        // wavelet = new Coiflet2( );
        // wavelet = new Coiflet3( );
        // wavelet = new Coiflet4( );
        // wavelet = new Coiflet5( );
        // wavelet = new Legendre1( );
        // wavelet = new Legendre2( );
        // wavelet = new Legendre3( );
        // wavelet = new Daubechies2( );
        // wavelet = new Daubechies3( );
        // wavelet = new Daubechies4( );
        // wavelet = new Daubechies5( );
        // wavelet = new Daubechies6( );
        // wavelet = new Daubechies7( );
        // wavelet = new Daubechies8( );
        // wavelet = new Daubechies9( );
        // wavelet = new Daubechies10( );
        // wavelet = new Daubechies11( );
        // wavelet = new Daubechies12( );
        // wavelet = new Symlet2( );
        // wavelet = new Symlet3( );
        // wavelet = new Symlet4( );
        // wavelet = new Symlet5( );
        // wavelet = new Symlet6( );
        // wavelet = new Symlet7( );
        // wavelet = new Symlet8( );
        // wavelet = new Symlet9( );
        // wavelet = new Symlet10( );
        // wavelet = new Symlet11( );
        // wavelet = new Symlet12( );
        // wavelet = new CDF53( );
        // wavelet = new CDF97( );
        // wavelet = new Battle23( );
        // wavelet = new DiscreteMayer( );

        Algorithm algorithm = null;
        algorithm = new FastWaveletTransform( wavelet );
        // algorithm = new WaveletPacketTransform( wavelet );
        // algorithm = new ShiftingWaveletTransform( wavelet );

        Transform t = new Transform( algorithm );

        Console.WriteLine( "SharpWave .. " +
        "doing Fast Wavelet Transform by " + wavelet.TYPE + ":" );
        Console.WriteLine( );

        // 1-D example
        // double[ ] arrTime = { 1, 1, 1, 1, 1, 1, 1, 1 }; // const
        double[ ] arrTime = { 1.1, 2.2, 2.2, 2.2, 3.3, 3.3, 4.4, 4.4 }; // real
        Console.Write( "time domain:    " );
        for( int i = 0; i < arrTime.Length; i++ )
          Console.Write( arrTime[ i ] + " " );
        Console.WriteLine( );

        double[ ] arrHilb = t.forward( arrTime ); // 1-D FWT Haar forward
        Console.Write( "hilbert domain: " );
        for( int i = 0; i < arrHilb.Length; i++ )
          Console.Write( arrHilb[ i ] + " " );
        Console.WriteLine( );

        double[ ] arrReco = t.reverse( arrHilb ); // 1-D FWT Haar reverse
        Console.Write( "reconstruction: " );
        for( int i = 0; i < arrReco.Length; i++ )
          Console.Write( arrReco[ i ] + " " );
        Console.WriteLine( );
        Console.WriteLine( );

        // 2-D example
        double[ , ] matTime = { { 1, 1, 1, 1 },
                                { 1, 1, 1, 1 },
                                { 1, 1, 1, 1 },
                                { 1, 1, 1, 1 } }; // const
        // double[ , ] matTime = { { 1, 1, 1, 1 },
        //                         { 1, 1, 1, 1 },
        //                         { 1, 1, 2, 2 },
        //                         { 1, 1, 2, 2 } }; // real
        Console.WriteLine( "time domain:    " );
        for( int i = 0; i < matTime.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matTime.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matTime[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        double[ , ] matHilb = t.forward( matTime ); // 2-D FWT Haar forward
        Console.WriteLine( "hilbert domain: " );
        for( int i = 0; i < matHilb.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matHilb.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matHilb[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        double[ , ] matReco = t.reverse( matHilb ); // 1-D FWT Haar reverse
        Console.WriteLine( "reconstruction: " );
        for( int i = 0; i < matReco.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matReco.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matReco[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        // try the wavelet packet transform
        t = new Transform(
          new WaveletPacketTransform(
            new Haar1( ) ) );

        // 1-D example
        // double[ ] arrTime = { 1, 1, 1, 1, 1, 1, 1, 1 };
        Console.Write( "time domain:    " );
        for( int i = 0; i < arrTime.Length; i++ )
          Console.Write( arrTime[ i ] + " " );
        Console.WriteLine( );

        arrHilb = t.forward( arrTime ); // 1-D FWT Haar forward
        Console.Write( "hilbert domain: " );
        for( int i = 0; i < arrHilb.Length; i++ )
          Console.Write( arrHilb[ i ] + " " );
        Console.WriteLine( );

        arrReco = t.reverse( arrHilb ); // 1-D FWT Haar reverse
        Console.Write( "reconstruction: " );
        for( int i = 0; i < arrReco.Length; i++ )
          Console.Write( arrReco[ i ] + " " );
        Console.WriteLine( );
        Console.WriteLine( );

        // 2-D example
        // double[ , ] matTime = { { 1, 1, 1, 1 },
        //                          { 1, 1, 1, 1 },
        //                          { 1, 1, 1, 1 },
        //                          { 1, 1, 1, 1 } };
        Console.WriteLine( "time domain:    " );
        for( int i = 0; i < matTime.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matTime.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matTime[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        matHilb = t.forward( matTime ); // 2-D FWT Haar forward
        Console.WriteLine( "hilbert domain: " );
        for( int i = 0; i < matHilb.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matHilb.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matHilb[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        matReco = t.reverse( matHilb ); // 1-D FWT Haar reverse
        Console.WriteLine( "reconstruction: " );
        for( int i = 0; i < matReco.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matReco.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matReco[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        // try the shifting wavelet transform
        t = new Transform(
          new ShiftingWaveletTransform(
            new Haar1( ) ) );

        // 1-D example
        // double[ ] arrTime = { 1, 1, 1, 1, 1, 1, 1, 1 };
        Console.Write( "time domain:    " );
        for( int i = 0; i < arrTime.Length; i++ )
          Console.Write( arrTime[ i ] + " " );
        Console.WriteLine( );

        arrHilb = t.forward( arrTime ); // 1-D FWT Haar forward
        Console.Write( "hilbert domain: " );
        for( int i = 0; i < arrHilb.Length; i++ )
          Console.Write( arrHilb[ i ] + " " );
        Console.WriteLine( );

        arrReco = t.reverse( arrHilb ); // 1-D FWT Haar reverse
        Console.Write( "reconstruction: " );
        for( int i = 0; i < arrReco.Length; i++ )
          Console.Write( arrReco[ i ] + " " );
        Console.WriteLine( );
        Console.WriteLine( );

        // 2-D example
        // double[ , ] matTime = { { 1, 1, 1, 1 },
        //                          { 1, 1, 1, 1 },
        //                          { 1, 1, 1, 1 },
        //                          { 1, 1, 1, 1 } };
        Console.WriteLine( "time domain:    " );
        for( int i = 0; i < matTime.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matTime.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matTime[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        matHilb = t.forward( matTime ); // 2-D FWT Haar forward
        Console.WriteLine( "hilbert domain: " );
        for( int i = 0; i < matHilb.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matHilb.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matHilb[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

        matReco = t.reverse( matHilb ); // 1-D FWT Haar reverse
        Console.WriteLine( "reconstruction: " );
        for( int i = 0; i < matReco.GetUpperBound( 0 ) + 1; i++ ) {
          for( int j = 0; j < matReco.GetUpperBound( 1 ) + 1; j++ ) {
            Console.Write( matReco[ i, j ] + " " );
          } // loop
          Console.WriteLine( );
        } // loop
        Console.WriteLine( );

      } catch(Exception e) {
        Console.WriteLine();
        Console.WriteLine (e.StackTrace);
        Console.WriteLine (e.Message);
      } // try

    } // method

  } // class

} // namespace
