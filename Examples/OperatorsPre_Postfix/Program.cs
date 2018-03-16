using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorsPre_Postfix
{
    class Program
    {
        static void Main(string[] args)
        {
          //1.Can you use both the pre- and post-increment operators on the same variable as in ++x++? 
          //If you can’t 
            decimal priceEach = 1000;           
            for (int i = 0; i < 10; i++)
            {
               // Console.WriteLine("i1:" +i);
                decimal totalPrice = i++ * priceEach;
               // Console.WriteLine("i2:" + i);
                Console.WriteLine(totalPrice);
            }
            Console.WriteLine(new String('-',50));

            for (int j = 0; j < 10; ++j)
            {
               // Console.WriteLine("j1:" + j);
                decimal totalPrice = ++j * priceEach;
               // Console.WriteLine("j2:" + j);
                Console.WriteLine(totalPrice);
            }

        }
    }
}
