///
/// SharpWave - a pragmatic port of JWave
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
/**
 * Base class for - stepping - forward and reverse methods, due to one kind of a
 * Fast Wavelet Transform (FWD) in 1-D using a specific Wavelet.
 *
 * @date 10.02.2010 08:10:42
 * @author Christian (graetz23@gmail.com)
 */
public class FastWaveletTransform : WaveletTransform {

  /**
   * Constructor receiving a Wavelet object and setting identifier of transform.
   *
   * @date 10.02.2010 08:10:42
   * @author Christian (graetz23@gmail.com)
   * @param wavelet
   *          object of type Wavelet
   */
  public FastWaveletTransform( Wavelet wavelet ) : base( wavelet ) {
    _name = "Fast Wavelet Transform"; // identifier of transform; keep constant
  } // FastWaveletTransform

  /**
   * Performs a 1-D forward transform from time domain to Hilbert domain using
   * one kind of a Fast Wavelet Transform (FWT) algorithm for a given array of
   * dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on.
   * However, the algorithms stops for a supported level that has be in the
   * range 0, .., p of the dimension of the input array; 0 is the time series
   * itself and p is the maximal number of possible levels.
   *
   * @author Christian (graetz23@gmail.com)
   * @date 22.03.2015 11:58:37
   * @throws JWaveException
   *           if given array is not of length 2^p | pEN or given level does not
   *           match the supported domain (array)
   * @see jwave.transforms.BasicTransform#forward(double[], int)
   */
   override public double[ ] forward( double[ ] arrTime, int level ) {

    if( !isBinary( arrTime.Length ) )
      throw new Types.Data_NotValid(
          "FastWaveletTransform#forward - "
              + "given array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. "
              + "please use the Ancient Egyptian Decomposition for any other array length!" );

    int noOfLevels = calcExponent( arrTime.Length );
    if( level < 0 || level > noOfLevels )
      throw new Types.Data_NotValid( "FastWaveletTransform#forward - "
          + "given level is out of range for given array" );

    // Arrays.copyOf( arrTime, arrTime.length );
    double[ ] arrHilb = new double[ arrTime.Length ];
    for( int i = 0; i < arrTime.Length; i++ )
      arrHilb[ i ] = arrTime[ i ];


    int l = 0;
    int h = arrHilb.Length;
    int transformWavelength = _wavelet.getTransformWavelength( ); // normally 2
    while( h >= transformWavelength && l < level ) {

      double[ ] arrTempPart = _wavelet.forward( arrHilb, h );

      // System.arraycopy( arrTempPart, 0, arrHilb, 0, h );
      for( int i = 0; i < h; i++ ) {
        arrHilb[ i ] = arrTempPart[ i ];
      } // loop

      h = h >> 1;
      l++;

    } // levels

    return arrHilb;

  } // forward

  /**
   * Performs a 1-D reverse transform from Hilbert domain to time domain using
   * one kind of a Fast Wavelet Transform (FWT) algorithm for a given array of
   * dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on.
   * However, the algorithms starts for at a supported level that has be in the
   * range 0, .., p of the dimension of the input array; 0 is the time series
   * itself and p is the maximal number of possible levels. The coefficients of
   * the input array have to match to the supported level.
   *
   * @author Christian (graetz23@gmail.com)
   * @date 22.03.2015 12:00:10
   * @throws JWaveException
   *           if given array is not of length 2^p | pEN or given level does not
   *           match the supported domain (array)
   * @see jwave.transforms.BasicTransform#reverse(double[], int)
   */
  override public double[ ] reverse( double[ ] arrHilb, int level )
  {

    if( !isBinary( arrHilb.Length ) )
      throw new Types.Data_NotValid(
          "FastWaveletTransform#reverse - "
              + "given array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. "
              + "please use the Ancient Egyptian Decomposition for any other array length!" );

    int noOfLevels = calcExponent( arrHilb.Length );
    if( level < 0 || level > noOfLevels )
      throw new Types.Data_NotValid( "FastWaveletTransform#reverse - "
          + "given level is out of range for given array" );

    int length = arrHilb.Length; // length of first Hilbert space
    // double[ ] arrTime = Arrays.copyOf( arrHilb, length );
    double[ ] arrTime = new double[ arrHilb.Length ];
    for( int i = 0; i < arrHilb.Length; i++ )
      arrTime[ i ] = arrHilb[ i ];

    int transformWavelength = _wavelet.getTransformWavelength( ); // normally 2
    int h = transformWavelength;

    int steps = calcExponent( length );
    for( int l = level; l < steps; l++ )
      h = h << 1; // begin reverse transform at certain - matching - level of Hilbert space

    while( h <= arrTime.Length && h >= transformWavelength ) {

      double[ ] arrTempPart = _wavelet.reverse( arrTime, h );

      // System.arraycopy( arrTempPart, 0, arrTime, 0, h );
      for( int i = 0; i < h; i++ ) {
        arrTime[ i ] = arrTempPart[ i ];
      } // loop

      h = h << 1;

    } // levels

    return arrTime;

  } // reverse

} // FastWaveletTransfrom

} // namespace
