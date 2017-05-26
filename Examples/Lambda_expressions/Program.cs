using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_expressions
{
    class Program
    {
        public delegate int Calculate(int x, int y);
        static void Main(string[] args)
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4)); // Displays 7 
            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4)); // Displays 12

            //================================================
            Calculate calc1 = (a, b) =>
            {

                Console.WriteLine("Adding numbers");
                return a + b;
            };
            int result = calc1(5, 6);
            Console.WriteLine(result);
            //================================================

            Action<int, int> calc2 = (c, d) =>
            {
                Console.WriteLine(c + d);
            };

            calc2(7, 8);
        }

    }
}
