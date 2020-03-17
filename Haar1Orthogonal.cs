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

  ///<summary>
  /// Alfred Haar's orthogonal wavelet transform.
  ///
  /// Remarks on mathematics (perpendicular, orthogonal, and orthonormal):
  ///
  /// "Orthogonal" is used for (base) vectors which are "perpendicular" but of
  /// any length.
  /// "Orthonormal" is used for (base) vectors which are "perpendicular" and of
  /// a "unit" length of one.
  ///
  /// "Orthogonal" system; ASCII art does not display the angles in 90 deg
  ///  or int 45 deg correctly:
  ///
  ///    ^ y
  ///    |
  ///  1 +      .  scaling function
  ///    |    /    {1,1}  \
  ///    |  /             | length = 1.4142135623730951
  ///    |/               /        = sqrt( (1)^2 + (1)^2 )
  ///  --o------+-> x
  ///  0 |\     1         \
  ///    |  \             | length = 1.4142135623730951
  ///    |    \           /        = sqrt( (1)^2 + (-1)^2 )
  /// -1 +      .  wavelet function
  ///    |         {1,-1}
  ///
  /// One can see that by each step of the algorithm the input coefficient's
  /// "energy" (energy := ||.||_2 euclidean norm) rises, while ever input value
  /// is multiplied by 1.414213 (sqrt(2)). This rise of the energy has to be
  /// corrected by reducing the added "energy" or "energ delta by the reverse
  /// transform method. For this example the multiplying factor is 1/2.
  ///
  /// Therefore, the "energy correction" factor is added by a private member
  /// variable (_energyCorrectionFactor) and the reverse transform is
  /// overwritten; see forward reverse methods of this class.
  ///
  /// For more details abour the introduced euclidean norm; see wikipedia:
  /// http:///en.wikipedia.org/wiki/Euclidean_norm
  ///
  /// The main disadvantage using "orthogonal" wavelets are the generated
  /// wavelet sub spaces having different levels of "energy". Those can not be
  /// combined anymore easily. For each level a different energy correction
  /// factor would get necessary depending on the target wavelet space.
  /// If an "orthonormal" wavelet is taken, the ||.||_2 norm does not change
  /// any energy at any level of the generated wavelet sub spaces. This allows
  /// for combining wavelet sub spaces of different levels easily and opens
  /// the application for enegy based algorithms, e.g. like iterative solvers
  /// used for wavelet compressed system of linear equations.
  ///
  /// Some other common used orthogonal Haar coefficients are:
  ///
  /// Reducing energy in wach wavelet sub space:
  /// _scalingDeCom[ 0 ] = .5; /// s0
  /// _scalingDeCom[ 1 ] = .5; ///  s1
  ///
  /// _waveletDeCom[ 0 ] = .5; /// w0 = s1
  /// _waveletDeCom[ 1 ] = -.5; /// w1 = -s0
  ///
  /// _scalingReCon[ 0 ] = .5; /// s0
  /// _scalingReCon[ 1 ] = .5; ///  s1
  ///
  /// _waveletReCon[ 0 ] = .5; /// w0 = s1
  /// _waveletReCon[ 1 ] = -.5; /// w1 = -s0
  ///
  /// The ||.||_2 norm will shrink the energy compared to the input signal's
  /// norm, due to length sqrt( .5 * .5 + .5 * .5 ) = sqrt( .5 ) = .7071.
  /// Hence, the correction factor in the reverse method is exchanged from:
  /// 1/2 = .5 to the value of 2.!
  ///
  /// For example a 2-D input matrix is defined in time domain as:
  /// 1 1 1 1
  /// 1 1 1 1
  /// 1 1 1 1
  /// 1 1 1 1
  ///
  /// The orthogonal version of the Haar wavelet will result in some beautiful
  /// hilbert domain using Fast Wavelet or Wavelet Packet Transform:
  /// 16 0 0 0
  ///  0 0 0 0
  ///  0 0 0 0
  ///  0 0 0 0
  /// One can see that all energy is just summed up which looks fine but gets
  /// complicated to correlate, if an application has the need to deal in
  /// different wavelet sub spaces, Hibert sub domains, respectively.
  ///
  /// For reconstruction the energy correction by 1/2 gets necessary and
  /// results (in case of no rounding errors; e.g. 0.999999999999) in:
  /// 1 1 1 1
  /// 1 1 1 1
  /// 1 1 1 1
  /// 1 1 1 1
  ///
  /// Such orthogonal wavelets can be used for any application always dealing
  /// with all levels of the sub spaces or for checking wheater some changed
  /// or new transform algorithm is working properly.
  ///
  /// An alternative is to use coefficients keeping the correction implicitely:
  ///
  /// _scalingDeCom[ 0 ] = 1.; /// s_d0
  /// _scalingDeCom[ 1 ] = 1.; ///  s_d1
  ///
  /// _waveletDeCom[ 0 ] = 1.; /// w_d0 = s_d1
  /// _waveletDeCom[ 1 ] = -1.; /// w_d1 = -s_d0
  ///
  /// _scalingReCon[ 0 ] = .5; /// s_r0
  /// _scalingReCon[ 1 ] = .5; ///  s_r1
  ///
  /// _waveletReCon[ 0 ] = .5; /// w_r0 = s_r1
  /// _waveletReCon[ 1 ] = -.5; /// w_r1 = -s_r0
  ///
  /// or
  ///
  /// _scalingDeCom[ 0 ] = .5; /// s_d0
  /// _scalingDeCom[ 1 ] = .5; ///  s_d1
  ///
  /// _waveletDeCom[ 0 ] = .5; /// w_d0 = s_d1
  /// _waveletDeCom[ 1 ] = -.5; /// w_d1 = -s_d0
  ///
  /// _scalingReCon[ 0 ] = 2.; /// s_r0
  /// _scalingReCon[ 1 ] = 2.; ///  s_r1
  ///
  /// _waveletReCon[ 0 ] = 2.; /// w_r0 = s_r1
  /// _waveletReCon[ 1 ] = -2.; /// w_r1 = -s_r0
  ///
  /// .. have fun ~8>
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 03.06.2010 09:47:24
  ///</remarks>
  public class Haar1Orthogonal : Wavelet {

    ///<summary>
    /// Energy correction factor of the (overwritten) reverse transform.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 03.06.2010 09:47:24
    ///</remarks>
    private static double _energyCorrectionFactor = .5;

    ///<summary>
    /// Constructor setting up the orthogonal Haar scaling coefficients and
    /// matching wavelet coefficients. However, the reverse method has to be
    /// obverloaded, due to having to change the energy during reconstruction.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 03.06.2010 09:47:24
    ///</remarks>
    public Haar1Orthogonal( ) :base("Haar 1 orthogonal", 2, 2) {
      // Orthogonal wavelet coefficients; NOT orthonormal, missing sqrt(2.)
      _scalingDeCom = new double[ _motherWavelength ];
      _scalingDeCom[ 0 ] = 1.0; // w0
      _scalingDeCom[ 1 ] = 1.0; //  w1
      // Rule for constructing an orthogonal vector in R^2 -- scales
      _waveletDeCom = new double[ _motherWavelength ];
      _waveletDeCom[ 0 ] = _scalingDeCom[ 1 ]; // w1
      _waveletDeCom[ 1 ] = -_scalingDeCom[ 0 ]; // -w0
      // Copy to reconstruction filters due to orthogonality
      _scalingReCon = new double[ _motherWavelength ];
      _waveletReCon = new double[ _motherWavelength ];
      for( int i = 0; i < _motherWavelength; i++ ) {
        _scalingReCon[ i ] = _scalingDeCom[ i ];
        _waveletReCon[ i ] = _waveletDeCom[ i ];
      } // i
    } // Haar1

    ///<summary>
    /// The reverse wavelet transform using the Alfred Haar's wavelet. The arrHilb
    /// array keeping coefficients of Hilbert domain should be of length 2 to the
    /// power of p -- length = 2^p where p is a positive integer. But in case of an
    /// only orthogonal Haar wavelet the reverse transform has to have a factor of
    /// 0.5 to reduce the up sampled "energy" in Hilbert space.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 21:17:22
    ///</remarks>
    override public double[ ] reverse( double[ ] arrHilb, int arrHilbLength ) {
      double[ ] arrTime = new double[ arrHilbLength ];
      int length = arrTime.Length;
      for( int i = 0; i < length; i++ ) {
        arrTime[ i ] = 0.0;
      } // rows
      int h = length >> 1; // .. -> 8 -> 4 -> 2 ..
      for( int i = 0; i < h; i++ ) {
        for( int j = 0; j < _motherWavelength; j++ ) {
          int k = ( i * 2 ) + j; // int k = ( i << 1 ) + j;
          while( k >= length ) {
            k -= length; // circulate arrays if scaling and wavelet are larger
          } // circuate
          // adding up energy from scaling coefficients, the low pass
          // (approximation) filter, and wavelet coefficients, the high pass
          // filter (details). However, the raised energy has to be reduced by
          // half for each step because of vectorial length of each base vector
          // of the orthogonal system is of sqrt( 2. ).
          arrTime[ k ] +=
              _energyCorrectionFactor * // reduction of added energy by 1/2 ..
              ( ( arrHilb[ i ] * _scalingReCon[ j ] ) +
                ( arrHilb[ i + h ] * _waveletReCon[ j ] ) );
        } // reconstruction from { scaling coefficients | wavelet coefficients }
      } // h = 2^(p-1) | p = { 1, 2, .., N } .. shrink by half wavelength
      return arrTime;
    } // reverse

  } // Haar1Orthogonal

} // namespace
