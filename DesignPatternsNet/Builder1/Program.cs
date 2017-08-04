using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder1
{
    //Purpose:  Separate  the  construction  of  a  complex  object  from  its  representation  so  that  the  same
    //construction process can create different representations

    //Product: represents the complex object that is being built.
    //Builder: this is base class (or interface) for all builders and defines a steps that must be taken in order to correctly create an complex object (product). Generally each step is an abstract method that is overriden by concrete implementation.
    //ConcreteBuilder: provides implementation for builder. Builder is an object able to create other complex objects (products).
    //Director: represents class that controls algorithm used for creation of complex object.

    class Program
    {
        static void Main(string[] args)
        {
            Builder b1 = new ConcreteBuilder1();

            Director.Construct(b1);
            var p1 = b1.GetResult();
            p1.Show();
        }
    }

    static class Director
    {
        public static void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    class ConcreteBuilder1 : Builder
    {
        private readonly Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("Part A");
        }

        public override void BuildPartB()
        {
            _product.Add("Part B");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class Product
    {
        private readonly List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("Parts:");
            foreach (string part in _parts)
            Console.WriteLine("\t" + part);
        }
    }
}
