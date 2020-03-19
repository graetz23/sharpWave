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
  /// Ingrid Daubechies' wavelet of eighteen coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db9/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies9 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies9( ) : base( "Daubechies 9", 18, 2 ) {
      _scalingDeCom[ 0 ] = 3.9347319995026124e-05;
      _scalingDeCom[ 1 ] = -0.0002519631889981789;
      _scalingDeCom[ 2 ] = 0.00023038576399541288;
      _scalingDeCom[ 3 ] = 0.0018476468829611268;
      _scalingDeCom[ 4 ] = -0.004281503681904723;
      _scalingDeCom[ 5 ] = -0.004723204757894831;
      _scalingDeCom[ 6 ] = 0.022361662123515244;
      _scalingDeCom[ 7 ] = 0.00025094711499193845;
      _scalingDeCom[ 8 ] = -0.06763282905952399;
      _scalingDeCom[ 9 ] = 0.030725681478322865;
      _scalingDeCom[ 10 ] = 0.14854074933476008;
      _scalingDeCom[ 11 ] = -0.09684078322087904;
      _scalingDeCom[ 12 ] = -0.29327378327258685;
      _scalingDeCom[ 13 ] = 0.13319738582208895;
      _scalingDeCom[ 14 ] = 0.6572880780366389;
      _scalingDeCom[ 15 ] = 0.6048231236767786;
      _scalingDeCom[ 16 ] = 0.24383467463766728;
      _scalingDeCom[ 17 ] = 0.03807794736316728;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies9

  } // class

} // namespace
