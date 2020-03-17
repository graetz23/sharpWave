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
  /// Base class for a Fast Wavelet Packet Transform (WPT) or Wavelet Packet
  /// Decomposition (WPD) using adapted 1-D forward and reverse (stepping)
  /// methods. All other methods like 2-D, 3-D, and so on, are working by
  /// using these central 1D methods for transforms.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 23.02.2010 13:44:05
  ///</remarks>
  public class WaveletPacketTransform : WaveletTransform {

    ///<summary>
    /// Constructor receiving a Wavelet object and setting identifier of
    /// transform.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 23.02.2010 13:44:05
    ///</remarks>
    public WaveletPacketTransform( Wavelet wavelet ) :
      base( "Wavelet Packet Transform", wavelet ) {
    } // method

    ///<summary>
    /// Performs a 1-D forward transform from time domain to Hilbert domain
    /// using one kind of a Wavelet Packet Transform (WPT) algorithm for a given
    /// array of dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, ..,
    /// and so on. However, the algorithm stops at a supported level that has
    /// to be in the range 0, .., p of the dimension of the input array; 0 is
    /// the time series itself and p is the maximal number of possible levels.
    /// If given array is not of length 2^p | pEN or the given level is out of
    /// range for the supported Hilbert space (array), the method trows a data
    /// not valid exception.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 22.03.2015 12:35:15
    ///</remarks>
    override public double[ ] forward( double[ ] arrTime, int level ) {
      if( !isBinary( arrTime.Length ) )
        throw new Types.Data_NotValid( "WaveletPacketTransform.forward - " +
        "array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " +
        "use the Ancient Egyptian Decomposition for any other array length!" );
      int noOfLevels = calcExponent( arrTime.Length );
      if( level < 0 || level > noOfLevels )
        throw new Types.Data_NotValid( "WaveletPacketTransform.forward - " +
        "given level is out of range for given array: " + level );
      int length = arrTime.Length;
      double[ ] arrHilb = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrHilb[ i ] = arrTime[ i ];
      } // rows
      int k = length;
      int h = length;
      int transformWavelength = _wavelet.TRANSFORMWAVELENGTH; // 2, 4, 8, ..
      int l = 0;
      while( h >= transformWavelength && l < level ) {
        int g = k / h; // 1 -> 2 -> 4 -> 8 -> ...
        for( int p = 0; p < g; p++ ) {
          double[ ] iBuf = new double[ h ];
          for( int i = 0; i < h; i++ ) {
            iBuf[ i ] = arrHilb[ i + ( p * h ) ];
          } // rows
          double[ ] oBuf = _wavelet.forward( iBuf, h );
          for( int i = 0; i < h; i++ ) {
            arrHilb[ i + ( p * h ) ] = oBuf[ i ];
          } // rows
        } // packets
        h = h >> 1;
        l++;
      } // levels
      return arrHilb;
    } // forward

    ///<summary>
    /// Performs a 1-D forward transform from Hilbert domain to time domain
    /// using one kind of a Wavelet Packet Transform (WPT) algorithm for a given
    /// array of dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, ..,
    /// and so on. However, the algorithm starts at a supported level that has
    /// to be in the range 0, .., p of the dimension of the input array and has
    /// to match the level of the supported Hilbert domain (transform level of
    /// input data); 0 is the time series itself and p is the maximal number of
    // possible levels. If given array is not of length 2^p | pEN or the given
    /// level is out of range for the supported Hilbert space (array), the
    /// method trows a data not valid exception.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 22.03.2015 12:38:23
    ///</remarks>
    override public double[ ] reverse( double[ ] arrHilb, int level ) {
      if( !isBinary( arrHilb.Length ) )
        throw new Types.Data_NotValid( "WaveletPacketTransform.reverse - " +
        "array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " +
        "use the Ancient Egyptian Decomposition for any other array length!" );
      int noOfLevels = calcExponent( arrHilb.Length );
      if( level < 0 || level > noOfLevels )
        throw new Types.Data_NotValid( "WaveletPacketTransform.reverse - " +
        "given level is out of range for given array: " + level );
      int length = arrHilb.Length; // length of first Hilbert space
      double[ ] arrTime = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrTime[ i ] = arrHilb[ i ];
      } // rows
      int transformWavelength = _wavelet.TRANSFORMWAVELENGTH; // 2, 4, 8, ..
      int k = length;
      int h = transformWavelength;
      int steps = calcExponent( length );
      for( int l = level; l < steps; l++ ) {
        h = h << 1; // reverse transform at matching level of hilbert space
      } // levels
      while( h <= length && h >= transformWavelength ) {
        int g = k / h; // ... -> 8 -> 4 -> 2 -> 1
        for( int p = 0; p < g; p++ ) {
          double[ ] iBuf = new double[ h ];
          for( int i = 0; i < h; i++ ) {
            iBuf[ i ] = arrTime[ i + ( p * h ) ];
          } // rows
          double[ ] oBuf = _wavelet.reverse( iBuf, h );
          for( int i = 0; i < h; i++ ) {
            arrTime[ i + ( p * h ) ] = oBuf[ i ];
          } // rows
        } // packets
        h = h << 1;
      } // levels
      return arrTime;
    } // reverse

  } // class

} // namespace
