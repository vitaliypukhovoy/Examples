using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_events
{
    class Program
    {
        static void Main(string[] args)
        {
            var create = new CreateEvent();
            create.CreateAndRaise();
        }

        //public class Pub
        //{
        //    public Action OnChange { get; set; }

        //    public void Raise()
        //    {
        //        if (OnChange != null)
        //        {
        //            OnChange();
        //        }
        //    }
        //}

        //public class CreateEvent
        //{
        //    public void CreateAndRaise()
        //    {
        //        Pub p = new Pub();
        //        p.OnChange += () => Console.WriteLine("Event raised to method 1");
        //        p.OnChange += () => Console.WriteLine("Event raised to method 2");
        //        p.Raise();
        //    }
        //}
        public class MyArgs : EventArgs 
        { 
            public MyArgs(int value) 
            { 
                Value = value; 
            } 
 
            public int Value { get; set; } 
        } 
 
        public class Pub 
        { 
            public event EventHandler<MyArgs> OnChange = delegate { }; 
 
            public void Raise() 
            { 
                OnChange(this, new MyArgs(42)); 
            } 
        }


        public class CreateEvent
        {
            public void CreateAndRaise()
            {
                Pub p = new Pub();

                p.OnChange += (sender, e)
                    => Console.WriteLine("Event raised: {0}", e.Value);

                p.Raise();
            }
        }
    }
}
