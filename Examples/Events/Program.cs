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
        public Person(string name,ClockTower tower)
        {
            _name = name;
            _tower = tower;
            //_tower.Chime += tower_Chime;
            _tower.Chime += () => Console.WriteLine("{0} head the clock chime",_name);
        }
        void tower_Chime()
        {           
        }
    }

    public delegate void ChimEventHandler();

    public class ClockTower
    {
        public event ChimEventHandler Chime;
        public void ChimeFivePM()
        {
            Chime();        
        }
        public void ChimeSixAM()
        {
            Chime();
        }
       
    }


}
