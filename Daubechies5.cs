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
  /// Ingrid Daubechies' wavelet of ten coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db5/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies5 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies5( ) : base( "Daubechies 5", 10, 2 ) {
      _scalingDeCom[ 0 ] = 0.003335725285001549;
      _scalingDeCom[ 1 ] = -0.012580751999015526;
      _scalingDeCom[ 2 ] = -0.006241490213011705;
      _scalingDeCom[ 3 ] = 0.07757149384006515;
      _scalingDeCom[ 4 ] = -0.03224486958502952;
      _scalingDeCom[ 5 ] = -0.24229488706619015;
      _scalingDeCom[ 6 ] = 0.13842814590110342;
      _scalingDeCom[ 7 ] = 0.7243085284385744;
      _scalingDeCom[ 8 ] = 0.6038292697974729;
      _scalingDeCom[ 9 ] = 0.160102397974125;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies5

  } // class

} // namespace
