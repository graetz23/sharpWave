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
  /// Ingrid Daubechies' wavelet of twelve coefficients in orthonormal version.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies6 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies6( ) : base( "Daubechies 6", 12, 2 ) {
      _scalingDeCom[ 0 ] = -0.00107730108499558;
      _scalingDeCom[ 1 ] = 0.004777257511010651;
      _scalingDeCom[ 2 ] = 0.0005538422009938016;
      _scalingDeCom[ 3 ] = -0.031582039318031156;
      _scalingDeCom[ 4 ] = 0.02752286553001629;
      _scalingDeCom[ 5 ] = 0.09750160558707936;
      _scalingDeCom[ 6 ] = -0.12976686756709563;
      _scalingDeCom[ 7 ] = -0.22626469396516913;
      _scalingDeCom[ 8 ] = 0.3152503517092432;
      _scalingDeCom[ 9 ] = 0.7511339080215775;
      _scalingDeCom[ 10 ] = 0.4946238903983854;
      _scalingDeCom[ 11 ] = 0.11154074335008017;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies6

  } // class

} // namespace
