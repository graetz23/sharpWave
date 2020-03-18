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
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of eighteen coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:58:59
  ///</remarks>
  public class Coiflet3 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// eighteen coefficients, orthonormalizes them (normed, due to ||*||2
    /// euclidean norm), and builds the scaling coefficients, and the
    /// orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:58:59
    ///</remarks>
    public Coiflet3( ) : base( "Coiflet 3", 18, 2 ) {
      _scalingDeCom[ 0 ] = -3.459977283621256e-05;
      _scalingDeCom[ 1 ] = -7.098330313814125e-05;
      _scalingDeCom[ 2 ] = 0.0004662169601128863;
      _scalingDeCom[ 3 ] = 0.0011175187708906016;
      _scalingDeCom[ 4 ] = -0.0025745176887502236;
      _scalingDeCom[ 5 ] = -0.00900797613666158;
      _scalingDeCom[ 6 ] = 0.015880544863615904;
      _scalingDeCom[ 7 ] = 0.03455502757306163;
      _scalingDeCom[ 8 ] = -0.08230192710688598;
      _scalingDeCom[ 9 ] = -0.07179982161931202;
      _scalingDeCom[ 10 ] = 0.42848347637761874;
      _scalingDeCom[ 11 ] = 0.7937772226256206;
      _scalingDeCom[ 12 ] = 0.4051769024096169;
      _scalingDeCom[ 13 ] = -0.06112339000267287;
      _scalingDeCom[ 14 ] = -0.0657719112818555;
      _scalingDeCom[ 15 ] = 0.023452696141836267;
      _scalingDeCom[ 16 ] = 0.007782596427325418;
      _scalingDeCom[ 17 ] = -0.003793512864491014;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet3

  } // class

} // namespace
