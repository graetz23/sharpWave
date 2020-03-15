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

  /// <summary>
  /// Basic class for transforms.
  /// </summary>
  public class Transform
  {

    /**
     * Transform object of type base class
     */
    protected BasicTransform _basicTransform;

    /**
     * Constructor; needs some object like DiscreteFourierTransform,
     * FastBasicTransform, WaveletPacketTransfom, ...
     *
     * @date 19.05.2009 09:50:24
     * @author Christian (graetz23@gmail.com)
     * @param transform
     *          Transform object
     */
    public Transform( BasicTransform basicTransform )
    {
      if(basicTransform == null )
        throw new Types.Types_NotExistent( "Given transform object is null!" );
      if(!(basicTransform is BasicTransform))
        throw new Types.Types_NotValid( "Given transform object is not correct type!" );
      _basicTransform = basicTransform;
    } // method

    /**
     * Performs the forward transform of the specified BasicWave object.
     *
     * @date 10.02.2010 09:41:01
     * @author Christian (graetz23@gmail.com)
     * @param arrTime
     *          coefficients of time domain
     * @return coefficients of frequency or Hilbert domain
     */
    public double[ ] forward( double[ ] arrTime ) {
      double[ ] arrHilb = null;
      arrHilb = _basicTransform.forward( arrTime );
      return arrHilb;
    } // forward

    /**
     * Performs the reverse transform of the specified BasicWave object.
     *
     * @date 10.02.2010 09:42:18
     * @author Christian (graetz23@gmail.com)
     * @param arrHilb
     *          coefficients of frequency or Hilbert domain
     * @return coefficients of time domain
     */
    public double[ ] reverse( double[ ] arrHilb ) {
      double[ ] arrTime = null;
      arrTime = _basicTransform.reverse( arrHilb );
      return arrTime;
    } // reverse

    /**
     * Performs a forward transform to a certain level of Hilbert space.
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 11:53:05
     * @param arrTime
     *          array of length 2^p | p E N .. 2, 4, 8, 16, 32, 64, ...
     * @param level
     *          a certain level that matches the array
     * @return Hilbert space of certain level
     */
    public double[ ] forward( double[ ] arrTime, int level ) {
      double[ ] arrHilb = null;
      arrHilb = _basicTransform.forward( arrTime, level );
      return arrHilb;
    } // forward

    /**
     * Performs a reverse transform for a Hilbert space of certain level; level
     * has to match the supported coefficients in the array!
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 11:54:59
     * @param arrHilb
     *          Hilbert space by an array of length 2^p | p E N .. 2, 4, 8, 16,
     *          32, 64, ...
     * @param level
     *          the certain level the supported hilbert space
     * @return time domain for a certain level of Hilbert space
     */
    public double[ ] reverse( double[ ] arrHilb, int level ) {
      double[ ] arrTime = null;
      arrTime = _basicTransform.reverse( arrHilb, level );
      return arrTime;
    } // reverse

    /**
     * Performs the 2-D forward transform of the specified BasicWave object.
     *
     * @date 10.02.2010 10:58:54
     * @author Christian (graetz23@gmail.com)
     * @param matrixTime
     *          coefficients of 2-D time domain; internal M(i),N(j)
     * @return coefficients of 2-D frequency or Hilbert domain
     */
    public double[ , ] forward( double[ , ] matrixTime ) {
      double[ , ] matrixHilb = null;
      matrixHilb = _basicTransform.forward( matrixTime );
      return matrixHilb;
    } // forward

    /**
     * Performs the 2-D reverse transform of the specified BasicWave object.
     *
     * @date 10.02.2010 10:59:32
     * @author Christian (graetz23@gmail.com)
     * @param matrixFreq
     *          coefficients of 2-D frequency or Hilbert domain; internal
     *          M(i),N(j)
     * @return coefficients of 2-D time domain
     */
    public double[ , ] reverse( double[ , ] matrixHilb ) {
      double[ , ] matrixTime = null;
      matrixTime = _basicTransform.reverse( matrixHilb );
      return matrixTime;
    } // reverse

    /**
     * Performs the 2-D forward transform of the specified BasicWave object.
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 14:40:54
     * @param matrixTime
     *          coefficients of 2-D time domain; internal M(i),N(j)
     * @param levelM
     *          a certain level to stop transform for over rows
     * @param levelN
     *          a certain level to stop transform for over columns
     * @return coefficients of 2-D frequency or Hilbert domain
     */
    public double[ , ] forward( double[ , ] matrixTime,
                                int levelM, int levelN ) {
      double[ , ] matrixHilb = null;
      matrixHilb = _basicTransform.forward( matrixTime, levelM, levelN );
      return matrixHilb;
    } // forward

    /**
     * Performs the 2-D reverse transform of the specified BasicWave object.
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 14:42:12
     * @param matrixFreq
     *          coefficients of 2-D frequency or Hilbert domain; internal
     *          M(i),N(j)
     * @param levelM
     *          a certain level to stop transform for over rows
     * @param levelN
     *          a certain level to stop transform for over columns
     * @return coefficients of 2-D time domain
     */
    public double[ , ] reverse( double[ , ] matrixHilb,
                                int levelM, int levelN ) {
      double[ , ] matrixTime = null;
      matrixTime = _basicTransform.reverse( matrixHilb, levelM, levelN );
      return matrixTime;
    } // reverse

    /**
     * Performs the 3-D forward transform of the specified BasicWave object.
     *
     * @date 10.07.2010 18:15:22
     * @author Christian (graetz23@gmail.com)
     * @param matrixTime
     *          coefficients of 2-D time domain; internal M(i),N(j),O(k)
     * @return coefficients of 2-D frequency or Hilbert domain
     */
    public double[ ,, ] forward( double[ ,, ] spaceTime ) {
      double[ ,, ] spaceHilb = null;
      spaceHilb = _basicTransform.forward( spaceTime );
      return spaceHilb;
    } // forward

    /**
     * Performs the 3-D reverse transform of the specified BasicWave object.
     *
     * @date 10.07.2010 18:15:33
     * @author Christian (graetz23@gmail.com)
     * @param matrixFreq
     *          coefficients of 2-D frequency or Hilbert domain; internal
     *          M(i),N(j),O(k)
     * @return coefficients of 2-D time domain
     */
    public double[ ,, ] reverse( double[ ,, ] spaceHilb ) {
      double[ ,, ] spaceTime = null;
      spaceTime = _basicTransform.reverse( spaceHilb );
      return spaceTime;
    } // reverse

    /**
     * Performs the 3-D forward transform of the specified BasicWave object.
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 14:45:46
     * @param spaceTime
     *          coefficients of 2-D time domain; internal M(i),N(j),O(k)
     * @param levelP
     *          a certain level to stop transform for over rows
     * @param levelQ
     *          a certain level to stop transform for over columns
     * @param levelR
     *          a certain level to stop transform for over height
     * @return coefficients of 2-D frequency or Hilbert domain
     */
    public double[ ,, ] forward( double[ ,, ] spaceTime,
                                 int levelP, int levelQ, int levelR ) {
      double[ ,, ] spaceHilb = null;
      spaceHilb = _basicTransform.forward( spaceTime, levelP, levelQ, levelR );
      return spaceHilb;
    } // forward

    /**
     * Performs the 3-D reverse transform of the specified BasicWave object.
     *
     * @author Christian (graetz23@gmail.com)
     * @date 22.03.2015 14:46:09
     * @param spaceHilb
     *          coefficients of 2-D frequency or Hilbert domain; internal
     *          M(i),N(j),O(k)
     * @param levelP
     *          a certain level to start transform from over rows
     * @param levelQ
     *          a certain level to stop transform for over columns
     * @param levelR
     *          a certain level to start transform from over height
     * @return coefficients of 2-D time domain
     */
    public double[ ,, ] reverse( double[ ,, ] spaceHilb,
                                 int levelP, int levelQ, int levelR ) {
      double[ ,, ] spaceTime = null;
      spaceTime = _basicTransform.reverse( spaceHilb, levelP, levelQ, levelR );
      return spaceTime;
    } // reverse

  } // class

} // namespace
