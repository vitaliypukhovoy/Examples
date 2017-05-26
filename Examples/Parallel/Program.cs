using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  
using System.Threading;
using System.Data.Linq;
//using System.Threading.Tasks.Parallel;

namespace _Parallel
{
    class Program
    {        
        static void TestMethod()
        {

            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("For");
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ForEach");
            });                
        }

        static void TestMethod2()
        {

        ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
        {
            if (i == 500)
            {
                Console.WriteLine("Breaking loop= {0}",i);
                loopState.Break();
                //loopState.Stop();
            }
            return;
        });
            Console.WriteLine(result.LowestBreakIteration);
            
        }
        static void Main(string[] args)
        {

           // TestMethod();
            TestMethod2();
        }
    }
}
