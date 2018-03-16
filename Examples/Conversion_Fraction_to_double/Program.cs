using System;
using System.Collections.Generic;
using System.Text;

namespace Conversion_Fraction_to_double
{
    class Program
    {

        //6.Create a conversion operator to convert Fraction to double. Is this a widening or  
        //narrowing conversion?

        static void Main(string[] args)
        {
            var obj1 = new Fraction(10);
            var obj2 = new Fraction(2);
            double num = obj1 * obj2;
            Console.WriteLine(num);
        }
    }

    public class Fraction
    {

        public int param;
        public Fraction(int param)
        {
            this.param = param;
        }

        public static double operator *(Fraction obj1, Fraction obj2)
        {
            return obj1.param * obj2.param;
        }

    }
}
