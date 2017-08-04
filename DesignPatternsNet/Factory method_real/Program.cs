using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_real
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory factory = GetFactory("Factory_method_real.LincolnAviatorFactory");

            var lincolnAviator = factory.CreateVehicle();

            lincolnAviator.ShowInfo();

            factory = GetFactory("Factory_method_real.FordExplorerFactory");

            var fordExplorer = factory.CreateVehicle();

            fordExplorer.ShowInfo();
        }

        static IVehicleFactory GetFactory(string factoryName)
        {
            return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as IVehicleFactory;
        }
    }

    public interface IVehicleFactory
    {
        Vehicle CreateVehicle();
    }

    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Body { get; set; }
        public int Doors { get; set; }
        public List<string> Accessories = new List<string>();

        public abstract void ShowInfo();
    }

    public class FordExplorerFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new FordExplorer();
        }
    }

    public class LincolnAviatorFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new LincolnAviator("Lincoln Aviator",
                "4.6 L DOHC Modular V8",
                "5-speed automatic",
                "SUV", 4);
        }
    }

    public class FordExplorer : Vehicle
    {
        public FordExplorer()
        {
            Model = "Ford Explorer";
            Engine = "4.0 L Cologne V6";
            Transmission = "5-speed M50D-R1 manual";
            Body = "SUV";
            Doors = 5;
            Accessories.Add("Car Cover");
            Accessories.Add("Sun Shade");
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Engine: {0}", Engine);
            Console.WriteLine("Body: {0}", Body);
            Console.WriteLine("Doors: {0}", Doors);
            Console.WriteLine("Transmission: {0}", Transmission);
            Console.WriteLine("Accessories:");
            foreach (var accessory in Accessories)
            {
                Console.WriteLine("\t{0}", accessory);
            }
        }
    }

    public class LincolnAviator : Vehicle
    {
        public LincolnAviator(string model, string engine, string transmission, string body, int doors)
        {
            Model = model;
            Engine = engine;
            Transmission = transmission;
            Body = body;
            Doors = doors;
            Accessories.Add("Leather Look Seat Covers");
            Accessories.Add("Chequered Plate Racing Floor");
            Accessories.Add("4x 200 Watt Coaxial Speekers");
            Accessories.Add("500 Watt Bass Subwoofer");
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Engine: {0}", Engine);
            Console.WriteLine("Body: {0}", Body);
            Console.WriteLine("Doors: {0}", Doors);
            Console.WriteLine("Transmission: {0}", Transmission);
            Console.WriteLine("Accessories:");
            foreach (var accessory in Accessories)
            {
                Console.WriteLine("\t{0}", accessory);
            }
        }
    }
}
