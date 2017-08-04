using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExamples2
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


    public class Singleton
    {
        private static volatile Singleton _instance;
        private static readonly object _lock = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
    }
}
