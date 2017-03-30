using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
//

namespace Closures
{
    class Program
    {       
        static void Main(string[] args)
        {
          //  Func<int,int>f = i => i + 7;         
            var funcs = new List<Func<int, int>>(); //List<Func<int>>();
            for (int i = 0; i < 3; i++)
            {
                int tmp = i;
                //funcs.Add(() => i);
                funcs.Add((x) => tmp+1);
            }
            foreach (var f in funcs)                
                Console.WriteLine(f(0));           
        }
    }
}
