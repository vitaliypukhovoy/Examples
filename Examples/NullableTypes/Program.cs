using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {      
            int? a = null;
            int? b;

            b = a ?? 10; // b = 10
            Console.WriteLine(b);

            a = 3;
            b = a ?? 10; // b = 3
            Console.WriteLine(b);
            

            //===============================
            Nullable<int> c = 1;

            if (c.HasValue == true)
            {
                Console.WriteLine("c is {0}.", c.Value);
            }
            
            int? d = 1;

            if (d.HasValue == true)
            {
                Console.WriteLine("d is {0}", d.Value);
            }
            
            // var? c = null;        

            // Delay.
            Console.ReadKey();
        }
    }
}
