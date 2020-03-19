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
  /// Ingrid Daubechies' wavelet of fourteen coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db7/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies7 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies7( ) : base( "Daubechies 7", 14, 2 ) {
      _scalingDeCom[ 0 ] = 0.0003537138000010399;
      _scalingDeCom[ 1 ] = -0.0018016407039998328;
      _scalingDeCom[ 2 ] = 0.00042957797300470274;
      _scalingDeCom[ 3 ] = 0.012550998556013784;
      _scalingDeCom[ 4 ] = -0.01657454163101562;
      _scalingDeCom[ 5 ] = -0.03802993693503463;
      _scalingDeCom[ 6 ] = 0.0806126091510659;
      _scalingDeCom[ 7 ] = 0.07130921926705004;
      _scalingDeCom[ 8 ] = -0.22403618499416572;
      _scalingDeCom[ 9 ] = -0.14390600392910627;
      _scalingDeCom[ 10 ] = 0.4697822874053586;
      _scalingDeCom[ 11 ] = 0.7291320908465551;
      _scalingDeCom[ 12 ] = 0.39653931948230575;
      _scalingDeCom[ 13 ] = 0.07785205408506236;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies7

  } // class

} // namespace
