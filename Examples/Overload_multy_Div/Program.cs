using System;
using System.Collections.Generic;
using System.Text;

namespace Overload_multy_Div
{
    class Program
    {

        //5.  Create a Fraction class and dene the * and / operators for it.
        static void Main(string[] args)
        {

            var obj1 = new Fraction(10);
            var obj2 = new Fraction(2);
            Fraction num1 = obj1 * obj2;
            Fraction num2 = obj1 / obj2;
            Console.WriteLine(num1.param);
            Console.WriteLine(num2.param);
        }
    }

    public class Fraction
    {

        public int param;
        public Fraction(int param)
        {
            this.param = param;
        }

        public static Fraction operator *(Fraction obj1, Fraction obj2)
        {
            return new Fraction(obj1.param * obj2.param);
        }
        public static Fraction operator /(Fraction obj1, Fraction obj2)
        {
            return new Fraction(obj1.param / obj2.param);
        }
    }
}
