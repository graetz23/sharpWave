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
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
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

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym3/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet3 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet3( ) : base( "Symlet 3", 6, 2) {
      _scalingDeCom[ 0 ] = 0.035226291882100656;
      _scalingDeCom[ 1 ] = -0.08544127388224149;
      _scalingDeCom[ 2 ] = -0.13501102001039084;
      _scalingDeCom[ 3 ] = 0.4598775021193313;
      _scalingDeCom[ 4 ] = 0.8068915093133388;
      _scalingDeCom[ 5 ] = 0.3326705529509569;
      _buildBaseSystem( );
    } // Symlet3

  } // Symlet3

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym4/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet4 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet4( ) : base( "Symlet 4", 8, 2) {
      _scalingDeCom[ 0 ] = -0.07576571478927333;
      _scalingDeCom[ 1 ] = -0.02963552764599851;
      _scalingDeCom[ 2 ] = 0.49761866763201545;
      _scalingDeCom[ 3 ] = 0.8037387518059161;
      _scalingDeCom[ 4 ] = 0.29785779560527736;
      _scalingDeCom[ 5 ] = -0.09921954357684722;
      _scalingDeCom[ 6 ] = -0.012603967262037833;
      _scalingDeCom[ 7 ] = 0.0322231006040427;
      _buildBaseSystem( );
    } // Symlet4

  } // Symlet4

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym5/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet5 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet5( ) : base( "Symlet 5", 10, 2) {
      _scalingDeCom[ 0 ] = 0.027333068345077982;
      _scalingDeCom[ 1 ] = 0.029519490925774643;
      _scalingDeCom[ 2 ] = -0.039134249302383094;
      _scalingDeCom[ 3 ] = 0.1993975339773936;
      _scalingDeCom[ 4 ] = 0.7234076904024206;
      _scalingDeCom[ 5 ] = 0.6339789634582119;
      _scalingDeCom[ 6 ] = 0.01660210576452232;
      _scalingDeCom[ 7 ] = -0.17532808990845047;
      _scalingDeCom[ 8 ] = -0.021101834024758855;
      _scalingDeCom[ 9 ] = 0.019538882735286728;
      _buildBaseSystem( );
    } // Symlet5

  } // Symlet5

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym6/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet6 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet6( ) : base( "Symlet 6", 12, 2) {
      _scalingDeCom[ 0 ] = 0.015404109327027373;
      _scalingDeCom[ 1 ] = 0.0034907120842174702;
      _scalingDeCom[ 2 ] = -0.11799011114819057;
      _scalingDeCom[ 3 ] = -0.048311742585633;
      _scalingDeCom[ 4 ] = 0.4910559419267466;
      _scalingDeCom[ 5 ] = 0.787641141030194;
      _scalingDeCom[ 6 ] = 0.3379294217276218;
      _scalingDeCom[ 7 ] = -0.07263752278646252;
      _scalingDeCom[ 8 ] = -0.021060292512300564;
      _scalingDeCom[ 9 ] = 0.04472490177066578;
      _scalingDeCom[ 10 ] = 0.0017677118642428036;
      _scalingDeCom[ 11 ] = -0.007800708325034148;
      _buildBaseSystem( );
    } // Symlet6

  } // Symlet6

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym7/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet7 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet7( ) : base( "Symlet 7", 14, 2) {
      _scalingDeCom[ 0 ] = 0.002681814568257878;
      _scalingDeCom[ 1 ] = -0.0010473848886829163;
      _scalingDeCom[ 2 ] = -0.01263630340325193;
      _scalingDeCom[ 3 ] = 0.03051551316596357;
      _scalingDeCom[ 4 ] = 0.0678926935013727;
      _scalingDeCom[ 5 ] = -0.049552834937127255;
      _scalingDeCom[ 6 ] = 0.017441255086855827;
      _scalingDeCom[ 7 ] = 0.5361019170917628;
      _scalingDeCom[ 8 ] = 0.767764317003164;
      _scalingDeCom[ 9 ] = 0.2886296317515146;
      _scalingDeCom[ 10 ] = -0.14004724044296152;
      _scalingDeCom[ 11 ] = -0.10780823770381774;
      _scalingDeCom[ 12 ] = 0.004010244871533663;
      _scalingDeCom[ 13 ] = 0.010268176708511255;
      _buildBaseSystem( );
    } // Symlet7

  } // Symlet7

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym8/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet8 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet8( ) : base( "Symlet 8", 16, 2) {
      _scalingDeCom[ 0 ] = -0.0033824159510061256;
      _scalingDeCom[ 1 ] = -0.0005421323317911481;
      _scalingDeCom[ 2 ] = 0.03169508781149298;
      _scalingDeCom[ 3 ] = 0.007607487324917605;
      _scalingDeCom[ 4 ] = -0.1432942383508097;
      _scalingDeCom[ 5 ] = -0.061273359067658524;
      _scalingDeCom[ 6 ] = 0.4813596512583722;
      _scalingDeCom[ 7 ] = 0.7771857517005235;
      _scalingDeCom[ 8 ] = 0.3644418948353314;
      _scalingDeCom[ 9 ] = -0.05194583810770904;
      _scalingDeCom[ 10 ] = -0.027219029917056003;
      _scalingDeCom[ 11 ] = 0.049137179673607506;
      _scalingDeCom[ 12 ] = 0.003808752013890615;
      _scalingDeCom[ 13 ] = -0.01495225833704823;
      _scalingDeCom[ 14 ] = -0.0003029205147213668;
      _scalingDeCom[ 15 ] = 0.0018899503327594609;
      _buildBaseSystem( );
    } // Symlet8

  } // Symlet8

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym9/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet9 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet9( ) : base( "Symlet 9", 18, 2) {
      _scalingDeCom[ 0 ] = 0.0014009155259146807;
      _scalingDeCom[ 1 ] = 0.0006197808889855868;
      _scalingDeCom[ 2 ] = -0.013271967781817119;
      _scalingDeCom[ 3 ] = -0.01152821020767923;
      _scalingDeCom[ 4 ] = 0.03022487885827568;
      _scalingDeCom[ 5 ] = 0.0005834627461258068;
      _scalingDeCom[ 6 ] = -0.05456895843083407;
      _scalingDeCom[ 7 ] = 0.238760914607303;
      _scalingDeCom[ 8 ] = 0.717897082764412;
      _scalingDeCom[ 9 ] = 0.6173384491409358;
      _scalingDeCom[ 10 ] = 0.035272488035271894;
      _scalingDeCom[ 11 ] = -0.19155083129728512;
      _scalingDeCom[ 12 ] = -0.018233770779395985;
      _scalingDeCom[ 13 ] = 0.06207778930288603;
      _scalingDeCom[ 14 ] = 0.008859267493400484;
      _scalingDeCom[ 15 ] = -0.010264064027633142;
      _scalingDeCom[ 16 ] = -0.0004731544986800831;
      _scalingDeCom[ 17 ] = 0.0010694900329086053;
      _buildBaseSystem( );
    } // Symlet9

  } // Symlet9

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym10/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet10 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet10( ) : base( "Symlet 10", 20, 2) {
      _scalingDeCom[ 0 ] = 0.0007701598091144901;
      _scalingDeCom[ 1 ] = 9.563267072289475e-05;
      _scalingDeCom[ 2 ] = -0.008641299277022422;
      _scalingDeCom[ 3 ] = -0.0014653825813050513;
      _scalingDeCom[ 4 ] = 0.0459272392310922;
      _scalingDeCom[ 5 ] = 0.011609893903711381;
      _scalingDeCom[ 6 ] = -0.15949427888491757;
      _scalingDeCom[ 7 ] = -0.07088053578324385;
      _scalingDeCom[ 8 ] = 0.47169066693843925;
      _scalingDeCom[ 9 ] = 0.7695100370211071;
      _scalingDeCom[ 10 ] = 0.38382676106708546;
      _scalingDeCom[ 11 ] = -0.03553674047381755;
      _scalingDeCom[ 12 ] = -0.0319900568824278;
      _scalingDeCom[ 13 ] = 0.04999497207737669;
      _scalingDeCom[ 14 ] = 0.005764912033581909;
      _scalingDeCom[ 15 ] = -0.02035493981231129;
      _scalingDeCom[ 16 ] = -0.0008043589320165449;
      _scalingDeCom[ 17 ] = 0.004593173585311828;
      _scalingDeCom[ 18 ] = 5.7036083618494284e-05;
      _scalingDeCom[ 19 ] = -0.0004593294210046588;
      _buildBaseSystem( );
    } // Symlet10

  } // Symlet10

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym11/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet11 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet11( ) : base( "Symlet 11", 22, 2) {
      _scalingDeCom[ 0 ] = 0.00017172195069934854;
      _scalingDeCom[ 1 ] = -3.8795655736158566e-05;
      _scalingDeCom[ 2 ] = -0.0017343662672978692;
      _scalingDeCom[ 3 ] = 0.0005883527353969915;
      _scalingDeCom[ 4 ] = 0.00651249567477145;
      _scalingDeCom[ 5 ] = -0.009857934828789794;
      _scalingDeCom[ 6 ] = -0.024080841595864003;
      _scalingDeCom[ 7 ] = 0.0370374159788594;
      _scalingDeCom[ 8 ] = 0.06997679961073414;
      _scalingDeCom[ 9 ] = -0.022832651022562687;
      _scalingDeCom[ 10 ] = 0.09719839445890947;
      _scalingDeCom[ 11 ] = 0.5720229780100871;
      _scalingDeCom[ 12 ] = 0.7303435490883957;
      _scalingDeCom[ 13 ] = 0.23768990904924897;
      _scalingDeCom[ 14 ] = -0.2046547944958006;
      _scalingDeCom[ 15 ] = -0.1446023437053156;
      _scalingDeCom[ 16 ] = 0.03526675956446655;
      _scalingDeCom[ 17 ] = 0.04300019068155228;
      _scalingDeCom[ 18 ] = -0.0020034719001093887;
      _scalingDeCom[ 19 ] = -0.006389603666454892;
      _scalingDeCom[ 20 ] = 0.00011053509764272153;
      _scalingDeCom[ 21 ] = 0.0004892636102619239;
      _buildBaseSystem( );
    } // Symlet11

  } // Symlet11

  ///<summary>
  /// Already orthonormal coefficients taken from Filip Wasilewski's webpage
  /// http://wavelets.pybytes.com/wavelet/sym12/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 17.08.2014 14:06:57
  ///</remarks>
  public class Symlet12 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Symlet wavelet,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), sets
    // the scaling coefficients, and the orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 13:40:30
    ///</remarks>
    public Symlet12( ) : base( "Symlet 12", 24, 2) {
      _scalingDeCom[ 0 ] = 0.00011196719424656033;
      _scalingDeCom[ 1 ] = -1.1353928041541452e-05;
      _scalingDeCom[ 2 ] = -0.0013497557555715387;
      _scalingDeCom[ 3 ] = 0.00018021409008538188;
      _scalingDeCom[ 4 ] = 0.007414965517654251;
      _scalingDeCom[ 5 ] = -0.0014089092443297553;
      _scalingDeCom[ 6 ] = -0.024220722675013445;
      _scalingDeCom[ 7 ] = 0.0075537806116804775;
      _scalingDeCom[ 8 ] = 0.04917931829966084;
      _scalingDeCom[ 9 ] = -0.03584883073695439;
      _scalingDeCom[ 10 ] = -0.022162306170337816;
      _scalingDeCom[ 11 ] = 0.39888597239022;
      _scalingDeCom[ 12 ] = 0.7634790977836572;
      _scalingDeCom[ 13 ] = 0.46274103121927235;
      _scalingDeCom[ 14 ] = -0.07833262231634322;
      _scalingDeCom[ 15 ] = -0.17037069723886492;
      _scalingDeCom[ 16 ] = 0.01530174062247884;
      _scalingDeCom[ 17 ] = 0.05780417944550566;
      _scalingDeCom[ 18 ] = -0.0026043910313322326;
      _scalingDeCom[ 19 ] = -0.014589836449234145;
      _scalingDeCom[ 20 ] = 0.00030764779631059454;
      _scalingDeCom[ 21 ] = 0.002350297614183465;
      _scalingDeCom[ 22 ] = -1.8158078862617515e-05;
      _scalingDeCom[ 23 ] = -0.0001790665869750869;
      _buildBaseSystem( );
    } // Symlet12

  } // Symlet12

} // namespace
