using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handling_exceptions3
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] A = { "1", "22", "333", "4444", "555", "66", "7" };
            var seq = A.OrderBy(i => i.Length).Select(i => i).Skip(4);
            //var seq = A.All(i => i.Length > 2);
            foreach (var i in seq)
            {
                Console.WriteLine(i);

            }
            Func<int, int> op1 = num => num * 5;
            Console.WriteLine(op1(6));
        }
    }

}
