using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a blue saloon car
             IVehicle myCar = new Saloon(new StandardEngine(1300));
           // AbstractVehicle myCar = new Saloon(new StandardEngine(1300)); 
            myCar.Paint(VehicleColour.Blue);
            Console.WriteLine(myCar);

            // Add air-conditioning to the car...
            myCar = new AirConditionedVehicle(myCar);
            Console.WriteLine(myCar);

            // Now add alloy wheels...
            myCar = new AlloyWheeledVehicle(myCar);
            Console.WriteLine(myCar);

            // Now add leather seats...
            myCar = new LeatherSeatedVehicle(myCar);
            Console.WriteLine(myCar);

            // Now add metallic paint...
            myCar = new MetallicPaintedVehicle(myCar);
            Console.WriteLine(myCar);

            // Now add satellite navigation
            myCar = new SatNavVehicle(myCar);
            Console.WriteLine(myCar);

            Console.Read();
        }
    }

    
    public interface IVehicle
    {
        IEngine Engine { get; }
        VehicleColour Colour { get; }
        void Paint(VehicleColour colour);

        int Price { get; }
    }

    public interface IEngine
    {
        int Size { get; }
        bool Turbo { get; }
    }

    public enum VehicleColour
    {
        Unpainted, Blue, Black, Green,
        Red, Silver, White, Yellow
    }
    public abstract class AbstractVehicle : IVehicle
    {
        private IEngine engine;
        private VehicleColour colour;

        public AbstractVehicle(IEngine engine)
            : this(engine, VehicleColour.Unpainted)
        {
        }

        public AbstractVehicle(IEngine engine, VehicleColour colour)
        {
            this.engine = engine;
            this.colour = colour;
        }

        public virtual IEngine Engine
        {
            get
            {
                return engine;
            }
        }

        public virtual VehicleColour Colour
        {
            get
            {
                return colour;
            }
        }

        public virtual void Paint(VehicleColour colour)
        {
            this.colour = colour;
        }

        public abstract int Price { get; }

        public override string ToString()
        {
            return this.GetType().Name + " (" + engine + ", " + colour +
                ", price " + Price + ")";
        }

    }


    public abstract class AbstractEngine : IEngine
    {

        private int size;
        private bool turbo;


        public AbstractEngine(int size, bool turbo)
        {
            this.size = size;
            this.turbo = turbo;
        }

        public virtual int Size
        {
            get
            {
                return size;
            }
        }

        public virtual bool Turbo
        {
            get
            {
                return turbo;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name + " (" + size + ")";
        }

    }

    public abstract class AbstractVehicleOption : AbstractVehicle
    {
        protected internal IVehicle decoratedVehicle;

        public AbstractVehicleOption(IVehicle vehicle)
            : base(vehicle.Engine, vehicle.Colour)
        {
            decoratedVehicle = vehicle;
        }
    }
    public abstract class AbstractCar : AbstractVehicle
    {

        public AbstractCar(IEngine engine)
            : this(engine, VehicleColour.Unpainted)
        {
        }

        public AbstractCar(IEngine engine, VehicleColour colour)
            : base(engine, colour)
        {
        }

    }

    public class Saloon : AbstractCar
    {
        public Saloon(IEngine engine)
            : this(engine, VehicleColour.Unpainted)
        {
        }

        public Saloon(IEngine engine, VehicleColour colour)
            : base(engine, colour)
        {
        }

        public override int Price
        {
            get
            {
                return 6000;
            }
        }
    }

    public class StandardEngine : AbstractEngine
    {

        public StandardEngine(int size)
            : base(size, false)
        {
            // not turbocharged
        }

    }

    public class AirConditionedVehicle : AbstractVehicleOption
    {
        public AirConditionedVehicle(IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Price
        {
            get
            {
                return decoratedVehicle.Price + 600;
            }
        }

        public virtual int Temperature
        {
            set
            {
                // code to set the temperature...
            }
        }
    }

    public class AlloyWheeledVehicle : AbstractVehicleOption
    {
        public AlloyWheeledVehicle(IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Price
        {
            get
            {
                return decoratedVehicle.Price + 250;
            }
        }
    }

    public class LeatherSeatedVehicle : AbstractVehicleOption
    {
        public LeatherSeatedVehicle(IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Price
        {
            get
            {
                return decoratedVehicle.Price + 1200;
            }
        }
    }

    public class MetallicPaintedVehicle : AbstractVehicleOption
    {
        public MetallicPaintedVehicle(IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Price
        {
            get
            {
                return decoratedVehicle.Price + 750;
            }
        }
    }

    public class SatNavVehicle : AbstractVehicleOption
    {
        public SatNavVehicle(IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Price
        {
            get
            {
                return decoratedVehicle.Price + 1500;
            }
        }

        public virtual string Destination
        {
            set
            {
                // code to set the destination...
            }
        }

    }


}
