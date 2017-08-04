using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{

    //Purpose: Represent a method to be performed on the elements of an object structure. Visitor lets you
    //define a new method without changing the classes of the elements on which it operates.

    class Program
    {
        static void Main(string[] args)
        {

            // Create an engine...
            IEngine engine = new StandardEngine(1300);

            // Run diagnostics on the engine...
            engine.AcceptEngineVisitor(new EngineDiagnostics());

            // Run inventory on the engine...
            engine.AcceptEngineVisitor(new EngineInventory());

            Console.Read();
        }
    }

    public interface IEngineVisitor
    {
        void Visit(Camshaft camshaft);
        void Visit(IEngine engine);
        void Visit(Piston piston);
        void Visit(SparkPlug sparkPlug);
    }


    public class Camshaft
    {
        public virtual void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Piston
    {
        public virtual void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class SparkPlug
    {
        public virtual void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IEngine
    {
        int Size { get; }
        bool Turbo { get; }

        void AcceptEngineVisitor(IEngineVisitor visitor);
    }

    public abstract class AbstractEngine : IEngine
    {
        private int size;
        private bool turbo;

        private Camshaft camshaft;
        private Piston piston;
        private SparkPlug[] sparkPlugs;

        public AbstractEngine(int size, bool turbo)
        {
            this.size = size;
            this.turbo = turbo;

            // Create a camshaft, piston and 4 spark plugs...
            camshaft = new Camshaft();
            piston = new Piston();
            sparkPlugs = new SparkPlug[]
										{
											new SparkPlug(), new SparkPlug(),
											new SparkPlug(), new SparkPlug()
										};
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

        public virtual void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            // Visit each component first...
            camshaft.AcceptEngineVisitor(visitor);
            piston.AcceptEngineVisitor(visitor);
            foreach (SparkPlug eachSparkPlug in sparkPlugs)
            {
                eachSparkPlug.AcceptEngineVisitor(visitor);
            }

            // Now visit the receiver...
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return this.GetType().Name + " (" + size + ")";
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

    public class EngineDiagnostics : IEngineVisitor
    {
        public virtual void Visit(Camshaft camshaft)
        {
            Console.WriteLine("Diagnosing the camshaft");
        }

        public virtual void Visit(IEngine engine)
        {
            Console.WriteLine("Diagnosing the engine");
        }

        public virtual void Visit(Piston piston)
        {
            Console.WriteLine("Diagnosing the piston");
        }

        public virtual void Visit(SparkPlug sparkPlug)
        {
            Console.WriteLine("Diagnosing a single spark plug");
        }

    }

    public class EngineInventory : IEngineVisitor
    {
        private int camshaftCount;
        private int pistonCount;
        private int sparkPlugCount;

        public EngineInventory()
        {
            camshaftCount = 0;
            pistonCount = 0;
            sparkPlugCount = 0;
        }

        public virtual void Visit(Camshaft camshaft)
        {
            camshaftCount++;
        }

        public virtual void Visit(IEngine engine)
        {
            Console.WriteLine("The engine has: " +
                                    camshaftCount + " camshaft(s), " +
                                    pistonCount + " piston(s), and " +
                                    sparkPlugCount + " spark plug(s)");
        }

        public virtual void Visit(Piston piston)
        {
            pistonCount++;
        }

        public virtual void Visit(SparkPlug sparkPlug)
        {
            sparkPlugCount++;
        }

    }
}
