using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExamples3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        static Singleton()
        {
            instance = new Singleton();
        }

        public static Singleton Instance
        {
            get { return instance; }
        }
    }
}
