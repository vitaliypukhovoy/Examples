using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method1
{
    //Purpose:  Define  an  interface  for  creating  an  object,  but  let  subclasses  decide  which  class  to
    //instantiate.   
    // FactoryBase: this is an abstract class for the concrete factory classes which will return new objects. 
    //              In some cases it could be a simple interface containing the signature for the factory method. This class contains FactoryMethod which returns a ProductBase object.
    //ConcreteFactory: represents concrete implementation of factory. Usually this class overrides the generating
    //                FactoryMethod and returns a ConcreteProduct object.
    //ProductBase: this is a base class for all products created by concrete factories. In some cases it could 
    //               be a simple interface.
    //ConcreteProduct: this is a concrete implementation of ProducBase. Concrete product classes can include specific    //              functionality. This objects are created by factory methods.
    class Program
    {
        static void Main(string[] args)
        {
            FactoryBase factory = new ConcreteFactory();
            ProductBase product = factory.FactoryMethod(1);
            product.ShowInfo();
            product = factory.FactoryMethod(2);
            product.ShowInfo();
        }
    }

    public abstract class FactoryBase
    {
        public abstract ProductBase FactoryMethod(int type);
    }

    public class ConcreteFactory : FactoryBase
    {
        public override ProductBase FactoryMethod(int type)
        {
            switch (type)
            {
                case 1:
                    return new ConcreteProduct1();
                case 2:
                    return new ConcreteProduct2();
                default:
                    throw new ArgumentException("Invalid type.", "type");
            }
        }
    }


    public abstract class ProductBase
    {
        public abstract void ShowInfo();
    }

    public class ConcreteProduct1 : ProductBase
    {
        public override void ShowInfo()
        {
            Console.WriteLine("Product1");
        }
    }

    public class ConcreteProduct2 : ProductBase
    {
        public override void ShowInfo()
        {
            Console.WriteLine("Product2");
        }
    }
}
