﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Synchrinizing
{
    class Program
    {
        static void Main(string[] args)
        {


            // int n = 0;
            ////object _lock = new object();   
            //var up = Task.Run(() => 
            //{
            //    for (int i = 0; i < 1000000; i++)
            //        //lock (_lock) 
            //        n++; 
            //});

            //for (int i = 0; i < 1000000; i++)
            //  //  lock (_lock) 
            //    n--; 
             
            //up.Wait();
            //Console.WriteLine(n);

            object lockA = new object(); 
            object lockB = new object(); 
  
            var up = Task.Run(() => 
            { 
                lock (lockA) 
                { 
                    Thread.Sleep(1000); 
                    lock (lockB) 
                    { 
                        Console.WriteLine("1. Locked A and B"); 
                    } 
                } 
            }); 
 
            lock (lockB) 
            { 
                lock (lockA) 
                { 
                    Console.WriteLine("2. Locked A and B"); 
                } 
            } 
            up.Wait(); 

        }
    }
}
