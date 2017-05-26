using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {

            Task longRunning = Task.Run(() => 
            { 
                Thread.Sleep(10000); 
            }); 
 
            int index = Task.WaitAny(new[] { longRunning }, 2000); 
 
            if (index == -1) 
                Console.WriteLine("Task timed out");


            CancellationTokenSource cancellationTokenSource =
           new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
                {
                    while (!token.IsCancellationRequested) //!token.IsCancellationRequested 
                    {
                        // token.ThrowIfCancellationRequested();
                        Console.Write("*");
                        Thread.Sleep(100);
                    }
                    token.ThrowIfCancellationRequested();
                }, token).ContinueWith((t) =>
                {
                    //  t.Exception.Handle((e) => true); 
                    Console.WriteLine("You have canceled the task");
                }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            task.Wait();
            Console.ReadLine();  

            ////try
            ////{
            ////    task.Wait();
            ////}
            ////catch (AggregateException e)
            ////{
            ////    foreach (var v in e.InnerExceptions)
            ////        Console.WriteLine(e.Message + " " + v.Message);
            ////}
            ////Console.ReadLine();


        //    Task task = Task.Run(() =>  
        //    { 
        //        while(!token.IsCancellationRequested)    
        //        {
        //            Console.Write("*"); 
        //            Thread.Sleep(100); 
        //        }
        //    }, token);

        //    try
        //    {
        //        Console.WriteLine("Press enter to stop the task");
        //        Console.ReadLine();
        //        cancellationTokenSource.Cancel();
        //        task.Wait();
                
        //    }
        //    catch (AggregateException e)
        //    {
        //        Console.WriteLine(e.InnerExceptions[0].Message);
        //    } 
        //    Console.WriteLine("Press enter to end the application"); 
        //    Console.ReadLine();
        }
    }
}
