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
  /// Basic class for a wavelet keeping coefficients of the wavelet function,
  /// the scaling function, the base wavelength, the forward transform method,
  /// and the reverse transform method.
  /// </summary>
  ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:54:48</remarks>
  public abstract class Wavelet {

    ///<summary>Identifier of the wavelet object.</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:54:48</remarks>
    protected String _type;

    ///<summary>Returns type of the current Wavelet object.</summary>
    ///<remarks>Christian (graetz23@gmail.com) 17.08.2014 11:02:31</remarks>
    ///<returns>Type as string of current Wavelet object.</returns>
    public String TYPE { get{ return _type; } } // method

    ///<summary>
    /// The wavelength of the base (mother wavelet) and its scaling function.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:54:48</remarks>
    protected int _motherWavelength;

    ///<summary>
    /// Returns the wavelength of the mother wavelet or scaling function.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 15.02.2014 22:06:12</remarks>
    ///<returns>Zhe minimal wavelength for the mother wavelet.</returns>
    public int MOTHERWAVELENGTH { get{ return _motherWavelength; } } // method

    ///<summary>
    /// The minimal wavelength for any signal to be transformed.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:54:48</remarks>
    protected int _transformWavelength;

    ///<summary>
    /// Returns the minimal necessary wavelength for a signal that can be
    /// transformed by this wavelet.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 15.02.2014 22:08:43</remarks>
    ///<returns>
    /// The minimal wavelength of the input signal that can be transformed by
    /// this wavelet.
    ///</returns>
    public int TRANSFORMWAVELENGTH {
      get { return _transformWavelength; }
    } // method

    ///<summary>
    /// The coefficients of the mother scaling (low pass filter) for
    /// decomposition.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 07:23:42</remarks>
    protected double[ ] _scalingDeCom = null;

    ///<summary>
    /// Returns a copy of the scaling (low pass filter) coefficients of
    /// decomposition.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 15.02.2010 22:11:42</remarks>
    ///<returns>
    /// array of length of the mother wavelet wavelength keeping the
    /// decomposition low pass filter coefficients
    ///</returns>
    public double[ ] SCALING_DECOMPOSITION {
      get {
        double [ ] arr = new double[ MOTHERWAVELENGTH ];
        for( int i = 0; i < MOTHERWAVELENGTH; i++ ) {
          arr[ i ] = _scalingDeCom[ i ];
        } // loop
        return arr;
      } // method
    } // method

    ///<summary>
    /// The coefficients of the mother wavelet (high pass filter) for
    /// decomposition.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 07:23:42</remarks>
    protected double[ ] _waveletDeCom = null;

    ///<summary>
    /// Returns a copy of the wavelet (high pass filter) coefficients of
    /// decomposition.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 15.02.2014 22:11:25</remarks>
    ///<returns>
    /// array of length of the mother wavelet wavelength keeping the
    /// decomposition high pass filter coefficients
    ///</returns>
    public double[ ] WAVELET_DECOMPOSITION {
      get {
        double [ ] arr = new double[ MOTHERWAVELENGTH ];
        for( int i = 0; i < MOTHERWAVELENGTH; i++ ) {
          arr[ i ] = _waveletDeCom[ i ];
        } // loop
        return arr;
      }  // method
    } // method

    ///<summary>
    /// The coefficients of the mother scaling (low pass filter) for
    /// reconstruction.
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 07:23:42</remarks>
    protected double[ ] _scalingReCon = null;

    ///<summary>
    /// Returns a copy of the scaling (low pass filter) coefficients of
    /// reconstruction.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 16.02.2014 10:35:11</remarks>
    ///<returns>
    /// array of length of the mother wavelet wavelength keeping the
    /// reconstruction low pass filter coefficients
    ///</returns>
    public double[ ] SCALING_RECONSTRUCTION {
      get {
        double [ ] arr = new double[ MOTHERWAVELENGTH ];
        for( int i = 0; i < MOTHERWAVELENGTH; i++ ) {
          arr[ i ] = _scalingReCon[ i ];
        } // loop
        return arr;
      } // method
    } // method

     ///<summary>
     /// The coefficients of the mother wavelet (high pass filter) for
     /// reconstruction.
     ///</summary>
     ///<remarks>Christian (graetz23@gmail.com) 22.03.2015 07:23:42</remarks>
    protected double[ ] _waveletReCon = null;

    ///<summary>
    /// Returns a copy of the wavelet (high pass filter) coefficients of
    /// reconstruction.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 16.02.2014 10:35:09</remarks>
    ///<returns>
    /// array of length of the mother wavelet wavelength keeping the
    /// reconstruction high pass filter coefficients
    ///</returns>
    public double[ ] WAVELET_RECONSTRUCTION {
      get {
        double [ ] arr = new double[ MOTHERWAVELENGTH ];
        for( int i = 0; i < MOTHERWAVELENGTH; i++ ) {
          arr[ i ] = _waveletReCon[ i ];
        } // loop
        return arr;
      } // method
    } // method

    ///<summary>
    /// Constructor; predefine members to default values or null!
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 15.02.2014 22:16:27</remarks>
    public Wavelet( String type,
                    int motherWavelength, int transformWavelength ) {
      _type = type;
      _motherWavelength = motherWavelength; // MOTHERWAVELENGTH
      _transformWavelength = transformWavelength; // TRANSFORMWAVELENGTH
      // allcoate mempry here, just to get sure and very comfortable ..
      _scalingDeCom = new double[ MOTHERWAVELENGTH ];
      _waveletDeCom = new double[ MOTHERWAVELENGTH ];
      _scalingReCon = new double[ MOTHERWAVELENGTH ];
      _waveletReCon = new double[ MOTHERWAVELENGTH ];
    } // method

    ///<summary>
    /// The method builds form the scaling (low pass) coefficients for
    /// decomposition of a filter, the matching coefficients for the wavelet
    /// (high pass) for decomposition, for the scaling (low pass) for
    /// reconstruction, and for the wavelet (Wavelethigh pass) of
    /// reconstruction. This method should be called in the constructor of an
    /// orthonormal filter directly after defining the orthonormal coefficients
    /// of the scaling (low pass) for decomposition!
    ///</summary>
    ///<remarks>Christian (graetz23@gmail.com) 16.02.2014 13:19:27</remarks>
    protected void _buildBaseSystem( ) {
      // building wavelet as orthogonal (orthonormal) space from
      // scaling coefficients (low pass filter). Have a look into
      // Alfred Haar's wavelet or the Daubechies Wavelet with 2
      // vanishing moments for understanding what is done here. ;-)
      for( int i = 0; i < MOTHERWAVELENGTH; i++ )
        if( i % 2 == 0 )
          _waveletDeCom[ i ] = _scalingDeCom[ ( MOTHERWAVELENGTH - 1 ) - i ];
        else
          _waveletDeCom[ i ] = -_scalingDeCom[ ( MOTHERWAVELENGTH - 1 ) - i ];
      // Copy to reconstruction filters due to orthogonality (orthonormality)!
      for( int i = 0; i < MOTHERWAVELENGTH; i++ ) {
        _scalingReCon[ i ] = _scalingDeCom[ i ];
        _waveletReCon[ i ] = _waveletDeCom[ i ];
      } // i
    } // method

    ///<summary>
    /// Performs the forward transform for the given array from time domain to
    /// Hilbert domain and returns a new array of the same size keeping
    /// coefficients of Hilbert domain and should be of length 2 to the power
    /// of p; length = 2^p, where p is a positive integer.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:18:02</remarks>
    ///<returns>
    /// Coefficients representing by frequency or Hilbert domain.
    /// </returns>
    virtual public double[ ] forward( double[ ] arrTime, int length ) {
      double[ ] arrHilb = new double[ length ];
      int h = length >> 1; // .. -> 8 -> 4 -> 2 .. shrinks in each step by half wavelength
      for( int i = 0; i < h; i++ ) {
        arrHilb[ i ] = arrHilb[ i + h ] = 0.0; // set to zero before sum up
        for( int j = 0; j < MOTHERWAVELENGTH; j++ ) {
          int k = ( i << 1 ) + j; // k = ( i * 2 ) + j;
          while( k >= length ) {
            k -= length; // circulate over arrays if scaling and wavelet are are larger
          } // circulate
          arrHilb[ i ] += arrTime[ k ] * _scalingDeCom[ j ]; // low pass filter for the energy (approximation)
          arrHilb[ i + h ] += arrTime[ k ] * _waveletDeCom[ j ]; // high pass filter for the details
        } // Sorting each step in patterns of: { scaling coefficients | wavelet coefficients }
      } // h = 2^(p-1) | p = { 1, 2, .., N } .. shrinks in each step by half wavelength
      return arrHilb;
    } // method

    ///<summary>
    /// Performs the reverse transform for the given array from Hilbert domain
    /// to time domain and returns a new array of the same size keeping
    /// coefficients of time domain and should be of length 2 to the power of
    /// p; length = 2^p, where p is a positive integer.
    /// </summary>
    ///<remarks>Christian (graetz23@gmail.com) 10.02.2010 08:19:24</remarks>
    ///<returns>
    /// Coefficients representing by time domain.
    /// </returns>
    virtual public double[ ] reverse( double[ ] arrHilb, int length ) {
      double[ ] arrTime = new double[ length ];
      for( int i = 0; i < length; i++ ) {
        arrTime[ i ] = 0.0; // set to zero before sum up
      } // rows
      int h = length >> 1; // .. -> 8 -> 4 -> 2 .. shrinks in each step by half wavelength
      for( int i = 0; i < h; i++ ) {
        for( int j = 0; j < MOTHERWAVELENGTH; j++ ) {
          int k = ( i << 1 ) + j; // k = ( i * 2 ) + j;
          while( k >= length ) {
            k -= length; // circulate over arrays if scaling and wavelet are larger
          } // circulate
          // adding up energy from low pass (approximation) and details from high pass filter
          arrTime[ k ] +=
              ( arrHilb[ i ] * _scalingReCon[ j ] ) +
              ( arrHilb[ i + h ] * _waveletReCon[ j ] ); // looks better with brackets
        } // Reconstruction from patterns of: { scaling coefficients | wavelet coefficients }
      } // h = 2^(p-1) | p = { 1, 2, .., N } .. shrink in each step by half wavelength
      return arrTime;
    } // method

  } // Wavelet

} // namespace
