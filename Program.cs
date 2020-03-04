///
/// SharpWave - a pragmatic port of JWave
/// https://github.com/cscheiblich/JWave
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
using System.Collections.Generic;

namespace Program
{

  using Types; // use Exception classes here
  using Types.Composite; // use class Entity

  /// <summary>
  /// Some example how to specialize the Composite Pattern Entity to any data
  /// set.
  /// </summary>
  /// <remarks>
  /// This is the basic set of functionality, there are a lot more stuff
  /// available by class Entity, e.g. has methods on CHILDS and ATTRIBUTES, ..
  /// </remarks>
  public class Address : Entity {

    private const string _id = "Id";
    private const string _city = "City";
    private const string _street = "Street";
    private const string _number = "No";

    public Address( ) : base( "Address" ) {
      ATTRIBUTES.create( _id );            // address should have an attribute
      CHILDS.create( _city );              // .. should have a child as city
      CHILDS.create( _street );            // .. should have a child as street
      Entity street = CHILDS[ _street ];   // fetch the child street
      street.ATTRIBUTES.create( _number ); // street should have an attribute
    } // method

    public string ID { // some getter n setter on attribute's value
      get{ return ATTRIBUTES[ _id ].VAL; }
      set{ ATTRIBUTES[ _id ].VAL = value; }
    } // method

    public string STREET { // some getter n setter on child's value
      get { return CHILDS[ _street ].VAL; }
      set { CHILDS[ _street ].VAL = value; }
    } // method

    public string NUMBER { // some getter n setter on child's attribute value
      get { return CHILDS[ _street ].ATTRIBUTES[ _number ].VAL; }
      set { CHILDS[ _street ].ATTRIBUTES[ _number ].VAL = value; }
    } // method

    public string CITY { // some better getter n setter on child's value
      get { // example to check if certain child is available or not
        string city = "n/a";
        if( CHILDS.has( _city ) )
          city = CHILDS[ _city ].VAL;
        return city;
      } // method
      set { // example to check if certain child is available or not
        if( CHILDS.has( _city ) )
          CHILDS[ _city ].VAL = value;
        else
          throw new Types_NotPossible(
            "CITY.set - node: " + _city + " is missing in data structure!" );
      } // method
    } // method

  } // class

  class MainClass
  {
    public static void Main (string[] args)
    {
      try {
        Console.WriteLine ("C# Composite Entity ..");
        Console.WriteLine();

        Entity data = new Entity("data"); // create a root element

        Address address1 = new Address( ); // first data set
        address1.ID = "1";
        address1.STREET = "Mannheim Rd";
        address1.NUMBER = "1600";
        address1.CITY = "Chicago";
        data.CHILDS.add( address1 ); // add data set to root element as child

        Address address2 = new Address( ); // second data set
        address2.ID = "2";
        address2.STREET = "Ocean Drive";
        address2.NUMBER = "800";
        address2.CITY = "Los Angeles";
        data.CHILDS.add( address2 ); // add data set to root element as child

        string xml = data.XML; // generate XML
        Console.WriteLine( xml ); // show

      } catch(Exception e) {
        Console.WriteLine();
        Console.WriteLine (e.StackTrace);
        Console.WriteLine (e.Message);
      } // try

    } // method

  } // class

} // namespace
