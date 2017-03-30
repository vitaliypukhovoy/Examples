using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person { Name = "John", Age = 33 };
            var p2 = new Person { Name = "Mickle", Age = 33 };
            p.SayHello(p2);
        }       
    }
    public static class Extention
    {
        public static void SayHello(this Person person, Person person2)
        {
            Console.WriteLine("{0} says hello {1}", person.Name, person2.Name);
        }
    }
}
