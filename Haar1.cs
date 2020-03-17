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

namespace SharpWave
{

  ///<summary>Alfred Haar's orthonormal wavelet transform.</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 08.02.2010 12:46:34
  ///</remarks>
  public class Haar1 : Wavelet {

    ///<summary>
    /// Constructor setting up the orthonormal Haar wavelet coefficients and
    /// the scaling coefficients; normed, due to ||*||_2, the euclidean norm.
    /// See the orthogonal version in class Haar1Orthogonal for more details.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 08.02.2010 12:46:34
    ///</remarks>
    public Haar1( ) : base( "Haar 1", 2, 2 ) {

      double sqrt2 = Math.Sqrt( 2.0 ); // squre root of 2

      _scalingDeCom[ 0 ] = 1.0 / sqrt2; // w0 = 1.4142135623730951 - normalized by square root of 2
      _scalingDeCom[ 1 ] = 1.0 / sqrt2; // w1 = 1.4142135623730951 - normalized by square root of 2

      _waveletDeCom[ 0 ] = _scalingDeCom[ 1 ]; // s0 = w1 - odd scaling is even wavelet parameter
      _waveletDeCom[ 1 ] = -_scalingDeCom[ 0 ]; // s1 = -w0 - even scaling is negative odd wavelet parameter

      // Copy to reconstruction filters due to orthogonality (orthonormality)!
      for( int i = 0; i < _motherWavelength; i++ ) {
        _scalingReCon[ i ] = _scalingDeCom[ i ]; //
        _waveletReCon[ i ] = _waveletDeCom[ i ];
      } // i

    } // method

  } // class

} // namespace
