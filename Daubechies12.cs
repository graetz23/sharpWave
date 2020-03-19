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
  /// Ingrid Daubechies' wavelet of twenty-four coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db12/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies12 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies12( ) : base( "Daubechies 12", 24, 2 ) {
      _scalingDeCom[ 0 ] = -1.5290717580684923e-06;
      _scalingDeCom[ 1 ] = 1.2776952219379579e-05;
      _scalingDeCom[ 2 ] = -2.4241545757030318e-05;
      _scalingDeCom[ 3 ] = -8.850410920820318e-05;
      _scalingDeCom[ 4 ] = 0.0003886530628209267;
      _scalingDeCom[ 5 ] = 6.5451282125215034e-06;
      _scalingDeCom[ 6 ] = -0.0021795036186277044;
      _scalingDeCom[ 7 ] = 0.0022486072409952287;
      _scalingDeCom[ 8 ] = 0.006711499008795549;
      _scalingDeCom[ 9 ] = -0.012840825198299882;
      _scalingDeCom[ 10 ] = -0.01221864906974642;
      _scalingDeCom[ 11 ] = 0.04154627749508764;
      _scalingDeCom[ 12 ] = 0.010849130255828966;
      _scalingDeCom[ 13 ] = -0.09643212009649671;
      _scalingDeCom[ 14 ] = 0.0053595696743599965;
      _scalingDeCom[ 15 ] = 0.18247860592758275;
      _scalingDeCom[ 16 ] = -0.023779257256064865;
      _scalingDeCom[ 17 ] = -0.31617845375277914;
      _scalingDeCom[ 18 ] = -0.04476388565377762;
      _scalingDeCom[ 19 ] = 0.5158864784278007;
      _scalingDeCom[ 20 ] = 0.6571987225792911;
      _scalingDeCom[ 21 ] = 0.3773551352142041;
      _scalingDeCom[ 22 ] = 0.10956627282118277;
      _scalingDeCom[ 23 ] = 0.013112257957229239;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies12

  } // class

} // namespace
