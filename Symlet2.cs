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

namespace SharpWave
{

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym2/ Thanks!
  /// However there are likely to be some rounding errors: ~1e-12.
  /// For example: 1.1 => 1,10000000000209 or 3,3 => 3,29999999999917 ..
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
  /// TODO Please report the analytical formula for construction, if available
  ///</remarks>
  public class Symlet2 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet of
    /// four coefficients, orthonormalizes them (normed, due to ||*||2
    /// euclidean norm), and builds the scaling coefficients, and the
    /// orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet2( ) : base( "Symlet 2", 4, 2 ) {
      // these coefficients are already orthonormal
      _scalingDeCom[ 0 ] = -0.12940952255092145;
      _scalingDeCom[ 1 ] = 0.22414386804185735;
      _scalingDeCom[ 2 ] = 0.836516303737469;
      _scalingDeCom[ 3 ] = 0.48296291314469025;
      //
      // _waveletDeCom[ 0 ] = -0.48296291314469025;
      // _waveletDeCom[ 1 ] = 0.836516303737469;
      // _waveletDeCom[ 2 ] = -0.22414386804185735;
      // _waveletDeCom[ 3 ] = -0.12940952255092145;
      //
      // _scalingReCon[ 0 ] = 0.48296291314469025;
      // _scalingReCon[ 1 ] = 0.836516303737469;
      // _scalingReCon[ 2 ] = 0.22414386804185735;
      // _scalingReCon[ 3 ] = -0.12940952255092145;
      //
      // _waveletReCon[ 0 ] = -0.12940952255092145;
      // _waveletReCon[ 1 ] = -0.22414386804185735;
      // _waveletReCon[ 2 ] = 0.836516303737469;
      // _waveletReCon[ 3 ] = -0.48296291314469025;
      //
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Symlet2

  } // class

} // namespace
