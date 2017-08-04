﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExamples4
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
        private static readonly Lazy<Singleton> instance =
        new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private Singleton()
        {
        }
    }
}
