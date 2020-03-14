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
  /// SharpWave.
  /// </summary>
  public class Globals
  { // general stuff
    public static string NULL { get { return null; } }
    public static string EMPTY { get { return ""; } }
    public static string TRUE { get { return "true"; } }
    public static string FALSE { get { return "false"; } }
    public static string OK { get { return "ok"; } }
    public static string NOK { get { return "nok"; } }
    public static string YES { get { return "yes"; } }
    public static string NO { get { return "no"; } }
    public static string NA { get { return "n/a"; } }
    public static string NO_ID { get { return "NO_ID"; } }
    public static string NO_TYPE { get { return "NO_TYPE"; } }
    // used by the exception handling
    public static string EXCEPTION { get { return "EXCEPTION"; } }
    public static string ERROR { get { return "ERROR"; } }
    public static string FAILURE { get { return "FAILURE"; } }
    public static string WARNING { get { return "WARNING"; } }
    public static string IRRELEVANT { get { return "IRRELEVANT"; } }
    public static string NOT_EXISTENT { get { return "NOT_EXISTENT"; } }
    public static string NOT_FOUND { get { return "NOT_FOUND"; } }
    public static string NOT_AVAILABLE { get { return "NOT_AVAILABLE"; } }
    public static string NOT_VALID { get { return "NOT_VALID"; } }
    public static string NOT_POSSIBLE { get { return "NOT_POSSIBLE"; } }
    public static string NOT_IMPLEMENTED { get { return "NOT_IMPLEMENTED"; } }
    public static string NOT_OKAY { get { return "NOT_OKAY"; } }
    public static string NOT_DEF { get { return "NOT_DEF"; } }

  } // class

} // namespace
