using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace CocurrentCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------------------------------
            Console.Write(new String('-', 20)); Console.WriteLine("ConcurrentDictionary {0}", new String('-', 20));

            var dict = new ConcurrentDictionary<string, int>(); 
                if (dict.TryAdd("k1", 42)) 
                { 
                    Console.WriteLine("Added"); 
                }
                if (dict.TryUpdate("k1", 21, 42)) 
                { 

                    Console.WriteLine("42 updated to 21"); 
                }
                dict["k1"] = 42; // Overwrite unconditionally 
 
                int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2); 
                int r2 = dict.GetOrAdd("k2", 3);


            //-----------------------------------------------------------
            Console.Write(new String('-', 20)); Console.WriteLine("ConcurrentStack {0}", new String('-', 20));


            ConcurrentStack<int> stack = new ConcurrentStack<int>();  
            stack.Push(42); 
 
            int res; 
            if (stack.TryPop(out res)) 
                Console.WriteLine("Popped: {0}", res); 
 
            stack.PushRange(new int[] { 1, 2, 3 }); 
 
            int[] values = new int[2]; 
            stack.TryPopRange(values);
 
            foreach (int i in values) 
                Console.WriteLine(i);
           
            //-----------------------------------------------------------            
            Console.Write(new String('-', 20)); Console.WriteLine("ConcurrentQueue {0}", new String('-', 20));

            ConcurrentQueue<int> queue = new ConcurrentQueue<int>(); 
            queue.Enqueue(42); 
 
            int res2; 
            if (queue.TryDequeue(out res2)) 
                Console.WriteLine("Dequeued: {0}", res2); 


            //-----------------------------------------------------------            
            Console.Write(new String('-', 20)); Console.WriteLine("ConcurrentBag1 {0}", new String('-', 20));


            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(44);
                Thread.Sleep(1000);
                bag.Add(22);
            });
            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();
           
            
            //-----------------------------------------------------------
            Console.Write(new String('-', 20)); Console.WriteLine("ConcurrentBag2 {0}", new String('-', 20));


           // ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            Console.WriteLine("Count={0}", bag.Count);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            Console.WriteLine("Count={0}", bag.Count);


           // One thing to keep in mind is that the TryPeek method is not very useful in a multithreaded 
           // environment. It could be that another thread removes the item before you can access it

            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);

            Console.WriteLine("Count={0}", bag.Count);



            //-----------------------------------------------------------
            Console.Write(new String('-', 20)); Console.WriteLine("BlockingCollection {0}", new String('-', 20));



            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                //while (true)
                //{                  
                //    Console.WriteLine(col.Take());// take and remove item
                   
                //}

                foreach (string v in col)
                    Console.WriteLine(v);

                //foreach (string v in col.GetConsumingEnumerable())
                //    Console.WriteLine(v); 
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                   
                    Console.WriteLine("Count={0}", col.Count);
                }
            });
            write.Wait();                                  
        }
    }
}