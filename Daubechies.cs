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

  ///<summary>
  /// Ingrid Daubechies' wavelet of four coefficients in orthonormal version.
  /// The computation is analytical and has - nearly - no rounding error.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 10.02.2010 15:42:45
  ///</remarks>
  public class Daubechies2 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 10.02.2010 15:42:45
    ///</remarks>
    public Daubechies2( ) : base( "Daubechies 2", 4, 2 ) {
      double sqrt02 = Math.Sqrt( 2.0 ); // 1.4142135623730951
      double sqrt03 = Math.Sqrt( 3.0 ); // 1.7320508075688772
      _scalingDeCom[ 0 ] = ( ( 1.0 + sqrt03 ) / 4.0 ) / sqrt02; // s0
      _scalingDeCom[ 1 ] = ( ( 3.0 + sqrt03 ) / 4.0 ) / sqrt02; // s1
      _scalingDeCom[ 2 ] = ( ( 3.0 - sqrt03 ) / 4.0 ) / sqrt02; // s2
      _scalingDeCom[ 3 ] = ( ( 1.0 - sqrt03 ) / 4.0 ) / sqrt02; // s3
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies2

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of six coefficients in orthonormal version.
  /// The computation is analytical and has - nearly - no rounding error.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:23:20
  ///</remarks>
  public class Daubechies3 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 25.03.2010 14:03:20
    ///</remarks>
    public Daubechies3( ) : base( "Daubechies 3", 6, 2 ) {
      double sqrt02 = Math.Sqrt( 2.0 ) ; // 1.4142135623730951
      double sqrt10 = Math.Sqrt( 10.0 );
      double constA = Math.Sqrt( 5.0 + 2.0 * sqrt10 );
      _scalingDeCom[ 0 ] = ( 1.0 +  1.0 * sqrt10 + 1.0 * constA ) / 16.0; // h0 = 0.47046720778416373
      _scalingDeCom[ 1 ] = ( 5.0 +  1.0 * sqrt10 + 3.0 * constA ) / 16.0; // h1 = 1.1411169158314438
      _scalingDeCom[ 2 ] = ( 10.0 - 2.0 * sqrt10 + 2.0 * constA ) / 16.0; // h2 = 0.6503650005262325
      _scalingDeCom[ 3 ] = ( 10.0 - 2.0 * sqrt10 - 2.0 * constA ) / 16.0; // h3 = -0.1909344155683274
      _scalingDeCom[ 4 ] = ( 5.0 +  1.0 * sqrt10 - 3.0 * constA ) / 16.0; // h4 = -0.1208322083103962
      _scalingDeCom[ 5 ] = ( 1.0 +  1.0 * sqrt10 - 1.0 * constA ) / 16.0; // h5 = 0.049817499736883764
      for( int i = 0; i < _motherWavelength; i++ )
        _scalingDeCom[ i ] /= sqrt02;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies3

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of eight coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db4/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies4 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies4( ) : base( "Daubechies 4", 8, 2 ) {
      _scalingDeCom[ 0 ] = -0.010597401784997278;
      _scalingDeCom[ 1 ] = 0.032883011666982945;
      _scalingDeCom[ 2 ] = 0.030841381835986965;
      _scalingDeCom[ 3 ] = -0.18703481171888114;
      _scalingDeCom[ 4 ] = -0.02798376941698385;
      _scalingDeCom[ 5 ] = 0.6308807679295904;
      _scalingDeCom[ 6 ] = 0.7148465705525415;
      _scalingDeCom[ 7 ] = 0.23037781330885523;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies4

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of ten coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db5/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies5 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies5( ) : base( "Daubechies 5", 10, 2 ) {
      _scalingDeCom[ 0 ] = 0.003335725285001549;
      _scalingDeCom[ 1 ] = -0.012580751999015526;
      _scalingDeCom[ 2 ] = -0.006241490213011705;
      _scalingDeCom[ 3 ] = 0.07757149384006515;
      _scalingDeCom[ 4 ] = -0.03224486958502952;
      _scalingDeCom[ 5 ] = -0.24229488706619015;
      _scalingDeCom[ 6 ] = 0.13842814590110342;
      _scalingDeCom[ 7 ] = 0.7243085284385744;
      _scalingDeCom[ 8 ] = 0.6038292697974729;
      _scalingDeCom[ 9 ] = 0.160102397974125;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies5

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of twelve coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db6/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies6 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies6( ) : base( "Daubechies 6", 12, 2 ) {
      _scalingDeCom[ 0 ] = -0.00107730108499558;
      _scalingDeCom[ 1 ] = 0.004777257511010651;
      _scalingDeCom[ 2 ] = 0.0005538422009938016;
      _scalingDeCom[ 3 ] = -0.031582039318031156;
      _scalingDeCom[ 4 ] = 0.02752286553001629;
      _scalingDeCom[ 5 ] = 0.09750160558707936;
      _scalingDeCom[ 6 ] = -0.12976686756709563;
      _scalingDeCom[ 7 ] = -0.22626469396516913;
      _scalingDeCom[ 8 ] = 0.3152503517092432;
      _scalingDeCom[ 9 ] = 0.7511339080215775;
      _scalingDeCom[ 10 ] = 0.4946238903983854;
      _scalingDeCom[ 11 ] = 0.11154074335008017;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies6

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of fourteen coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db7/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies7 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies7( ) : base( "Daubechies 7", 14, 2 ) {
      _scalingDeCom[ 0 ] = 0.0003537138000010399;
      _scalingDeCom[ 1 ] = -0.0018016407039998328;
      _scalingDeCom[ 2 ] = 0.00042957797300470274;
      _scalingDeCom[ 3 ] = 0.012550998556013784;
      _scalingDeCom[ 4 ] = -0.01657454163101562;
      _scalingDeCom[ 5 ] = -0.03802993693503463;
      _scalingDeCom[ 6 ] = 0.0806126091510659;
      _scalingDeCom[ 7 ] = 0.07130921926705004;
      _scalingDeCom[ 8 ] = -0.22403618499416572;
      _scalingDeCom[ 9 ] = -0.14390600392910627;
      _scalingDeCom[ 10 ] = 0.4697822874053586;
      _scalingDeCom[ 11 ] = 0.7291320908465551;
      _scalingDeCom[ 12 ] = 0.39653931948230575;
      _scalingDeCom[ 13 ] = 0.07785205408506236;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies7

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of sixteen coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db8/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies8 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies8( ) : base( "Daubechies 8", 16, 2 ) {
      _scalingDeCom[ 0 ] = -0.00011747678400228192;
      _scalingDeCom[ 1 ] = 0.0006754494059985568;
      _scalingDeCom[ 2 ] = -0.0003917403729959771;
      _scalingDeCom[ 3 ] = -0.00487035299301066;
      _scalingDeCom[ 4 ] = 0.008746094047015655;
      _scalingDeCom[ 5 ] = 0.013981027917015516;
      _scalingDeCom[ 6 ] = -0.04408825393106472;
      _scalingDeCom[ 7 ] = -0.01736930100202211;
      _scalingDeCom[ 8 ] = 0.128747426620186;
      _scalingDeCom[ 9 ] = 0.00047248457399797254;
      _scalingDeCom[ 10 ] = -0.2840155429624281;
      _scalingDeCom[ 11 ] = -0.015829105256023893;
      _scalingDeCom[ 12 ] = 0.5853546836548691;
      _scalingDeCom[ 13 ] = 0.6756307362980128;
      _scalingDeCom[ 14 ] = 0.3128715909144659;
      _scalingDeCom[ 15 ] = 0.05441584224308161;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies8

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of eighteen coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db9/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies9 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies9( ) : base( "Daubechies 9", 18, 2 ) {
      _scalingDeCom[ 0 ] = 3.9347319995026124e-05;
      _scalingDeCom[ 1 ] = -0.0002519631889981789;
      _scalingDeCom[ 2 ] = 0.00023038576399541288;
      _scalingDeCom[ 3 ] = 0.0018476468829611268;
      _scalingDeCom[ 4 ] = -0.004281503681904723;
      _scalingDeCom[ 5 ] = -0.004723204757894831;
      _scalingDeCom[ 6 ] = 0.022361662123515244;
      _scalingDeCom[ 7 ] = 0.00025094711499193845;
      _scalingDeCom[ 8 ] = -0.06763282905952399;
      _scalingDeCom[ 9 ] = 0.030725681478322865;
      _scalingDeCom[ 10 ] = 0.14854074933476008;
      _scalingDeCom[ 11 ] = -0.09684078322087904;
      _scalingDeCom[ 12 ] = -0.29327378327258685;
      _scalingDeCom[ 13 ] = 0.13319738582208895;
      _scalingDeCom[ 14 ] = 0.6572880780366389;
      _scalingDeCom[ 15 ] = 0.6048231236767786;
      _scalingDeCom[ 16 ] = 0.24383467463766728;
      _scalingDeCom[ 17 ] = 0.03807794736316728;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies9

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of twenty coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db10/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies10 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies10( ) : base( "Daubechies 10", 20, 2 ) {
      _scalingDeCom[ 0 ] = -1.326420300235487e-05;
      _scalingDeCom[ 1 ] = 9.358867000108985e-05;
      _scalingDeCom[ 2 ] = -0.0001164668549943862;
      _scalingDeCom[ 3 ] = -0.0006858566950046825;
      _scalingDeCom[ 4 ] = 0.00199240529499085;
      _scalingDeCom[ 5 ] = 0.0013953517469940798;
      _scalingDeCom[ 6 ] = -0.010733175482979604;
      _scalingDeCom[ 7 ] = 0.0036065535669883944;
      _scalingDeCom[ 8 ] = 0.03321267405893324;
      _scalingDeCom[ 9 ] = -0.02945753682194567;
      _scalingDeCom[ 10 ] = -0.07139414716586077;
      _scalingDeCom[ 11 ] = 0.09305736460380659;
      _scalingDeCom[ 12 ] = 0.12736934033574265;
      _scalingDeCom[ 13 ] = -0.19594627437659665;
      _scalingDeCom[ 14 ] = -0.24984642432648865;
      _scalingDeCom[ 15 ] = 0.2811723436604265;
      _scalingDeCom[ 16 ] = 0.6884590394525921;
      _scalingDeCom[ 17 ] = 0.5272011889309198;
      _scalingDeCom[ 18 ] = 0.18817680007762133;
      _scalingDeCom[ 19 ] = 0.026670057900950818;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies10

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of twenty-two coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db11/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies11 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies11( ) : base( "Daubechies 11", 22, 2 ) {
      _scalingDeCom[ 0 ] = 4.494274277236352e-06;
      _scalingDeCom[ 1 ] = -3.463498418698379e-05;
      _scalingDeCom[ 2 ] = 5.443907469936638e-05;
      _scalingDeCom[ 3 ] = 0.00024915252355281426;
      _scalingDeCom[ 4 ] = -0.0008930232506662366;
      _scalingDeCom[ 5 ] = -0.00030859285881515924;
      _scalingDeCom[ 6 ] = 0.004928417656058778;
      _scalingDeCom[ 7 ] = -0.0033408588730145018;
      _scalingDeCom[ 8 ] = -0.015364820906201324;
      _scalingDeCom[ 9 ] = 0.02084090436018004;
      _scalingDeCom[ 10 ] = 0.03133509021904531;
      _scalingDeCom[ 11 ] = -0.06643878569502022;
      _scalingDeCom[ 12 ] = -0.04647995511667613;
      _scalingDeCom[ 13 ] = 0.14981201246638268;
      _scalingDeCom[ 14 ] = 0.06604358819669089;
      _scalingDeCom[ 15 ] = -0.27423084681792875;
      _scalingDeCom[ 16 ] = -0.16227524502747828;
      _scalingDeCom[ 17 ] = 0.41196436894789695;
      _scalingDeCom[ 18 ] = 0.6856867749161785;
      _scalingDeCom[ 19 ] = 0.44989976435603013;
      _scalingDeCom[ 20 ] = 0.1440670211506196;
      _scalingDeCom[ 21 ] = 0.01869429776147044;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies11

  } // class

  ///<summary>
  /// Ingrid Daubechies' wavelet of twenty-four coefficients in orthonormal
  /// version. Already orthonormal coefficients taken from Filip Wasilewski's
  /// webpage http://wavelets.pybytes.com/wavelet/db12/ Thanks!
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
  ///</remarks>
  public class Daubechies12 : Wavelet {

    ///<summary>
    /// Constructor keeping the orthogonal Daubechies scaling coefficients,
    /// orthonormalizes them (normed, due to ||*||2 euclidean norm), and
    /// builds all other coefficients, therewith the orthonormal base.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 26.03.2010 07:35:31
    ///</remarks>
    public Daubechies12( ) : base( "Daubechies 12", 24, 2 ) {
      _scalingDeCom[ 0 ] = -1.5290717580684923e-06;
      _scalingDeCom[ 1 ] = 1.2776952219379579e-05;
      _scalingDeCom[ 2 ] = -2.4241545757030318e-05;
      _scalingDeCom[ 3 ] = -8.850410920820318e-05;
      _scalingDeCom[ 4 ] = 0.0003886530628209267;
      _scalingDeCom[ 5 ] = 6.5451282125215034e-06;
      _scalingDeCom[ 6 ] = -0.0021795036186277044;
      _scalingDeCom[ 7 ] = 0.0022486072409952287;
      _scalingDeCom[ 8 ] = 0.006711499008795549;
      _scalingDeCom[ 9 ] = -0.012840825198299882;
      _scalingDeCom[ 10 ] = -0.01221864906974642;
      _scalingDeCom[ 11 ] = 0.04154627749508764;
      _scalingDeCom[ 12 ] = 0.010849130255828966;
      _scalingDeCom[ 13 ] = -0.09643212009649671;
      _scalingDeCom[ 14 ] = 0.0053595696743599965;
      _scalingDeCom[ 15 ] = 0.18247860592758275;
      _scalingDeCom[ 16 ] = -0.023779257256064865;
      _scalingDeCom[ 17 ] = -0.31617845375277914;
      _scalingDeCom[ 18 ] = -0.04476388565377762;
      _scalingDeCom[ 19 ] = 0.5158864784278007;
      _scalingDeCom[ 20 ] = 0.6571987225792911;
      _scalingDeCom[ 21 ] = 0.3773551352142041;
      _scalingDeCom[ 22 ] = 0.10956627282118277;
      _scalingDeCom[ 23 ] = 0.013112257957229239;
      _buildBaseSystem( ); // build the orthogonal / orthonormal base system
    } // Daubechies12

  } // class

} // namespace
