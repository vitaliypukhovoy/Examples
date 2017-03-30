using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Method();
        }
       static void Method()
        {
            var horse = new Animal();
            var type = horse.GetType();
            var method = type.GetMethod("Speak");
            Console.WriteLine(method);
            var value = (string)method.Invoke(horse, null);   // value=”hello”;
            Console.WriteLine(value);
        }
    }
    public class Animal
    {
	    public string Speak() { return "hello"; }
    }
}
