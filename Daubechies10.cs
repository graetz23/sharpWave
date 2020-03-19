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
  /// Ingrid Daubechies' wavelet of twenty coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db10/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies10 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies10( ) : base( "Daubechies 10", 20, 2 ) {
      _scalingDeCom[ 0 ] = -1.326420300235487e-05;
      _scalingDeCom[ 1 ] = 9.358867000108985e-05;
      _scalingDeCom[ 2 ] = -0.0001164668549943862;
      _scalingDeCom[ 3 ] = -0.0006858566950046825;
      _scalingDeCom[ 4 ] = 0.00199240529499085;
      _scalingDeCom[ 5 ] = 0.0013953517469940798;
      _scalingDeCom[ 6 ] = -0.010733175482979604;
      _scalingDeCom[ 7 ] = 0.0036065535669883944;
      _scalingDeCom[ 8 ] = 0.03321267405893324;
      _scalingDeCom[ 9 ] = -0.02945753682194567;
      _scalingDeCom[ 10 ] = -0.07139414716586077;
      _scalingDeCom[ 11 ] = 0.09305736460380659;
      _scalingDeCom[ 12 ] = 0.12736934033574265;
      _scalingDeCom[ 13 ] = -0.19594627437659665;
      _scalingDeCom[ 14 ] = -0.24984642432648865;
      _scalingDeCom[ 15 ] = 0.2811723436604265;
      _scalingDeCom[ 16 ] = 0.6884590394525921;
      _scalingDeCom[ 17 ] = 0.5272011889309198;
      _scalingDeCom[ 18 ] = 0.18817680007762133;
      _scalingDeCom[ 19 ] = 0.026670057900950818;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies10

  } // class

} // namespace
