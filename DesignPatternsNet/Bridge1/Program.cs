using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge1
{
    class BridgePattern
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Bridge Pattern\n");
            Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
            Console.WriteLine(new Abstraction(new ImplementationB()).Operation());
        }

        class Abstraction
        {
            Bridge bridge;
            public Abstraction(Bridge implementation)
            {
                bridge = implementation;
            }
            public string Operation()
            {
                return "Abstraction" + " <<< BRIDGE >>>> " + bridge.OperationImp();
            }
        }

        interface Bridge
        {
            string OperationImp();
        }

        class ImplementationA : Bridge
        {
            public string OperationImp()
            {
                return "ImplementationA";
            }
        }

        class ImplementationB : Bridge
        {
            public string OperationImp()
            {
                return "ImplementationB";
            }
        }

    }
}
