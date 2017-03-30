using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{

    delegate void Operation(int num);
    class Program
    {
        static void Main(string[] args)
        {

            Operation op = Double;
            op += Triple;
            op += Triple;
            op += Triple;
            op += Triple;
            op -= Triple;
            op -= Double;

            ExcuteOperation(2,op);
        }
        static void Double(int num)
        {
            Console.WriteLine("{0} x 2 = {1}",num,num * 2);
        }

        static void Triple(int num)
        {
            Console.WriteLine("{0} x 3 = {1}", num, num * 3);
        }

        static void ExcuteOperation(int num, Operation op)
        {
            op(num);             
        }
    }

}
