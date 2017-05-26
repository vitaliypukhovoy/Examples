using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_class
{
    class Program
    {
        static void Main(string[] args)
        {
            PartialClass instance = new PartialClass();
            instance.MethodFromPart1();                
            instance.MethodFromPart2();
        }
    }

    interface IPerson
    {
         void MethodFromPart1();
    }
    interface IStudent
    {
         void MethodFromPart2();
    }

    class PartialClass : IPerson, IStudent
    {
        public void MethodFromPart1()
        {
            Console.WriteLine("I Part");
        }
        public void MethodFromPart2()
        {
            Console.WriteLine("II Part");
        }    
    }

    //  partial class PartialClass
    //    {
    //        public void MethodFromPart1()
    //        {
    //            Console.WriteLine("I Part");
    //        }
    //    }
 
    //partial class PartialClass
    //    {
    //        public void MethodFromPart2()
    //        {
    //            Console.WriteLine("II Part");
    //        }
    //    } 
    }
