using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var tower = new ClockTower();
            var John = new Person("John", tower);
            var Mickle = new Person("Mickle", tower);
            tower.ChimeFivePM();
            tower.ChimeSixAM();
        }
    }
    public class Person
    {
        public string _name;
        private ClockTower _tower;
        public Person(string name, ClockTower tower)
        {
            _name = name;
            _tower = tower;
            //_tower.Chime += tower_Chime;
            //_tower.Chime += (object sender, ClockEventHandler args) => Console.WriteLine("{0} head the clock chime", _name);
            _tower.Chime += (object sender, ClockEventHandler args) =>
                {
                    Console.WriteLine("{0} head the clock chime", _name);
                    switch (args.Time)
                    {
                        case 6: Console.WriteLine("{0} is wakin up", args.Time);
                            break;
                        case 17: Console.WriteLine("{0} is wakin up ", args.Time);
                            break;
                    }
               };      
        }
        void tower_Chime()
        {
        }
    }


    public class ClockEventHandler : EventArgs
    {
        public int Time { get; set; }
    
    }
   // public delegate void ChimEventHandler(object sender,EventArgs args);

    public delegate void ChimEventHandler(object sender, ClockEventHandler args);

    public class ClockTower
    {
        public event ChimEventHandler Chime;
        public void ChimeFivePM()
        {
            Chime(this, new ClockEventHandler { Time=17});
        }
        public void ChimeSixAM()
        {
             Chime(this, new ClockEventHandler { Time=6});
        }

    }


}
