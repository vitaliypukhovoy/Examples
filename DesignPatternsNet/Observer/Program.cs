using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
             Speedometer speedo = new Speedometer();

            // Create a monitor...
            SpeedMonitor monitor = new SpeedMonitor(speedo);

            // Add automatic gearbox as an observer
            AutomaticGearbox auto = new AutomaticGearbox(speedo);

            // Drive at different speeds...
            speedo.CurrentSpeed = 50;
            speedo.CurrentSpeed = 70;
            speedo.CurrentSpeed = 40;
            speedo.CurrentSpeed = 100;
            speedo.CurrentSpeed = 69;

            Console.Read();        

        }
    }
    public class Speedometer
    {
        public event EventHandler ValueChanged;
        private int currentSpeed;

        public Speedometer()
        {
            currentSpeed = 0;
        }

        public virtual int CurrentSpeed
        {
            set
            {
                currentSpeed = value;

                // Tell all observers so they know value has changed...
                OnValueChanged();
            }
            get
            {
                return currentSpeed;
            }
        }

        protected void OnValueChanged()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

    }
    public class SpeedMonitor
    {
        public const int SPEED_TO_ALERT = 70;

        public SpeedMonitor(Speedometer speedo)
        {
            speedo.ValueChanged += ValueHasChanged;
        }

        private void ValueHasChanged(Object sender, EventArgs e)
        {
            Speedometer speedo = (Speedometer)sender;
            if (speedo.CurrentSpeed > SPEED_TO_ALERT)
            {
                Console.WriteLine("** ALERT ** Driving too fast! ("
                                        + speedo.CurrentSpeed + ")");

            }
            else
            {
                Console.WriteLine("... nice and steady ... ("
                                        + speedo.CurrentSpeed + ")");
            }
        }
    }

    public class AutomaticGearbox
    {
        public AutomaticGearbox(Speedometer speedo)
        {
            speedo.ValueChanged += ValueHasChanged;
        }

        private void ValueHasChanged(Object sender, EventArgs e)
        {
            Speedometer speedo = (Speedometer)sender;
            if (speedo.CurrentSpeed <= 10)
            {
                Console.WriteLine("Now in first gear");

            }
            else if (speedo.CurrentSpeed <= 20)
            {
                Console.WriteLine("Now in second gear");

            }
            else if (speedo.CurrentSpeed <= 30)
            {
                Console.WriteLine("Now in third gear");

            }
            else
            {
                Console.WriteLine("Now in fourth gear");
            }
        }
    }

}
