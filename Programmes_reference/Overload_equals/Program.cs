using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload_equals
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new Fraction(10);
            var obj2 = new Fraction(2);
            bool boolean1 = obj1 == obj2;
            bool boolean2 = obj1 != obj2;
            Console.WriteLine(boolean1);
            Console.WriteLine(boolean2); 
        }
    }

    public class Fraction
    {
        public int param;
        public Fraction(int param)
        {
            this.param = param;
        }
        public static bool operator ==(Fraction obj1, Fraction obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Fraction obj1, Fraction obj2)
        {
            return !obj1.Equals(obj2);
        }

    }
}
