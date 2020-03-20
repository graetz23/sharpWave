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
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of six coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:27:55
  ///</remarks>
  public class Coiflet1 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// six coefficients, orthonormalizes them (normed, due to ||*||2 euclidean
    /// norm), and builds the scaling coefficients, and the orthonormal bases
    /// afterwards; .
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:27:55
    ///</remarks>
    public Coiflet1( ) : base( "Coiflet 1", 6, 2 ) {
      double sqrt02 = 1.4142135623730951;
      double sqrt15 = Math.Sqrt( 15.0 );
      // these coefficients are already orthonormal
      _scalingDeCom[ 0 ] = sqrt02 * ( sqrt15 - 3.0 ) / 32.0; //  -0.01565572813546454;
      _scalingDeCom[ 1 ] = sqrt02 * ( 1.0 - sqrt15 ) / 32.0; // -0.0727326195128539;
      _scalingDeCom[ 2 ] = sqrt02 * ( 6.0 - 2.0 * sqrt15 ) / 32.0; //  0.38486484686420286;
      _scalingDeCom[ 3 ] = sqrt02 * ( 2.0 * sqrt15 + 6.0 ) / 32.0; // 0.8525720202122554;
      _scalingDeCom[ 4 ] = sqrt02 * ( sqrt15 + 13.0 ) / 32.0; // 0.3378976624578092;
      _scalingDeCom[ 5 ] = sqrt02 * ( 9.0 - sqrt15 ) / 32.0; //-0.0727326195128539;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet1

  } // class

  ///<summary>
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of twelve coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:33:55
  ///</remarks>
  public class Coiflet2 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// twelve coefficients, orthonormalizes them (normed, due to ||*||2
    /// euclidean norm), and builds the scaling coefficients, and the
    /// orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:33:55
    ///</remarks>
    public Coiflet2( ) : base( "Coiflet 2", 12, 2 ) {
      _scalingDeCom[ 0 ] = -0.0007205494453645122;
      _scalingDeCom[ 1 ] = -0.0018232088707029932;
      _scalingDeCom[ 2 ] = 0.0056114348193944995;
      _scalingDeCom[ 3 ] = 0.023680171946334084;
      _scalingDeCom[ 4 ] = -0.0594344186464569;
      _scalingDeCom[ 5 ] = -0.0764885990783064;
      _scalingDeCom[ 6 ] = 0.41700518442169254;
      _scalingDeCom[ 7 ] = 0.8127236354455423;
      _scalingDeCom[ 8 ] = 0.3861100668211622;
      _scalingDeCom[ 9 ] = -0.06737255472196302;
      _scalingDeCom[ 10 ] = -0.04146493678175915;
      _scalingDeCom[ 11 ] = 0.016387336463522112;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet2

  } // class

  ///<summary>
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of eighteen coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 15.02.2014 22:58:59
  ///</remarks>
  public class Coiflet3 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// eighteen coefficients, orthonormalizes them (normed, due to ||*||2
    /// euclidean norm), and builds the scaling coefficients, and the
    /// orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 15.02.2014 22:58:59
    ///</remarks>
    public Coiflet3( ) : base( "Coiflet 3", 18, 2 ) {
      _scalingDeCom[ 0 ] = -3.459977283621256e-05;
      _scalingDeCom[ 1 ] = -7.098330313814125e-05;
      _scalingDeCom[ 2 ] = 0.0004662169601128863;
      _scalingDeCom[ 3 ] = 0.0011175187708906016;
      _scalingDeCom[ 4 ] = -0.0025745176887502236;
      _scalingDeCom[ 5 ] = -0.00900797613666158;
      _scalingDeCom[ 6 ] = 0.015880544863615904;
      _scalingDeCom[ 7 ] = 0.03455502757306163;
      _scalingDeCom[ 8 ] = -0.08230192710688598;
      _scalingDeCom[ 9 ] = -0.07179982161931202;
      _scalingDeCom[ 10 ] = 0.42848347637761874;
      _scalingDeCom[ 11 ] = 0.7937772226256206;
      _scalingDeCom[ 12 ] = 0.4051769024096169;
      _scalingDeCom[ 13 ] = -0.06112339000267287;
      _scalingDeCom[ 14 ] = -0.0657719112818555;
      _scalingDeCom[ 15 ] = 0.023452696141836267;
      _scalingDeCom[ 16 ] = 0.007782596427325418;
      _scalingDeCom[ 17 ] = -0.003793512864491014;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet3

  } // class

  ///<summary>
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of twentyfour coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 16.02.2014 01:46:11
  ///</remarks>
  public class Coiflet4 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// twentyfour coefficients, orthonormalizes them (normed, due to ||*||2
    /// euclidean norm), and builds the scaling coefficients, and the
    /// orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 01:46:11
    ///</remarks>
    public Coiflet4( ) : base( "Coiflet 4", 24, 2 ) {
      _scalingDeCom[ 0 ] = -1.7849850030882614e-06;
      _scalingDeCom[ 1 ] = -3.2596802368833675e-06;
      _scalingDeCom[ 2 ] = 3.1229875865345646e-05;
      _scalingDeCom[ 3 ] = 6.233903446100713e-05;
      _scalingDeCom[ 4 ] = -0.00025997455248771324;
      _scalingDeCom[ 5 ] = -0.0005890207562443383;
      _scalingDeCom[ 6 ] = 0.0012665619292989445;
      _scalingDeCom[ 7 ] = 0.003751436157278457;
      _scalingDeCom[ 8 ] = -0.00565828668661072;
      _scalingDeCom[ 9 ] = -0.015211731527946259;
      _scalingDeCom[ 10 ] = 0.025082261844864097;
      _scalingDeCom[ 11 ] = 0.03933442712333749;
      _scalingDeCom[ 12 ] = -0.09622044203398798;
      _scalingDeCom[ 13 ] = -0.06662747426342504;
      _scalingDeCom[ 14 ] = 0.4343860564914685;
      _scalingDeCom[ 15 ] = 0.782238930920499;
      _scalingDeCom[ 16 ] = 0.41530840703043026;
      _scalingDeCom[ 17 ] = -0.05607731331675481;
      _scalingDeCom[ 18 ] = -0.08126669968087875;
      _scalingDeCom[ 19 ] = 0.026682300156053072;
      _scalingDeCom[ 20 ] = 0.016068943964776348;
      _scalingDeCom[ 21 ] = -0.0073461663276420935;
      _scalingDeCom[ 22 ] = -0.0016294920126017326;
      _scalingDeCom[ 23 ] = 0.0008923136685823146;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet4

  } // class

  ///<summary>
  /// Ingrid Daubechies' orthonormal Coiflet wavelet of thirty coefficients.
  ///</summary>
  ///<remarks>
  /// Christian (graetz23@gmail.com) 16.02.2014 01:49:39
  ///</remarks>
  public class Coiflet5 : Wavelet {

    ///<summary>
    /// Constructor calculating analytically the orthogonal Coiflet wavelet of
    /// thirty coefficients, orthonormalizes them (normed, due to ||*||2
    /// euclidean norm), and builds the scaling coefficients, and the
    /// orthonormal bases afterwards.
    ///</summary>
    ///<remarks>
    /// Christian (graetz23@gmail.com) 16.02.2014 01:49:39
    ///</remarks>
    public Coiflet5( ) : base( "Coiflet 5", 30, 2 ) {
      _scalingDeCom[ 0 ] = -9.517657273819165e-08;
      _scalingDeCom[ 1 ] = -1.6744288576823017e-07;
      _scalingDeCom[ 2 ] = 2.0637618513646814e-06;
      _scalingDeCom[ 3 ] = 3.7346551751414047e-06;
      _scalingDeCom[ 4 ] = -2.1315026809955787e-05;
      _scalingDeCom[ 5 ] = -4.134043227251251e-05;
      _scalingDeCom[ 6 ] = 0.00014054114970203437;
      _scalingDeCom[ 7 ] = 0.00030225958181306315;
      _scalingDeCom[ 8 ] = -0.0006381313430451114;
      _scalingDeCom[ 9 ] = -0.0016628637020130838;
      _scalingDeCom[ 10 ] = 0.0024333732126576722;
      _scalingDeCom[ 11 ] = 0.006764185448053083;
      _scalingDeCom[ 12 ] = -0.009164231162481846;
      _scalingDeCom[ 13 ] = -0.01976177894257264;
      _scalingDeCom[ 14 ] = 0.03268357426711183;
      _scalingDeCom[ 15 ] = 0.0412892087501817;
      _scalingDeCom[ 16 ] = -0.10557420870333893;
      _scalingDeCom[ 17 ] = -0.06203596396290357;
      _scalingDeCom[ 18 ] = 0.4379916261718371;
      _scalingDeCom[ 19 ] = 0.7742896036529562;
      _scalingDeCom[ 20 ] = 0.4215662066908515;
      _scalingDeCom[ 21 ] = -0.05204316317624377;
      _scalingDeCom[ 22 ] = -0.09192001055969624;
      _scalingDeCom[ 23 ] = 0.02816802897093635;
      _scalingDeCom[ 24 ] = 0.023408156785839195;
      _scalingDeCom[ 25 ] = -0.010131117519849788;
      _scalingDeCom[ 26 ] = -0.004159358781386048;
      _scalingDeCom[ 27 ] = 0.0021782363581090178;
      _scalingDeCom[ 28 ] = 0.00035858968789573785;
      _scalingDeCom[ 29 ] = -0.00021208083980379827;
      _buildBaseSystem( ); // build all other from low pass decomposition
    } // Coiflet5

  } // class

} // namespace
