using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _Interlocked
{
    class Program
    {

        static int value = 1;
        static int newValue = 5;
        static void Main(string[] args)
        {

            //int n = 0;
            //var up = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000000; i++)                    
            //        {
            //            Interlocked.Increment(ref n);
            //            // n++;
            //        }
            //});


            // Replace value with 1.
            ////Console.WriteLine(Interlocked.Exchange(ref n, 1)); 



            //for (int i = 0; i < 1000000; i++)

            //// if (Interlocked.Exchange(ref n, 1) == 1)
            //{                
            //    Interlocked.Decrement(ref n);
            //   // n--;
            //}

            //up.Wait();
            //Console.WriteLine(n); 



            Task t1 = Task.Run(() =>
             {
                 if (value == 1)
                 {
                     // Removing the following line will change the output 
                     Thread.Sleep(3000);
                     // CompareExchange: if 3, change to 2
                     Interlocked.CompareExchange(ref value, 2, 3);
                     //Then the runtime guarantees that the compare and exchange are done together and 
                     //no other thread can cut in the middle of those operations.
                    // value = 2; 
                 }
             });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1,t2);
            Console.WriteLine(value); // Displays 2 

           // Task t1 starts running and sees that value is equal to 1. At the same time, t2 changes the 
           //value to 3 and then t1 changes it back to 2. To avoid this, you can use the following Inter
        }
    }
}
