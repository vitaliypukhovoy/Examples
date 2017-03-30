using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonimusMethods_LamdaExpression
{

    delegate void Operation(int num);
    delegate int Operation1(int num);
    delegate void Operation2(int num);
    class Program
    {
        static void Main(string[] args)
        {
            //Operation op = Double;
            Operation op = delegate(int num) 
            {
                Console.WriteLine("{0} x 2 = {1}", num, num * 2);
                Console.WriteLine("{0} x 3 = {1}", num, num * 3);
                Console.WriteLine("{0} x 4 = {1}", num, num * 4);
                Console.WriteLine("{0} x 5 = {1}", num, num * 5);
            };           
            op(2);
           //=======================================
            Operation1 op1 = delegate(int num)
            {
                return num * 2;
            };

            int value = op1(2);
            Console.WriteLine(value);
            //=======================================

            Operation2 op2 =  num =>  //(int num)=>
            {
                Console.WriteLine("{0} x 2 = {1}", num, num * 2);               
            };
            op2(2);    
            //=======================================

            Operation2 op3 = num => Console.WriteLine("{0} x 2 = {1}", num, num * 2);                            
            op3(2);
            //=======================================
            Action<int> op4 = num => Console.WriteLine("{0} x 2 = {1}", num, num * 2);
            op4(5);            
            //=======================================

            Func<int,int> op5 = num => { return num * 5;};
            Func<int, int> op6 = num =>  num * 6;
            Console.WriteLine(op5(2));
            Console.WriteLine(op6(2));
        }


        static void Double(int num)
        {
            Console.WriteLine("{0} x 2 = {1}", num, num * 2);
        }
    }
}
