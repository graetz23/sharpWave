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
  /// Ingrid Daubechies' wavelet of six coefficients in orthonormal version.
  /// The computation is analytical and has - nearly - no rounding error.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:23:20
  ///</remarks>
  public class Daubechies3 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 25.03.2010 14:03:20
    ///</remarks>
    public Daubechies3( ) : base( "Daubechies 3", 6, 2 ) {
      double sqrt02 = Math.Sqrt( 2.0 ) ; // 1.4142135623730951
      double sqrt10 = Math.Sqrt( 10.0 );
      double constA = Math.Sqrt( 5.0 + 2.0 * sqrt10 );
      _scalingDeCom[ 0 ] = ( 1.0 +  1.0 * sqrt10 + 1.0 * constA ) / 16.0; // h0 = 0.47046720778416373
      _scalingDeCom[ 1 ] = ( 5.0 +  1.0 * sqrt10 + 3.0 * constA ) / 16.0; // h1 = 1.1411169158314438
      _scalingDeCom[ 2 ] = ( 10.0 - 2.0 * sqrt10 + 2.0 * constA ) / 16.0; // h2 = 0.6503650005262325
      _scalingDeCom[ 3 ] = ( 10.0 - 2.0 * sqrt10 - 2.0 * constA ) / 16.0; // h3 = -0.1909344155683274
      _scalingDeCom[ 4 ] = ( 5.0 +  1.0 * sqrt10 - 3.0 * constA ) / 16.0; // h4 = -0.1208322083103962
      _scalingDeCom[ 5 ] = ( 1.0 +  1.0 * sqrt10 - 1.0 * constA ) / 16.0; // h5 = 0.049817499736883764
      for( int i = 0; i < _motherWavelength; i++ )
        _scalingDeCom[ i ] /= sqrt02;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies3

  } // class

} // namespace
