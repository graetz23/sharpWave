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
  /// Base class for - stepping - forward and reverse methods, due to this is
  /// "one kind of" a Fast Wavelet Transform (FWD) in 1-D using a specific
  /// wavelet as main part of the orthogonal (orthonormal) transform. See other
  /// wavelet classes for the core of the transform; e.g. class Haar1.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 10.02.2010 08:10:42
  ///</remarks>
  public class FastWaveletTransform : WaveletTransform {

    ///<summary>
    /// Constructor receiving a Wavelet object and setting identifier of
    /// transform.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 10.02.2010 08:10:42
    ///</remarks>
    public FastWaveletTransform( Wavelet wavelet ) :
      base( "Fast Wavelet Transform", wavelet ) {
    } // FastWaveletTransform

    ///<summary>
    /// Performs a 1-D forward transform from time domain to Hilbert domain
    /// using one kind of a Fast Wavelet Transform (FWT) algorithm for a given
    /// array of dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, ..,
    /// and so on. However, the algorithms stops for a supported level that has
    /// be in the range 0, .., p of the dimension of the input array; 0 is the
    /// time series itself and p is the maximal number of possible levels.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 22.03.2015 11:58:37
    ///</remarks>
    override public double[ ] forward( double[ ] arrTime, int level ) {
      if( !isBinary( arrTime.Length ) ) {
        throw new Types.Data_NotValid( "FastWaveletTransform#forward - " +
        "array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " +
        "use the Ancient Egyptian Decomposition for any other array length!" );
      } // if
      int length = arrTime.Length; // length of initial time domain
      int noOfLevels = calcExponent( length );
      if( level < 0 || level > noOfLevels ) {
        throw new Types.Data_NotValid( "FastWaveletTransform#forward - " +
        "given level is out of range for given array" );
      } // if
      double[ ] arrHilb = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrHilb[ i ] = arrTime[ i ];
      } // rows
      int l = 0;
      int h = length;
      int transformWavelength = _wavelet.TRANSFORMWAVELENGTH; // normally 2
      while( h >= transformWavelength && l < level ) {
        double[ ] arrPart = _wavelet.forward( arrHilb, h );
        for( int i = 0; i < h; i++ ) {
          arrHilb[ i ] = arrPart[ i ];
        } // rows
        h = h >> 1;
        l++;
      } // levels
      return arrHilb;
    } // forward

    ///<summary>
    /// Performs a 1-D reverse transform from Hilbert domain to time domain
    /// using one kind of a Fast Wavelet Transform (FWT) algorithm for a given
    /// array of dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, ..,
    /// and so on. However, the algorithms starts for at a supported level that
    /// has be in the range 0, .., p of the dimension of the input array; 0 is
    /// the time series itself and p is the maximal number of possible levels.
    /// The coefficients of the input array have to match to the supported
    /// level.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 22.03.2015 12:00:10
    ///</remarks>
    override public double[ ] reverse( double[ ] arrHilb, int level ) {
      if( !isBinary( arrHilb.Length ) ) {
        throw new Types.Data_NotValid( "FastWaveletTransform#reverse - " +
        "array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " +
        "use the Ancient Egyptian Decomposition for any other array length!" );
      } // if
      int length = arrHilb.Length; // length of first Hilbert space
      int noOfLevels = calcExponent( length );
      if( level < 0 || level > noOfLevels ) {
        throw new Types.Data_NotValid( "FastWaveletTransform#reverse - " +
       "given level is out of range for given array" );
      } // if
      double[ ] arrTime = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrTime[ i ] = arrHilb[ i ];
      } // rows
      int transformWavelength = _wavelet.TRANSFORMWAVELENGTH; // normally 2
      int h = transformWavelength;
      int steps = calcExponent( length );
      for( int l = level; l < steps; l++ ) {
        h = h << 1; // reverse transform at matching level of Hilbert space
      } // levels
      while( h <= arrTime.Length && h >= transformWavelength ) {
        double[ ] arrPart = _wavelet.reverse( arrTime, h );
        for( int i = 0; i < h; i++ ) {
          arrTime[ i ] = arrPart[ i ];
        } // rows
        h = h << 1;
      } // levels
      return arrTime;
    } // reverse

  } // FastWaveletTransfrom

} // namespace
