using System;
using System.Collections.Generic;
using System.Text;

namespace Overload_greater
{
    class Program
    {

        //7. Create a > operator for the Fraction class.
        static void Main(string[] args)
        {
            var obj1 = new Fraction(10);
            var obj2 = new Fraction(2);
            bool boolean = obj1 > obj2;
            Console.WriteLine(boolean);
        }
    }

    public class Fraction
    {

        public int param;
        public Fraction(int param)
        {
            this.param = param;
        }

        public static bool operator <(Fraction obj1, Fraction obj2)
        {

            bool status = false;
            if (obj1.param < obj2.param)
            {
                status = true;
            }

            return status;
        }
        public static bool operator >(Fraction obj1, Fraction obj2)
        {

            bool status = false;
            if (obj1.param > obj2.param)
            {
                status = true;
            }

            return status;
        }

    }
}
