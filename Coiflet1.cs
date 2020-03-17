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
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of six coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:27:55
  ///</remarks>
  public class Coiflet1 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// six coefficients, orthonormalizes them (normed, due to ||*||2 euclidean
    /// norm), and builds the scaling coefficients, and the orthonormal bases
    /// afterwards; .
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:27:55
    ///</remarks>
    public Coiflet1( ) : base( "Coiflet 1", 6, 2 ) {
      double sqrt02 = 1.4142135623730951;
      double sqrt15 = Math.Sqrt( 15.0 );
      // these coefficients are already orthonormal
      _scalingDeCom[ 0 ] = sqrt02 * ( sqrt15 - 3.0 ) / 32.0; //  -0.01565572813546454;
      _scalingDeCom[ 1 ] = sqrt02 * ( 1.0 - sqrt15 ) / 32.0; // -0.0727326195128539;
      _scalingDeCom[ 2 ] = sqrt02 * ( 6.0 - 2.0 * sqrt15 ) / 32.0; //  0.38486484686420286;
      _scalingDeCom[ 3 ] = sqrt02 * ( 2.0 * sqrt15 + 6.0 ) / 32.0; // 0.8525720202122554;
      _scalingDeCom[ 4 ] = sqrt02 * ( sqrt15 + 13.0 ) / 32.0; // 0.3378976624578092;
      _scalingDeCom[ 5 ] = sqrt02 * ( 9.0 - sqrt15 ) / 32.0; //-0.0727326195128539;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet1

  } // class

} // namespace
