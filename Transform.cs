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

    protected BasicTransform _basicTransform;

    public Transform( BasicTransform basicTransform )
    {
      if(basicTransform == null )
        throw new NotExistent( "Given transform oject is null!" );
      if(!(basicTransform is BasicTransform))
        throw new NotExistent( "Given transform oject is not correct type!" );
      _basicTransform = basicTransform;
    } // method

    public double[ ] forward( double[ ] arrTime ) {
      double[ ] arrHilb = null;
      arrHilb = _basicTransform.forward( arrTime );
      return arrHilb;
    } // forward

    public double[ ] reverse( double[ ] arrHilb ) {
      double[ ] arrTime = null;
      arrTime = _basicTransform.reverse( arrHilb )
      return arrTime;
    } // reverse

    public double[ ] forward( double[ ] arrTime, int level ) {
      double[ ] arrHilb = null;
      arrHilb = _basicTransform.forward( arrTime, level );
      return arrHilb;
    } // forward

    public double[ ] reverse( double[ ] arrHilb, int level ) {
      double[ ] arrTime = null;
      arrTime = _basicTransform.reverse( arrHilb, level );
      return arrTime;
    } // reverse

  } // class

} // namespace
