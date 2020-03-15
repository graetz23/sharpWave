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
using System;

namespace SharpWave
{

  ///<summary>
  /// Basic Wave for transformations like Fast Fourier Transform (FFT), Fast
  /// Wavelet Transform (FWT), Fast Wavelet Packet Transform (WPT), or Discrete
  /// Wavelet Transform (DWT). Naming of this class due to en.wikipedia.org; to
  /// write Fourier series in terms of the 'basic waves' of function:
  /// e^(2*pi*i*w).
  ///</summary>
  ///<remarks>Christian (graetz23@gmail.com) 08.02.2010 11:11:59</remarks>
  public abstract class BasicTransform {

    ///<summary>String identifier of the current Transform object.</summary>
    ///<remarks>Christian (graetz23@gmail.com) 14.03.2015 14:25:56</remarks>
    protected String _type;

     ///<summary>Constructor taking type of transform as string.</summary>
     ///<remarks>Christian (graetz23@gmail.com) 19.02.2014 18:38:21</remarks>
    public BasicTransform( String type ) {
      if( String.IsNullOrWhiteSpace( type ) ) {
        throw new Types.Types_NotPossible( "BasicTransform - " +
          "given string for transform type is null, empty or whitespace!" );
        } // if
      _type = type;
    } // BasicTransform

    ///<returns>Returns identifier of type of BasicTransform Object.</returns>
    ///<remarks>Christian (graetz23@gmail.com) 14.03.2015 18:13:34</remarks>
    public String TYPE { get { return _type; } } // method

    ///<returns>Returns the Wavelet object or throws an exception.</returns>
    ///<remarks>Christian (graetz23@gmail.com) 14.03.2015 18:26:44</remarks>
    public virtual Wavelet WAVELET {
      get {
        throw new Types.Types_NotAvailable( "BasicTransform.WAVELET - " +
          "not available while this is not necessarily a wavelet transform!" );
        } // method
    } // method

    ///<summary>
    /// Performs the forward transform from time domain to frequency or Hilbert
    /// domain for a given 1-D array depending on the used transform algorithm
    /// by inheritance and overriding this method. All other forward methods
    /// like 2-D, 3-D, and so on, are using this method.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:23:24</remarks>
    ///<returns>Coefficients of 1-D frequency or Hilbert space.</returns>
    public abstract double[ ] forward( double[ ] arrTime );

    ///<summary>
    /// Performs the reverse transform from frequency or Hilbert domain to time
    /// domain for a given 1-D array depending on the used transform algorithm
    /// by inheritance and overriding this method. All other reverse methods
    /// like 2-D, 3-D, and so on, are using this method.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:23:42</remarks>
    ///<returns>
    /// Coefficients of time series of 1-D frequency or Hilbert space.
    ///</returns>
    public abstract double[ ] reverse( double[ ] arrFreq );

    ///<summary>
    /// Performs the forward transform from time domain to frequency or Hilbert
    /// domain for a given 1-D array depending on the used transform algorithm
    /// by inheritance and overriding this method. All other forward methods
    /// like 2-D, 3-D, and so on, are using this method.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com)  22.03.2015 11:33:11</remarks>
    ///<returns>
    /// Coefficients of 1-D frequency or Hilbert space of requested level.
    ///</returns>
    public virtual double[ ] forward( double[ ] arrTime, int level ) {
      throw new Types.Types_NotImplemented( "BasicTransform.forward - "
          + "method is not implemented for this transform type!" );
    } // forward

    ///<summary>
    /// Performs the reverse transform from frequency or Hilbert domain to time
    /// domain for a given 1-D array depending on the used transform algorithm
    /// by inheritance and overriding this method. All other reverse methods
    /// like 2-D, 3-D, and so on, are using this method.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 11:34:27</remarks>
    ///<returns>Coefficients of time series of requested level.</returns>
    public virtual double[ ] reverse( double[ ] arrFreq, int level ) {
      throw new Types.Types_NotAvailable( "BasicTransform.reverse - "
          + "method is not implemented for this transform type!" );
    } // reverse

    ///<summary>
    /// Performs the forward transform from time domain to frequency or Hilbert
    /// domain for a given 2-D array depending on the used transform algorithm
    /// by using the 1-D forward transform multiple times.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 12:47:01</remarks>
    ///<returns>Coefficients of 2-D frequency or Hilbert space.</returns>
    public double[ , ] forward( double[ , ] matTime ) {
      int maxM = calcExponent( matTime.GetUpperBound( 0 ) + 1 ); // no of rows
      int maxN = calcExponent( matTime.GetUpperBound( 1 ) + 1 ); // no of cols
      return forward( matTime, maxM, maxN );
    } // forward

    ///<summary>
    /// Performs the forward transform from time domain to frequency or Hilbert
    /// domain of certain levels for a given 2-D array depending on the used
    /// transform algorithm by using the 1-D forward transform multiple times.
    /// lvlM - level to stop in dimension row of the matrix.
    /// lvlN - level to stop in dimension columns of the matrix
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 11:00:29</remarks>
    ///<returns>
    /// Coefficients of 2-D frequency or Hilbert space of requested levels.
    ///</returns>
    public double[ , ] forward( double[ , ] matTime, int lvlM, int lvlN ) {
      int noOfRows = matTime.GetUpperBound( 0 ) + 1; // number of rows
      int noOfCols = matTime.GetUpperBound( 1 ) + 1; // number of cols
      double[ , ] matHilb = new double[ noOfRows , noOfCols ];
      for( int i = 0; i < noOfRows; i++ ) {
        double[ ] arrTime = new double[ noOfCols ];
        for( int j = 0; j < noOfCols; j++ ) {
          double val = matTime[ i , j ];
          arrTime[ j ] = val;
        } // cols
        double[ ] arrHilb = forward( arrTime, lvlN ); // 1-D forwards on cols
        for( int j = 0; j < noOfCols; j++ ) {
          double val = arrHilb[ j ];
          matHilb[ i , j ] = val;
        } // cols
      } // rows
      for( int j = 0; j < noOfCols; j++ ) {
        double[ ] arrTime = new double[ noOfRows ];
        for( int i = 0; i < noOfRows; i++ ) {
          double val = matHilb[ i , j ];
          arrTime[ i ] = val;
        } // rows
        double[ ] arrHilb = forward( arrTime, lvlM ); // 1-D forwards on rows
        for( int i = 0; i < noOfRows; i++ ) {
          double val = arrHilb[ i ];
          matHilb[ i , j ] = val;
        } // rows
      } // cols
      return matHilb;
    } // forward

    ///<summary>
    /// Performs the reverse transform from frequency or Hilbert domain to time
    /// domain for a given 2-D array depending on the used transform algorithm
    /// by by using the 1-D reverse transform multiple times.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 11:01:38</remarks>
    ///<returns>Coefficients of 2-D time series of requested level.</returns>
    public double[ , ] reverse( double[ , ] matFreq ) {
      int maxM = calcExponent( matFreq.GetUpperBound( 0 ) + 1 ); // no of rows
      int maxN = calcExponent( matFreq.GetUpperBound( 1 ) + 1 ); // no of cols
      return reverse( matFreq, maxM, maxN );
    } // reverse

    ///<summary>
    /// Performs the reverse transform from frequency or Hilbert domain to time
    /// domain of certain levels for a given 2-D array depending on the used
    /// transform algorithm by by using the 1-D reverse transform multiple
    /// times.
    /// lvlM - level to start reconstruction for dimension rows of the matrix
    /// lvlN - level to start reconstruction for dimension columns of the matrix
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 12:49:16</remarks>
    ///<returns>Coefficients of 2-D time series of requested level.</returns>
    public double[ , ] reverse( double[ , ] matFreq, int lvlM, int lvlN ) {
      int noOfRows = matFreq.GetUpperBound( 0 ) + 1; // no of rows
      int noOfCols = matFreq.GetUpperBound( 1 ) + 1; // no of cols
      double[ , ] matTime = new double[ noOfRows , noOfCols ];
      for( int j = 0; j < noOfCols; j++ ) {
        double[ ] arrFreq = new double[ noOfRows ];
        for( int i = 0; i < noOfRows; i++ ) {
           double val = matFreq[ i , j ];
           arrFreq[ i ] = val;
        } // rows
        double[ ] arrTime = reverse( arrFreq, lvlM ); // 1-D reverse for rows
        for( int i = 0; i < noOfRows; i++ ) {
          double val = arrTime[ i ];
          matTime[ i , j ] = val;
        } // rows
      } // cols
      for( int i = 0; i < noOfRows; i++ ) {
        double[ ] arrFreq = new double[ noOfCols ];
        for( int j = 0; j < noOfCols; j++ ) {
          double val = matTime[ i , j ];
          arrFreq[ j ] = val;
        } // cols
        double[ ] arrTime = reverse( arrFreq, lvlN ); // 1-D reverse for cols
        for( int j = 0; j < noOfCols; j++ ) {
          double val = arrTime[ j ];
          matTime[ i , j ] = val;
        } // cols
      } // rows
      return matTime;
    } // reverse

    ///<summary>
    /// Performs the forward transform from time domain to frequency or Hilbert
    /// domain for a given 3-D array depending on the used transform algorithm
    /// by using the 1-D forward transform multiple times.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.07.2010 18:08:17</remarks>
    ///<returns>Coefficients of 3-D frequency or Hilbert space.</returns>
    public double[ ,, ] forward( double[ ,, ] spcTime ) {
      int maxP = calcExponent( spcTime.GetUpperBound( 0 ) + 1 ); // no of rows
      int maxQ = calcExponent( spcTime.GetUpperBound( 1 ) + 1 ); // no of cols
      int maxR = calcExponent( spcTime.GetUpperBound( 2 ) + 1 ); // no of high
      return forward( spcTime, maxP, maxQ, maxR );
    } // forward

    ///<summary>
    /// Performs the forward transform from time domain to frequency or Hilbert
    /// domain of certain levels for a given 3-D array depending on the used
    /// transform algorithm by using the 1-D forward transform multiple times.
    /// lvlP - level to stop in dimension columns of the cube
    /// lvlQ - level to stop in dimension height of the cube
    /// lvlR - level to stop in dimension row of the cube
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 12:58:34</remarks>
    ///<returns>
    /// Coefficients of 3-D frequency or Hilbert space of requested levels.
    ///</returns>
    public double[ ,, ] forward( double[ ,, ] spcTime,
                                 int lvlP, int lvlQ, int lvlR ) {
      int noOfRows = spcTime.GetUpperBound( 0 ) + 1; // no of rows
      int noOfCols = spcTime.GetUpperBound( 1 ) + 1; // no of cols
      int noOfHigh = spcTime.GetUpperBound( 2 ) + 1; // no of high
      double[ ,, ] spcHilb = new double[ noOfRows , noOfCols , noOfHigh ];
      for( int i = 0; i < noOfRows; i++ ) {
        double[ , ] matTime = new double[ noOfCols , noOfHigh ];
        for( int j = 0; j < noOfCols; j++ ) {
          for( int k = 0; k < noOfHigh; k++ ) {
            double val = spcTime[ i , j , k ];
            matTime[ j , k ] = val;
          } // high
        } // cols
        double[ , ] matHilb = forward( matTime, lvlP, lvlQ ); // 2-D cols & high
        for( int j = 0; j < noOfCols; j++ ) {
          for( int k = 0; k < noOfHigh; k++ ) {
            double val = matHilb[ j , k ];
            spcHilb[ i , j , k ] = val;
          } // high
        } // cols
      } // rows
      for( int j = 0; j < noOfCols; j++ ) {
        for( int k = 0; k < noOfHigh; k++ ) {
          double[ ] arrTime = new double[ noOfRows ];
          for( int i = 0; i < noOfRows; i++ ) {
            double val = spcHilb[ i , j , k ];
            arrTime[ i ] = val;
          } // rows
          double[ ] arrHilb = forward( arrTime, lvlR ); // 1-D forward rows
          for( int i = 0; i < noOfRows; i++ ) {
            double val = arrHilb[ i ];
            spcHilb[ i , j , k ] = val;
          } // rows
        } // high
      } // cols
      return spcHilb;
    } // forward

    ///<summary>
    /// Performs the reverse transform from frequency or Hilbert domain to time
    /// domain for a given 3-D array depending on the used transform algorithm
    /// by by using the 1-D reverse transform multiple times.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.07.2010 18:09:54</remarks>
    ///<returns>Coefficients of 3-D time series of requested levels.</returns>
    public double[ ,, ] reverse( double[ ,, ] spcHilb ) {
      int maxP = calcExponent( spcHilb.GetUpperBound( 0 ) + 1 ); // no of rows
      int maxQ = calcExponent( spcHilb.GetUpperBound( 1 ) + 1 ); // no of cols
      int maxR = calcExponent( spcHilb.GetUpperBound( 2 ) + 1 ); // no of high
      return reverse( spcHilb, maxP, maxQ, maxR );
    } // reverse

    ///<summary>
    /// Performs the reverse transform from frequency or Hilbert domain to time
    /// domain of certain levels for a given 3-D array depending on the used
    /// transform algorithm by by using the 1-D reverse transform multiple
    /// times.
    /// lvlP - level to start reconstruction for dimension columns of the cube
    /// lvlQ - level to start reconstruction for dimension height of the cube
    /// lvlR - level to start reconstruction for dimension rows of the cube
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 13:01:47</remarks>
    ///<returns>Coefficients of 3-D time series of requested levels.</returns>
    public double[ ,, ] reverse( double[ ,, ] spcHilb,
                                 int lvlP, int lvlQ, int lvlR ) {
      int noOfRows = spcHilb.GetUpperBound( 0 ) + 1; // no of rows
      int noOfCols = spcHilb.GetUpperBound( 1 ) + 1; // no of cols
      int noOfHigh = spcHilb.GetUpperBound( 2 ) + 1; // no of high
      double[ ,, ] spcTime = new double[ noOfRows , noOfCols , noOfHigh ];
      for( int i = 0; i < noOfRows; i++ ) {
        double[ , ] matHilb = new double[ noOfCols , noOfHigh ];
        for( int j = 0; j < noOfCols; j++ ) {
          for( int k = 0; k < noOfHigh; k++ ) {
            double val = spcHilb[ i , j , k ];
            matHilb[ j , k ] = val;
          } // high
        } // cols
        double[ , ] matTime = reverse( matHilb, lvlP, lvlQ ); // 2-D cols & high
        for( int j = 0; j < noOfCols; j++ ) {
          for( int k = 0; k < noOfHigh; k++ ) {
            double val = matTime[ j , k ];
            spcTime[ i , j , k ] = val;
          } // high
        } // cols
      } // rows
      for( int j = 0; j < noOfCols; j++ ) {
        for( int k = 0; k < noOfHigh; k++ ) {
          double[ ] arrHilb = new double[ noOfRows ];
          for( int i = 0; i < noOfRows; i++ ) {
            double val = spcTime[ i , j , k ];
            arrHilb[ i ] = val;
          } // rows
          double[ ] arrTime = reverse( arrHilb, lvlR ); // 1-D reverse rows
          for( int i = 0; i < noOfRows; i++ ) {
            double val = arrTime[ i ];
            spcTime[ i , j , k ] = val;
          } // rows
        } // high
      } // cols
      return spcTime;
    } // reverse

    ///<summary>
    /// Returns true if given integer is of binary type: 1, 2, 4, 8, 16, ..
    /// else returns false.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 13:31:39</remarks>
    ///<returns>true if number is a binary number else false</returns>
    protected bool isBinary( int number ) {
      bool isBinary = false;
      int power = (int)( Math.Log( number ) / Math.Log( 2.0 ) );
      double result = 1.0 * Math.Pow( 2.0, power );
      if( result == number )
        isBinary = true;
      return isBinary;
    } // isBinary

    ///<summary>
    /// Returns the exponent of a binary a number or throws exception if the
    /// calculation of the exponent is not possible.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 13:35:50</remarks>
    ///<returns>p as number = 2^p | p € N</returns>
    protected int calcExponent( int number ) {
      if( !isBinary( number ) )
        throw new Types.Types_NotPossible( "BasicTransform.calcExponent - "
            + "given number is not binary: "
            + "2^p | pEN .. = 1, 2, 4, 8, 16, 32, .. " );
      int exp = (int)( Math.Log( number ) / Math.Log( 2.0 ) );
      return exp;
    } // calcExponent

    /**
     * Generates from a 2-D decomposition a 1-D time series.
     *
     * @author Christian (graetz23@gmail.com)
     * @date 17.08.2014 10:07:19
     * @param matDeComp
     *          2-D Hilbert spaces: [ 0 .. p ][ 0 .. N ] where p is the exponent
     *          of N=2^p
     * @return a 1-D time domain signal
     */
    // public virtual double[ ][ ] decompose( double[ ] arrTime ) {
    //   throw new Types.Types_NotAvailable( "BasicTransform#decompose - "
    //       + "method is not implemented for this transform type!" );
    // } // decompose

    /**
     * Generates from a 1-D signal a 2-D output, where the second dimension are
     * the levels of the wavelet transform. The first level should keep the
     * original coefficients. All following levels should keep each step of the
     * decomposition of the Fast Wavelet Transform. However, each level of the
     * this decomposition matrix is having the full set, full energy and full
     * details, that are needed to do a full reconstruction. So one can select a
     * level filter it and then do reconstruction only from this single line! BY
     * THIS METHOD, THE _HIGHEST_ LEVEL IS _ALWAYS_ TAKEN FOR RECONSTRUCTION!
     *
     * @author Christian (graetz23@gmail.com)
     * @date 17.08.2014 10:07:19
     * @param matDeComp
     *          2-D Hilbert spaces: [ 0 .. p ][ 0 .. M ] where p is the exponent
     *          of M=2^p | pEN
     */
    // public virtual double[ ] recompose( double[ ][ ] matDeComp ) {
    //   // Each level of the matrix is having the full set (full energy + details)
    //   // of decomposition. Therefore, each level can be used to do a full reconstruction,
    //   int level = matDeComp.Length - 1; // selected highest level in general.
    //   double[ ] arrTime = null;
    //   arrTime = recompose( matDeComp, level );
    //   return arrTime;
    // } // recompose

    /**
     * Generates from a 1-D signal a 2-D output, where the second dimension are
     * the levels of the wavelet transform. The first level should keep the
     * original coefficients. All following levels should keep each step of the
     * decomposition of the Fast Wavelet Transform. However, each level of the
     * this decomposition matrix is having the full set, full energy and full
     * details, that are needed to do a full reconstruction. So one can select a
     * level filter it and then do reconstruction only from this single line!
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 15:12:19
     * @param matDeComp
     *          2-D Hilbert spaces: [ 0 .. p ][ 0 .. M ] where p is the exponent
     *          of M=2^p | pEN
     * @param level
     *          the level that should be used for reconstruction
     * @return the reconstructed time series of a selected level
     */
    // public virtual double[ ] recompose( double[ ][ ] matDeComp, int level ) {
    //   double[ ] arrTime = null;
    //   arrTime = recompose( matDeComp, level );
    //   return arrTime;
    // } // recompose

    /**
     * Performs the forward transform from time domain to frequency or Hilbert
     * domain for a given array depending on the used transform algorithm by
     * inheritance.
     *
     * @date 16.02.2014 14:42:57
     * @author Christian (graetz23@gmail.com)
     * @param arrTime
     *          coefficients of 1-D time domain
     * @return coefficients of 1-D frequency or Hilbert domain
     * @throws JWaveException
     */
    // public virtual Complex[ ] forward( Complex[ ] arrTime ) {
    //
    //   double[ ] arrTimeBulk = new double[ 2 * arrTime.Length ];
    //
    //   for( int i = 0; i < arrTime.Length; i++ ) {
    //
    //     // TODO rehack complex number splitting this to: { r1, r2, r3, .., c1, c2, c3, .. }
    //     int k = i * 2;
    //     arrTimeBulk[ k ] = arrTime[ i ].getReal( );
    //     arrTimeBulk[ k + 1 ] = arrTime[ i ].getImag( );
    //
    //   } // i blown to k = 2 * i
    //
    //   double[ ] arrHilbBulk = forward( arrTimeBulk );
    //
    //   Complex[ ] arrHilb = new Complex[ arrTime.Length ];
    //
    //   for( int i = 0; i < arrTime.length; i++ ) {
    //
    //     int k = i * 2;
    //     arrHilb[ i ] = new Complex( arrHilbBulk[ k ], arrHilbBulk[ k + 1 ] );
    //
    //   } // k = 2 * i shrink to i
    //
    //   return arrHilb;
    //
    // } // forward

    /**
     * Performs the reverse transform from frequency or Hilbert domain to time
     * domain for a given array depending on the used transform algorithm by
     * inheritance.
     *
     * @date 16.02.2014 14:42:57
     * @author Christian (graetz23@gmail.com)
     * @param arrFreq
     *          coefficients of 1-D frequency or Hilbert domain
     * @return coefficients of 1-D time domain
     * @throws JWaveException
     */
    // public Complex[ ] reverse( Complex[ ] arrHilb ) throws JWaveException {
    //
    //   double[ ] arrHilbBulk = new double[ 2 * arrHilb.length ];
    //
    //   for( int i = 0; i < arrHilb.length; i++ ) {
    //
    //     int k = i * 2;
    //     arrHilbBulk[ k ] = arrHilb[ i ].getReal( );
    //     arrHilbBulk[ k + 1 ] = arrHilb[ i ].getImag( );
    //
    //   } // i blown to k = 2 * i
    //
    //   double[ ] arrTimeBulk = reverse( arrHilbBulk );
    //
    //   Complex[ ] arrTime = new Complex[ arrHilb.length ];
    //
    //   for( int i = 0; i < arrTime.length; i++ ) {
    //
    //     int k = i * 2;
    //     arrTime[ i ] = new Complex( arrTimeBulk[ k ], arrTimeBulk[ k + 1 ] );
    //
    //   } // k = 2 * i shrink to i
    //
    //   return arrTime;
    //
    // } // reverse

  } // BasicTransform

} // namespace
