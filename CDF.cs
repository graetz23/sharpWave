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

  ///<summary>
  /// Cohen Daubechies Feauveau (CDF) 5/3 wavelet.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 08:41:55
  /// TODO This wavelet is not working, due to odd number coefficients.
  ///</remarks>
  public class CDF53 : Wavelet {

    ///<summary>
    /// Cohen Daubechies Feauveau (CDF) 5/3 wavelet.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:27:55
    ///</remarks>
    public CDF53( ) : base( "CDF 5/3", 5, 2 ) {
      //
      _scalingDeCom[ 0 ] = -1.0 / 8.0; // ? - 1/8
      _scalingDeCom[ 1 ] = 1.0 / 4.0;  // ? + 2/8
      _scalingDeCom[ 2 ] = 3.0 / 4.0;  // ? + 6/8
      _scalingDeCom[ 3 ] = 1.0 / 4.0;  // ? + 2/8
      _scalingDeCom[ 4 ] = -1.0 / 8.0; // ? - 1/8
      //
      _waveletDeCom[ 0 ] = 0.0;        // ?
      _waveletDeCom[ 1 ] = 1.0 / 2.0;  // ?
      _waveletDeCom[ 2 ] = 1.0;        // ?
      _waveletDeCom[ 3 ] = 1.0 / 2.0;  // ?
      _waveletDeCom[ 4 ] = 0.0;        // ?
      // Copy to reconstruction filters due to orthogonality!
      for( int i = 0; i < _motherWavelength; i++ ) {
        _scalingReCon[ i ] = _scalingDeCom[ i ];
        _waveletReCon[ i ] = _waveletDeCom[ i ];
      } // i
    } // CDF53

  } // class

  ///<summary>
  /// Cohen Daubechies Feauveau (CDF) 9/7 wavelet.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 08:41:55
  /// TODO This wavelet is not working, due to odd number coefficients.
  ///</remarks>
  public class CDF97 : Wavelet {

    ///<summary>
    /// Cohen Daubechies Feauveau (CDF) 9/7 wavelet.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:27:55
    ///</remarks>
    public CDF97( ) : base( "CDF 9/7", 9, 2 ) {
      //
      _scalingDeCom[ 0 ] = 0.026748757411; //
      _scalingDeCom[ 1 ] = -0.016864118443; //
      _scalingDeCom[ 2 ] = -0.078223266529; //
      _scalingDeCom[ 3 ] = 0.266864118443; //
      _scalingDeCom[ 4 ] = 0.602949018236; //
      _scalingDeCom[ 5 ] = 0.266864118443; //
      _scalingDeCom[ 6 ] = -0.078223266529; //
      _scalingDeCom[ 7 ] = -0.016864118443; //
      _scalingDeCom[ 8 ] = 0.026748757411; //
      //
      _waveletDeCom[ 0 ] = 0.0; //
      _waveletDeCom[ 1 ] = 0.091271763114; //
      _waveletDeCom[ 2 ] = -0.057543526229; //
      _waveletDeCom[ 3 ] = -0.591271763114; //
      _waveletDeCom[ 4 ] = 1.11508705; //
      _waveletDeCom[ 5 ] = -0.591271763114; //
      _waveletDeCom[ 6 ] = -0.057543526229; //
      _waveletDeCom[ 7 ] = 0.091271763114; //
      _waveletDeCom[ 8 ] = 0.0; //
      // Copy to reconstruction filters due to orthogonality!
      for( int i = 0; i < _motherWavelength; i++ ) {
        _scalingReCon[ i ] = _scalingDeCom[ i ];
        _waveletReCon[ i ] = _waveletDeCom[ i ];
      } // i
    } // CDF97

  } // class

} // namespace
