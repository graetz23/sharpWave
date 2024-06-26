///
/// SharpWave - A refactored port of JWave
/// https://github.com/graetz23/JWave
///
/// MIT License
///
/// Copyright (c) 2020-2024 Christian (graetz23@gmail.com)
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
  /// The Battle 23 Wavelet from Mallat's book: "A Theory for Multiresolution
  /// Signal Decomposition: The Wavelet Representation", IEEE PAMI, v. 11,
  /// no. 7, 674-693, Table 1.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 23:19:07
  /// TODO This wavelet is not working, due to odd number coefficients.
  ///</remarks>
  public class Battle23 : Wavelet {

    ///<summary>
    /// The Battle 23 Wavelet by Mallat.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 23:19:07
    ///</remarks>
    public Battle23( ) : base( "Battle 23", 23, 2 ) {
      _scalingDeCom[ 0 ] = -0.002;
      _scalingDeCom[ 1 ] = -0.003;
      _scalingDeCom[ 2 ] = 0.006;
      _scalingDeCom[ 3 ] = 0.006;
      _scalingDeCom[ 4 ] = -0.013;
      _scalingDeCom[ 5 ] = -0.012;
      _scalingDeCom[ 6 ] = 0.030;
      _scalingDeCom[ 7 ] = 0.023;
      _scalingDeCom[ 8 ] = -0.078;
      _scalingDeCom[ 9 ] = -0.035;
      _scalingDeCom[ 10 ] = 0.307;
      _scalingDeCom[ 11 ] = 0.542;
      _scalingDeCom[ 12 ] = 0.307;
      _scalingDeCom[ 13 ] = -0.035;
      _scalingDeCom[ 14 ] = -0.078;
      _scalingDeCom[ 15 ] = 0.023;
      _scalingDeCom[ 16 ] = 0.030;
      _scalingDeCom[ 17 ] = -0.012;
      _scalingDeCom[ 18 ] = -0.013;
      _scalingDeCom[ 19 ] = 0.006;
      _scalingDeCom[ 20 ] = 0.006;
      _scalingDeCom[ 21 ] = -0.003;
      _scalingDeCom[ 22 ] = -0.002;
      // building wavelet as orthogonal (orthonormal) space from
      // scaling coefficients (low pass filter). Have a look into
      // Alfred Haar's wavelet or the Daubechie Wavelet with 2
      // vanishing moments for understanding what is done here. ;-)
      for( int i = 0; i < MOTHERWAVELENGTH; i++ )
        if( i % 2 == 0 )
          _waveletDeCom[ i ] = _scalingDeCom[ ( MOTHERWAVELENGTH - 1 ) - i ];
        else
          _waveletDeCom[ i ] = -_scalingDeCom[ ( MOTHERWAVELENGTH - 1 ) - i ];
      // Copy to reconstruction filters due to orthogonality (orthonormality)!
      for( int i = 0; i < MOTHERWAVELENGTH; i++ ) {
        _scalingReCon[ i ] = _scalingDeCom[ i ];
        _waveletReCon[ i ] = _waveletDeCom[ i ];
      } // i
    } // Battle23

  } // class

} // namespace
