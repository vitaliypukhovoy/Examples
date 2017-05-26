using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace events_and_callback
{
    class Program
    {
       static public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }

       static public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        } 
        public delegate void Del(); 
        static void Main(string[] args)
        {
            UseDelegate();

            //A multicast delegate
            Del d = MethodOne;
            d += MethodTwo;
            d();
            int invocationCount = d.GetInvocationList().GetLength(0); // how many methods a multicast delegate is going to cal
            Console.WriteLine(invocationCount);
            UseCovariance();
        }

        //Using a delegate
        public delegate int Calculate(int x, int y); 
 
       static public int Add(int x, int y) { return x + y; } 
       static public int Multiply(int x, int y) { return x * y; }

        static public void UseDelegate()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4)); // Displays 7 

            calc = Multiply;
            Console.WriteLine(calc(3, 4)); // Displays 12 
        }
        //Covariance with delegates
        //=======================================================
       public delegate TextWriter CovarianceDel(); 
 
       static public StreamWriter MethodStream() { return null; } 
       static public StringWriter MethodString() { return null; } 
 
        static public  void UseCovariance(){
        CovarianceDel del; 
        del = MethodStream; 
        del = MethodString;
        }

      
        static void DoSomething(TextWriter tw) { } 
        public delegate void ContravarianceDel(StreamWriter tw);

        ContravarianceDel del = DoSomething;

    }
}

