///
/// SharpWave - a pragmatic port of JWave
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

namespace SharpWave
{

   ///<summary>
   /// The Discrete Fourier Transform (DFT) is the discrete version of the
   /// continuous Fourier Transform applied to a discrete complex valued
   /// series. While the DFT can be applied to any complex valued series; of
   /// any length, in practice for large series it can take considerable time
   /// to compute, while the time taken being proportional to the square of the
   /// number on points in the series.
   ///</summary>
   ///<remarks>
   /// Christian (graetz23@gmail.com) 14.03.2015 18:30:35
   ///</remarks>
  public class DiscreteFourierTransform : BasicTransform {

    ///<summary>Constructor; does nothing</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 25.03.2010 19:56:29
    ///</remarks>
    public DiscreteFourierTransform( ) : base( "Discrete Fourier Transform" ) {
    } // method

    ///<summary>
    /// The 1-D forward version of the Discrete Fourier Transform (DFT); the
    /// input array arrTime is organized by real and imaginary parts of a
    /// complex number using even and odd places for the index. For example:
    /// arrTime[ 0 ] = real1, arrTime[ 1 ] = imag1,
    /// arrTime[ 2 ] = real2, arrTime[ 3 ] = imag2, ..
    /// The output arrFreq is organized by the same scheme.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 25.03.2010 19:56:29
    ///</remarks>
    ///<returns>
    /// The discrete fourier transform of for a given time series.
    ///</returns>
    override public double[ ] forward( double[ ] arrTime ) {
      if( !isBinary( arrTime.Length ) )
        throw new Types.Data_NotValid( "DiscreteFourierTransform.forward - " +
        "given array length is not 2^p | p E N .. = 1, 2, 4, 8, 16, 32, .. " +
        "please use the Ancient Egyptian Decomposition " +
        "for any other array length!" );
      int m = arrTime.Length;
      double[ ] arrFreq = new double[ m ]; // result
      int n = m >> 1; // half of m
      for( int i = 0; i < n; i++ ) {
        int iR = i * 2;
        int iC = i * 2 + 1;
        arrFreq[ iR ] = 0.0;
        arrFreq[ iC ] = 0.0;
        double arg = -2.0 * Math.PI * (double)i / (double)n;
        for( int k = 0; k < n; k++ ) {
          int kR = k * 2;
          int kC = k * 2 + 1;
          double cos = Math.Cos( k * arg );
          double sin = Math.Sin( k * arg );
          arrFreq[ iR ] += arrTime[ kR ] * cos - arrTime[ kC ] * sin;
          arrFreq[ iC ] += arrTime[ kR ] * sin + arrTime[ kC ] * cos;
        } // k
        arrFreq[ iR ] /= (double)n;
        arrFreq[ iC ] /= (double)n;
      } // i
      return arrFreq;
    } // forward

    ///<summary>
    /// The 1-D reverse version of the Discrete Fourier Transform (DFT); the
    /// input array arrFreq is organized by real and imaginary parts of a
    /// complex number using even and odd places for the index. For example:
    /// arrTime[ 0 ] = real1, arrTime[ 1 ] = imag1,
    /// arrTime[ 2 ] = real2, arrTime[ 3 ] = imag2, ..
    /// The output arrTime is organized by the same scheme.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 25.03.2010 19:56:29
    ///</remarks>
    ///<returns>
    /// The reconstructed time series for a given discrete frequency domain .
    ///</returns>
    override public double[ ] reverse( double[ ] arrFreq ) {
      if( !isBinary( arrFreq.Length ) )
        throw new Types.Data_NotValid( "DiscreteFourierTransform.reverse - " +
        "given array length is not 2^p | p E N .. = 1, 2, 4, 8, 16, 32, .. " +
        "please use the Ancient Egyptian Decomposition " +
        "for any other array length!" );
      int m = arrFreq.Length;
      double[ ] arrTime = new double[ m ]; // result
      int n = m >> 1; // half of m
      for( int i = 0; i < n; i++ ) {
        int iR = i * 2;
        int iC = i * 2 + 1;
        arrTime[ iR ] = 0.0;
        arrTime[ iC ] = 0.0;
        double arg = 2.0 * Math.PI * (double)i / (double)n;
        for( int k = 0; k < n; k++ ) {
          int kR = k * 2;
          int kC = k * 2 + 1;
          double cos = Math.Cos( k * arg );
          double sin = Math.Sin( k * arg );
          arrTime[ iR ] += arrFreq[ kR ] * cos - arrFreq[ kC ] * sin;
          arrTime[ iC ] += arrFreq[ kR ] * sin + arrFreq[ kC ] * cos;
        } // k
      } // i
      return arrTime;
    } // reverse

    ///<summary>No levels are available yet; see forward method.</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.05.2015 21:18:34
    ///</remarks>
    ///<returns>
    /// The discrete fourier transform of for a given time series.
    ///</returns>
    override public double[ ] forward( double[ ] arrTime, int level ) {
      return forward( arrTime ); // no level is available, so just skip it ..
    } // forward

    ///<summary>No levels are available yet; see reverse method.</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.05.2015 21:18:34
    ///</remarks>
    ///<returns>
    /// The reconstructed time series for a given discrete frequency domain .
    ///</returns>
    override public double[ ] reverse( double[ ] arrFreq, int level ) {
      return reverse( arrFreq ); // no level is available, so just skip it ..
    } // reverse

    /**
     * The 1-D forward version of the Discrete Fourier Transform (DFT); The input
     * array arrTime is organized by a class called Complex keeping real and
     * imaginary part of a complex number. The output arrFreq is organized by the
     * same scheme.
     *
     * @date 23.11.2010 18:57:34
     * @author Christian (graetz23@gmail.com)
     * @param arrTime
     *          array of type Complex keeping coefficients of complex numbers
     * @return array of type Complex keeping the discrete fourier transform
     *         coefficients
     */
    // public Complex[ ] forward( Complex[ ] arrTime ) {
    //
    //   int n = arrTime.length;
    //
    //   Complex[ ] arrFreq = new Complex[ n ]; // result
    //
    //   for( int i = 0; i < n; i++ ) {
    //
    //     arrFreq[ i ] = new Complex( ); // 0. , 0.
    //
    //     double arg = -2. * Math.PI * (double)i / (double)n;
    //
    //     for( int k = 0; k < n; k++ ) {
    //
    //       double cos = Math.cos( k * arg );
    //       double sin = Math.sin( k * arg );
    //
    //       double real = arrTime[ k ].getReal( );
    //       double imag = arrTime[ k ].getImag( );
    //
    //       arrFreq[ i ].addReal( real * cos - imag * sin );
    //       arrFreq[ i ].addImag( real * sin + imag * cos );
    //
    //     } // k
    //
    //     arrFreq[ i ].mulReal( 1. / (double)n );
    //     arrFreq[ i ].mulImag( 1. / (double)n );
    //
    //   } // i
    //
    //   return arrFreq;
    // } // forward

    /**
     * The 1-D reverse version of the Discrete Fourier Transform (DFT); The input
     * array arrFreq is organized by a class called Complex keeping real and
     * imaginary part of a complex number. The output arrTime is organized by the
     * same scheme.
     *
     * @date 23.11.2010 19:02:12
     * @author Christian (graetz23@gmail.com)
     * @param arrFreq
     *          array of type Complex keeping the discrete fourier transform
     *          coefficients
     * @return array of type Complex keeping coefficients of tiem domain
     */
    // public Complex[ ] reverse( Complex[ ] arrFreq ) {
    //
    //   int n = arrFreq.length;
    //   Complex[ ] arrTime = new Complex[ n ]; // result
    //
    //   for( int i = 0; i < n; i++ ) {
    //
    //     arrTime[ i ] = new Complex( ); // 0. , 0.
    //
    //     double arg = 2. * Math.PI * (double)i / (double)n;
    //
    //     for( int k = 0; k < n; k++ ) {
    //
    //       double cos = Math.cos( k * arg );
    //       double sin = Math.sin( k * arg );
    //
    //       double real = arrFreq[ k ].getReal( );
    //       double imag = arrFreq[ k ].getImag( );
    //
    //       arrTime[ i ].addReal( real * cos - imag * sin );
    //       arrTime[ i ].addImag( real * sin + imag * cos );
    //
    //     } // k
    //
    //   } // i
    //
    //   return arrTime;
    // } // reverse

  } // class

} // namespace
