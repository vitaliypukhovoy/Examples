using System;
using System.Collections.Generic;
using System.Text;

namespace Overload_Equals_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new Fraction(10);
            var obj2 = new Fraction(2);
            bool boolean = obj1.Equals(obj2);
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
        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            Fraction obj2 = (Fraction)obj;

            return obj.GetType() == GetType() && this.param == obj2.param;
        }

        public override int GetHashCode()
        {
            return param.GetHashCode();
        }
    }
}
