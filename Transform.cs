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

  /// <summary>
  /// Basic class for transforms.
  /// </summary>
  public class Transform
  {

    /// <summary>
    /// Transform object of base class type; BasicTransfrom.
    /// </summary>
    protected Algorithm _algorithm;

    ///<summary>
    /// Constructor; needs some object like DiscreteFourierTransform,
    /// FastBasicTransform, WaveletPacketTransfom, ...
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 19.05.2009 09:50:24</remarks>
    public Transform( Algorithm basicTransform )
    {
      if(basicTransform == null ) {
        throw new Types.Types_NotExistent( "Transform - " +
          "Given transform object is null!" );
      } // if
      if(!(basicTransform is Algorithm)) {
        throw new Types.Types_NotValid( "Transform - " +
          "Given transform object is not correct type!" );
      } // if
      _algorithm = basicTransform;
    } // method

    ///<summary>
    /// Performs the forward transform by the specified BasicTransform object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 09:41:01</remarks>
    ///<returns>Coefficients of frequency or Hilbert domain</returns>
    public double[ ] forward( double[ ] arrTime ) {
      double[ ] arrHilb = null;
      arrHilb = _algorithm.forward( arrTime );
      return arrHilb;
    } // forward

    ///<summary>
    /// Performs the reverse transform by the specified BasicTransform object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 09:42:18</remarks>
    ///<returns>Coefficients of frequency or Hilbert domain</returns>
    public double[ ] reverse( double[ ] arrHilb ) {
      double[ ] arrTime = null;
      arrTime = _algorithm.reverse( arrHilb );
      return arrTime;
    } // reverse

    ///<summary>
    /// Performs a forward transform to a certain level of frequency or Hilbert
    /// space by the specified BasicTransform object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 11:53:05</remarks>
    ///<returns>
    /// Coefficients of frequency or Hilbert domain of certain level.
    ///</returns>
    public double[ ] forward( double[ ] arrTime, int level ) {
      double[ ] arrHilb = null;
      arrHilb = _algorithm.forward( arrTime, level );
      return arrHilb;
    } // forward

    ///<summary>
    /// Performs a reverse transform for a frequency or Hilbert space of a
    /// certain level by the specified BasicTransform object; the level has to
    /// match the supported coefficients in the array!.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 11:54:59</remarks>
    ///<returns>
    /// Reconstructed time domain for a certain level of frequencyor Hilbert
    /// space.
    ///</returns>
    public double[ ] reverse( double[ ] arrHilb, int level ) {
      double[ ] arrTime = null;
      arrTime = _algorithm.reverse( arrHilb, level );
      return arrTime;
    } // reverse

    ///<summary>
    /// Performs the 2-D forward transform by the specified BasicTransform
    /// object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 10:58:54</remarks>
    ///<returns>
    /// Coefficients of 2-D frequency or Hilbert domain.
    ///</returns>
    public double[ , ] forward( double[ , ] matrixTime ) {
      double[ , ] matrixHilb = null;
      matrixHilb = _algorithm.forward( matrixTime );
      return matrixHilb;
    } // forward

    ///<summary>
    /// Performs the 2-D reverse transform by the specified BasicTransform
    /// object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 10:59:32</remarks>
    ///<returns>
    /// Coefficients of reconstructed 2-D time domain.
    ///</returns>
    public double[ , ] reverse( double[ , ] matrixHilb ) {
      double[ , ] matrixTime = null;
      matrixTime = _algorithm.reverse( matrixHilb );
      return matrixTime;
    } // reverse

    ///<summary>
    /// Performs the 2-D forward transform to a certain level by the specified
    /// BasicTransform object .
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 14:40:54</remarks>
    ///<returns>
    /// Coefficients of 2-D frequency or Hilbert domain of certain level.
    ///</returns>
    public double[ , ] forward( double[ , ] matrixTime,
                                int levelM, int levelN ) {
      double[ , ] matrixHilb = null;
      matrixHilb = _algorithm.forward( matrixTime, levelM, levelN );
      return matrixHilb;
    } // forward

    ///<summary>
    /// Performs the 2-D reverse transform from a certain level by the specified
    /// BasicTransform object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 14:42:12</remarks>
    ///<returns>
    /// Coefficients of reconstructed 2-D time domain.
    ///</returns>
    public double[ , ] reverse( double[ , ] matrixHilb,
                                int levelM, int levelN ) {
      double[ , ] matrixTime = null;
      matrixTime = _algorithm.reverse( matrixHilb, levelM, levelN );
      return matrixTime;
    } // reverse

    ///<summary>
    /// Performs the 3-D forward transform by the specified BasicTransform
    /// object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.07.2010 18:15:22</remarks>
    ///<returns>
    /// Coefficients of 3-D frequency or Hilbert domain.
    ///</returns>
    public double[ ,, ] forward( double[ ,, ] spaceTime ) {
      double[ ,, ] spaceHilb = null;
      spaceHilb = _algorithm.forward( spaceTime );
      return spaceHilb;
    } // forward

    ///<summary>
    /// Performs the 3-D reverse transform by the specified BasicTransform
    /// object.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.07.2010 18:15:33</remarks>
    ///<returns>
    /// Coefficients of reconstructed 3-D time domain.
    ///</returns>
    public double[ ,, ] reverse( double[ ,, ] spaceHilb ) {
      double[ ,, ] spaceTime = null;
      spaceTime = _algorithm.reverse( spaceHilb );
      return spaceTime;
    } // reverse

    ///<summary>
    /// Performs the 3-D forward transform to a certain level by the specified
    /// BasicTransform object.
    /// levelP - certain level to stop transform for over rows
    /// levelQ - certain level to stop transform for over columns
    /// levelR - certain level to stop transform for over height
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 14:45:46</remarks>
    ///<returns>
    /// Coefficients of 3-D frequency or Hilbert domain of a certain level.
    ///</returns>
    public double[ ,, ] forward( double[ ,, ] spaceTime,
                                 int levelP, int levelQ, int levelR ) {
      double[ ,, ] spaceHilb = null;
      spaceHilb = _algorithm.forward( spaceTime, levelP, levelQ, levelR );
      return spaceHilb;
    } // forward

    ///<summary>
    /// Performs the 3-D reverse transform to a certain level by the specified
    /// BasicTransform object.
    /// levelP - certain level to start transform from over rows
    /// levelQ - certain level to stop transform for over columns
    /// levelR - certain level to start transform from over height
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 14:46:09</remarks>
    ///<returns>
    /// Coefficients of reconstructed 3-D time domain.
    ///</returns>
    public double[ ,, ] reverse( double[ ,, ] spaceHilb,
                                 int levelP, int levelQ, int levelR ) {
      double[ ,, ] spaceTime = null;
      spaceTime = _algorithm.reverse( spaceHilb, levelP, levelQ, levelR );
      return spaceTime;
    } // reverse

  } // class

} // namespace
