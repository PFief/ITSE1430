﻿/*
 * ITSE 1430
 *
 * Section 1
 */
using System;

namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            while (!quit)
            {
                //Equality
                bool isEqual = quit.Equals(10);

                //Display the menu
                char choice = DisplayMenu();

                //Process menu selection
                switch (Char.ToUpper(choice))
                {
                    case 'L': ListProducts(); break;
                    case 'A': AddProduct(); break;
                    case 'Q': quit = true; break;
                }
            }
        }

        static void AddProduct()
        {
            //Get name
            _name = ReadString("Enter name: ", true);

            //Get price
            _price = ReadDecimal("Enter price: ", 0);

            //Get description
            _description = ReadString("Enter optional description: ", false);
        }

        private static string ReadString(string message, bool isRequired)
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                //If not required or not empty
                if (!isRequired || value != "")
                    return value;

                Console.WriteLine("Value is required");
            } while (true);
        }

        private static decimal ReadDecimal( string message, decimal minValue )
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();
                
                if (Decimal.TryParse(value, out decimal result))
                {
                    //If not required or not empty
                    if (result >= minValue)
                        return result;
                }

                //Formatting strings
                //Console.WriteLine("Value must be >= {0}", minValue);
                string msg = String.Format("Value must be >= {0}", minValue);
                Console.WriteLine(msg);
            } while (true);
        }

        private static char DisplayMenu()
        {
            do
            {
                Console.WriteLine("L)ist Products");
                Console.WriteLine("A)dd Product");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine(); //Probably use toUpper
                //Remove whitespace
                input = input.Trim();
                //input = input.ToUpper();

                //Padding
                //input = input.PadLeft(10);

                //Starts with outputs true/false
                //input.StartsWith(@"\");
                //input.EndsWith(@"\");

                //Substring
                //string newValue = input.Substring(0, 10);

                if (String.Compare(input, "L", true) == 0)
                    return input[0];
                else if (String.Compare(input, "A", true) == 0)
                    return input[0];
                else if (String.Compare(input, "Q", true) == 0)
                    return input[0];
                
                Console.WriteLine("Please choose a valid option");
            } while (true);
        }

        static void ListProducts()
        {
            //Are there any products?
            //if (_name != null && _name != String.Empty)
            //if (_name != null && _name.Length == 0)
            if (!String.IsNullOrEmpty(_name)) 
            {
                //Display a product - name [$price]
                //                    <description>
                //String formatting
                //var msg = String.Format("{0} [${1}]", _name, _price);

                //String concatenation
                //var msg = _name + " [$" + _price + "]";
                
                //String concat part 2
                //var msg = String.Concat(_name, " [$", _price, "]");

                //String interpolation
                string msg = $"{_name} [${_price}]";

                Console.WriteLine(msg);
                //Console.WriteLine(_name);
                //Console.WriteLine(_price);

                if (!String.IsNullOrEmpty(_description))
                    Console.WriteLine(_description);
            } else
                Console.WriteLine("No products");
        }

        //Data for a product
        static string _name;
        static decimal _price;
        static string _description;

        static void PlayingWithPrimitives()
        {
            //Primitive
            decimal unitPrice = 10.5M;

            //Real declaration
            System.Decimal unitPrice2 = 10.5M;

            //Current time
            DateTime now = DateTime.Now;

            System.Collections.ArrayList items;
            
        }

        static void PlayingWithVariables()
        {
            int hours = 0;
            double rate = 10.25;

            int hours2 = hours;
            string firstName, lastName;

            //string @class;

            firstName = "Bob";
            lastName = "Miller";

            firstName = lastName = "Sue";

            //Math ops
            int x = 0, y = 10;
            int add = x + y;
            int subtract = x - y;
            int multiply = x * y;
            int divide = x / y;
            int modulos = x % y;

            x += 10;
            double ceiling = Math.Ceiling(rate);
            double floor = ceiling;
        }
    }
}
