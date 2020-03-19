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
  /// Ingrid Daubechies' wavelet of twenty-two coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db11/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies11 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies11( ) : base( "Daubechies 11", 22, 2 ) {
      _scalingDeCom[ 0 ] = 4.494274277236352e-06;
      _scalingDeCom[ 1 ] = -3.463498418698379e-05;
      _scalingDeCom[ 2 ] = 5.443907469936638e-05;
      _scalingDeCom[ 3 ] = 0.00024915252355281426;
      _scalingDeCom[ 4 ] = -0.0008930232506662366;
      _scalingDeCom[ 5 ] = -0.00030859285881515924;
      _scalingDeCom[ 6 ] = 0.004928417656058778;
      _scalingDeCom[ 7 ] = -0.0033408588730145018;
      _scalingDeCom[ 8 ] = -0.015364820906201324;
      _scalingDeCom[ 9 ] = 0.02084090436018004;
      _scalingDeCom[ 10 ] = 0.03133509021904531;
      _scalingDeCom[ 11 ] = -0.06643878569502022;
      _scalingDeCom[ 12 ] = -0.04647995511667613;
      _scalingDeCom[ 13 ] = 0.14981201246638268;
      _scalingDeCom[ 14 ] = 0.06604358819669089;
      _scalingDeCom[ 15 ] = -0.27423084681792875;
      _scalingDeCom[ 16 ] = -0.16227524502747828;
      _scalingDeCom[ 17 ] = 0.41196436894789695;
      _scalingDeCom[ 18 ] = 0.6856867749161785;
      _scalingDeCom[ 19 ] = 0.44989976435603013;
      _scalingDeCom[ 20 ] = 0.1440670211506196;
      _scalingDeCom[ 21 ] = 0.01869429776147044;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies11

  } // class

} // namespace