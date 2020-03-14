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
using SharpWave;

namespace Types
{
    /// <summary>
    /// Base exception class that any other specific exception class inherit.
    /// </summary>
    public class Types_Exception : System.Exception
    {
        public Types_Exception() : base() { }
        public Types_Exception(string msg) : base("TYPES." + msg) { }
        public Types_Exception(string msg, Exception e) :
          base("TYPES." + msg, e) { }
    } // class

    /// <summary>
    /// Error that should be used within this namespace.
    /// </summary>
    public class Types_Error : Types_Exception
    {
        public Types_Error() : base() { }
        public Types_Error(string msg) : base(msg + " - " + Globals.ERROR) { }
        public Types_Error(string msg, Exception e) :
          base(msg + " - " + Globals.ERROR, e) { }
    } // class

    /// <summary>
    /// Failure that should be used within this namespace.
    /// </summary>
    public class Types_Failure : Types_Exception
    {
        public Types_Failure() : base() { }
        public Types_Failure(string msg) : base(msg + " - " + Globals.FAILURE) { }
        public Types_Failure(string msg, Exception e) :
          base(msg + " - " + Globals.FAILURE, e) { }
    } // class

    /// <summary>
    /// Warning that should be used within this namespace.
    /// </summary>
    public class Types_Warning : Types_Exception
    {
        public Types_Warning() : base() { }
        public Types_Warning(string msg) : base(msg + " - " + Globals.WARNING) { }
        public Types_Warning(string msg, Exception e) :
          base(msg + " - " + Globals.WARNING, e) { }
    } // class

    /// <summary>
    /// Irrelevant that should be used within this namespace.
    /// </summary>
    public class Types_Irrelevant : Types_Exception
    {
        public Types_Irrelevant() : base() { }
        public Types_Irrelevant(string msg) :
          base(msg + " - " + Globals.IRRELEVANT) { }
        public Types_Irrelevant(string msg, Exception e) :
          base(msg + " - " + Globals.IRRELEVANT, e) { }
    } // class

    /// <summary>
    /// Not existent that should be used within this namespace.
    /// </summary>
    public class Types_NotExistent : Types_Exception
    {
        public Types_NotExistent() : base() { }
        public Types_NotExistent(string msg) :
          base(msg + " - " + Globals.NOT_EXISTENT) { }
        public Types_NotExistent(string msg, Exception e) :
          base(msg + " - " + Globals.NOT_EXISTENT, e) { }
    } // class

    /// <summary>
    /// Not found that should be used within this namespace.
    /// </summary>
    public class Types_NotFound : Types_Exception
    {
        public Types_NotFound() : base() { }
        public Types_NotFound(string msg) :
          base(msg + " - " + Globals.NOT_FOUND) { }
        public Types_NotFound(string msg, Exception e) :
          base(msg + " - " + Globals.NOT_FOUND, e) { }
    } // class

    /// <summary>
    /// Not valid that should be used within this namespace.
    /// </summary>
    public class Types_NotValid : Types_Exception
    {
        public Types_NotValid() : base() { }
        public Types_NotValid(string msg) :
          base(msg + " - " + Globals.NOT_VALID) { }
        public Types_NotValid(string msg, Exception e) :
          base(msg + " - " + Globals.NOT_VALID, e) { }
    } // class

    /// <summary>
    /// Not possible that should be used within this namespace.
    /// </summary>
    public class Types_NotPossible : Types_Exception
    {
        public Types_NotPossible() : base() { }
        public Types_NotPossible(string msg) :
          base(msg + " - " + Globals.NOT_POSSIBLE) { }
        public Types_NotPossible(string msg, Exception e) :
          base(msg + " - " + Globals.NOT_POSSIBLE, e) { }
    } // class

      /// <summary>
      /// Not available that should be used within this namespace.
      /// </summary>
      public class Types_NotAvailable : Types_Exception
      {
          public Types_NotAvailable() : base() { }
          public Types_NotAvailable(string msg) :
            base(msg + " - " + Globals.NOT_AVAILABLE) { }
          public Types_NotAvailable(string msg, Exception e) :
            base(msg + " - " + Globals.NOT_AVAILABLE, e) { }
      } // class

    /// <summary>
    /// Not implemented that should be used within this namespace.
    /// </summary>
    public class Types_NotImplemented : Types_Exception
    {
        public Types_NotImplemented() : base() { }
        public Types_NotImplemented(string msg) :
          base(msg + " - " + Globals.NOT_IMPLEMENTED) { }
        public Types_NotImplemented(string msg, Exception e) :
          base(msg + " - " + Globals.NOT_IMPLEMENTED, e) { }
    } // class

    /// <summary>
    /// Base exception class for DATA problematics; any other specific
    /// exception class inherits.
    /// </summary>
    /// <remarks>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </remarks>
    public class Data_Exception : System.Exception
    {
        public Data_Exception() : base() { }
        public Data_Exception(string msg) : base("DATA." + msg) { }
        public Data_Exception(string msg, Exception e) :
          base("DATA." + msg, e) { }
    } // class

    /// <summary>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </summary>
    /// <remarks>
    /// Use this in general if something went totally wrong and program has
    /// to be aborted.
    /// </remarks>
    public class Data_Error : Data_Exception
    {
        public Data_Error() : base() { }
        public Data_Error(string msg) : base(Globals.ERROR + " " + msg) { }
        public Data_Error(string msg, Exception e) :
          base(Globals.ERROR + " " + msg, e) { }
    } // class

    /// <summary>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </summary>
    /// <remarks>
    /// Use this in case of some structural / logical inconsistencies that do
    /// not bother but may be cleaned up in future releases or versions.
    /// </remarks>
    public class Data_Warning : Data_Exception
    {
        public Data_Warning() : base() { }
        public Data_Warning(string msg) : base(Globals.WARNING + " " + msg) { }
        public Data_Warning(string msg, Exception e) :
          base(Globals.WARNING + " " + msg, e) { }
    } // class

    /// <summary>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </summary>
    /// <remarks>
    /// Use this if some logical, strucutural content is additional and
    /// uselessfor the performed processing, operation.
    /// </remarks>
    public class Data_Irrelevant : Data_Exception
    {
        public Data_Irrelevant() : base() { }
        public Data_Irrelevant(string msg) :
          base(Globals.IRRELEVANT + " " + msg) { }
        public Data_Irrelevant(string msg, Exception e) :
          base(Globals.IRRELEVANT + " " + msg, e) { }
    } // class

    /// <summary>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </summary>
    /// <remarks>
    /// Use this if some data is requested and not found in data strucutre.
    /// </remarks>
    public class Data_NotFound : Data_Exception
    {
        public Data_NotFound() : base() { }
        public Data_NotFound(string msg) : base(Globals.NOT_FOUND + " " + msg) { }
        public Data_NotFound(string msg, Exception e) :
          base(Globals.NOT_FOUND + " " + msg, e) { }
    } // class

    /// <summary>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </summary>
    /// <remarks>
    /// Use this if some data content can be read in structural ways but the
    /// content itself is not available as information; e.g. n/a is placed
    /// instead a value.
    /// </remarks>
    public class Data_NotAvailable : Data_Exception
    {
        public Data_NotAvailable() : base() { }
        public Data_NotAvailable(string msg) :
          base(Globals.NOT_AVAILABLE + " " + msg) { }
        public Data_NotAvailable(string msg, Exception e) :
          base(Globals.NOT_AVAILABLE + " " + msg, e) { }
    } // class

    /// <summary>
    /// Hierachical exception that should be used for logical, structural
    /// problems in the processed data structure or in case of problematic
    /// content.
    /// </summary>
    /// <remarks>
    /// Use this if content is found that is not valid; e.g. if a value is
    /// out of range.
    /// </remarks>
    public class Data_NotValid : Data_Exception
    {
        public Data_NotValid() : base() { }
        public Data_NotValid(string msg) : base(Globals.NOT_VALID + " " + msg) { }
        public Data_NotValid(string msg, Exception e) :
          base(Globals.NOT_VALID + " " + msg, e) { }
    } // class

} // namespace
