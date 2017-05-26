using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);
            //var parallelResult = numbers.AsParallel();
                var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential()
                .ToArray();              
            foreach (int i in parallelResult.Take(3))
                Console.WriteLine(i);
            //------------------------------------------------
            Console.WriteLine(new String('-',20)); 

            var parallelResult2 = numbers.AsParallel()
                .Where(i => i % 2 == 0);

            parallelResult2.ForAll(e => Console.WriteLine(e));

            Console.WriteLine(new String('-', 20));
            //-------------------------------------------------
            try 
            {
                var parallelResult1 = numbers.AsParallel() 
                    .Where(i => IsEven(i)); 
  
                parallelResult1.ForAll(e => Console.WriteLine(e)); 
            } 
            catch (AggregateException e) 
            { 
                Console.WriteLine("There where {0}   exceptions",  
                                    e.InnerExceptions.Count); 
            } 
        } 
  
        public static bool IsEven(int i) 
        { 
            if (i % 10 == 0) throw new ArgumentException("i");   
            return i % 2 == 0; 
        } 
        }    
}
