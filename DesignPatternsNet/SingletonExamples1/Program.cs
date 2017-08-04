using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExamples1
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton1 = Singleton.Instance;
            var singleton2 = Singleton.Instance;

            Console.WriteLine(singleton1 == singleton2);
        }
    }
}

// Broken, non thread-save solution.
// Don't use this code.
public class Singleton
{
    private static volatile Singleton _instance;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}

