///
/// SharpWave - A refactored port of JWave
/// https://github.com/graetz23/JWave
///
/// MIT License
///
/// Copyright (c) 2020-2024 Christian (graetz23@gmail.com)
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
  /// Shifting Wavelet Transform shifts a wavelet of smallest wavelength over
  /// the input array, then by the double wavelength, .., and so on.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2016 23:12:55
  /// TODO The algorithm stops one step to early; it could do one step more!
  ///</remarks>
  public class ShiftingWaveletTransform : WaveletTransform {

    ///<summary>
    /// Constructor taking Wavelet object for performing the transform.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2016 23:12:55
    ///</remarks>
    public ShiftingWaveletTransform( Wavelet wavelet ) :
      base( "Shifting Wavelet Transform", wavelet ) {
    } // method

    ///<summary>
    /// Forward method that uses strictly the abilities of an orthogonal
    /// transform.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2016 23:12:55
    ///</remarks>
    ///<returns>
    /// The block wise shifted frequency or Hilbert domain.
    ///</returns>
    override public double[ ] forward( double[ ] arrTime ) {
      int length = arrTime.Length;
      int div = 2;
      int odd = length % div; // if odd == 1 => steps * 2 + odd else steps * 2
      double[ ] arrHilb = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrHilb[ i ] = arrTime[ i ];
      } // rows
      while( div <= length ) {
        int splits = length / div; // cuts the digits == round down to full
        // doing smallest wavelength of div by no of steps
        for( int s = 0; s < splits; s++ ) {
          double[ ] arrDiv = new double[ div ];
          double[ ] arrRes = null;
          for( int p = 0; p < div; p++ ) {
            arrDiv[ p ] = arrHilb[ s * div + p ];
          } // shifted rows
          arrRes = _wavelet.forward( arrDiv, div );
          for( int q = 0; q < div; q++ ) {
            arrHilb[ s * div + q ] = arrRes[ q ];
          } // shifted rows
        } // shifts
        div *= 2;
      } // while
      if( odd == 1 ) {
        arrHilb[ length - 1 ] = arrTime[ length - 1 ];
      } // if
      return arrHilb;
    } // forward

    ///<summary>Method wrapper due to levels are not available.</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2016 23:12:55
    ///</remarks>
    ///<returns>
    /// The block wise shifted frequency or Hilbert domain.
    ///</returns>
    override public double[ ] forward( double[ ] arrTime, int level ) {
      return forward( arrTime );
    } // forward

    ///<summary>
    /// Reverse method that uses strictly the abilities of an orthogonal
    /// transform.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2016 23:12:55
    ///</remarks>
    ///<returns>
    /// The reconstructed time domain for a block wise shifted frequency or
    /// Hilbert domain.
    ///</returns>
    override public double[ ] reverse( double[ ] arrHilb ) {
      int length = arrHilb.Length;
      int div = 0;
      if( length % 2 == 0 ) {
        div = length;
      } else {
        div = length / 2; // 2 = 4.5 => 4
        div *= 2; // 4 * 2 = 8
      } // if
      int odd = length % div; // if odd == 1 => steps * 2 + odd else steps * 2
      double[ ] arrTime = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrTime[ i ] = arrHilb[ i ];
      } // row
      while( div >= 2 ) {
        int splits = length / div; // cuts the digits == round down to full
        // doing smallest wavelength of div by no of steps
        for( int s = 0; s < splits; s++ ) {
          double[ ] arrDiv = new double[ div ];
          double[ ] arrRes = null;
          for( int p = 0; p < div; p++ ) {
            arrDiv[ p ] = arrTime[ s * div + p ];
          } // shifted rows
          arrRes = _wavelet.reverse( arrDiv, div );
          for( int q = 0; q < div; q++ ) {
            arrTime[ s * div + q ] = arrRes[ q ];
          } // shifted rows
        } // shifts
        div /= 2;
      } // while
      if( odd == 1 ) {
        arrTime[ length - 1 ] = arrHilb[ length - 1 ];
      } // if
      return arrTime;
    } // reverse

    ///<summary>Method wrapper due to levels are not available.</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2016 23:12:55
    ///</remarks>
    ///<returns>
    /// The reconstructed time domain for a block wise shifted frequency or
    /// Hilbert domain.
    ///</returns>
    override public double[ ] reverse( double[ ] arrHilb, int level ) {
      return reverse( arrHilb );
    } // reverse

  } // class

} // namespace
