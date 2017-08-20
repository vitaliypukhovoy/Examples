using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload_subtraction
{
    class Program
    {    
         //Create a subtraction operator for the Complex class described in this chapter.
        static void Main(string[] args)
        {
            var obj1 = new Complex(10);
            var obj2 = new Complex(2);
            Complex num1 = obj1 - obj2;
            Complex num2 = obj1 + obj2;
            Console.WriteLine(num1.param);
            Console.WriteLine(num2.param);
        }        
    }
    public class Complex
    {
        public int param;
        public Complex(int param)
        {
            this.param = param;
        }
        public static Complex operator - (Complex obj1, Complex obj2)
        {
            return new Complex(obj1.param - obj2.param);
        }

        public static Complex operator +(Complex obj1, Complex obj2)
        {
            return new Complex(obj1.param + obj2.param);
        }
    }
}

