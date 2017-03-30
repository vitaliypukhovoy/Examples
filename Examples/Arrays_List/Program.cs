using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>
           {
           "Jeremy",
           "Jason",
           "Zed"                                 
           };
            names[1] = "Jessica";
            names.Add("Caleb");
            names.AddRange(new[] { "Philip", "Patrick" });
            names.Insert(0, "Kim");
            names.Add("Jeremy");
            //  //names.InsertRange(0, new[] { });

            var index = names.IndexOf("Jeremy");
            //  //names.LastIndexOf();
            var contains = names.Contains("Jaffrey");
            var nameWithJ = names.Find(s => s.StartsWith("J"));
            var namesWithJ = names.FindAll(s => s.StartsWith("J"));
            //  //names.FindIndex();
            //  //names.FindLast()
            //  //names.FindLastIndex();
            var chars = names.ConvertAll(s => s[0]);
            names.ForEach(s => Console.WriteLine(s));
            Console.WriteLine("--------------");
            names.Remove("Jeremy");
            names.RemoveAll(s => s == "Jeremy");
            names.RemoveAt(0);
            names.RemoveRange(0, names.Count);
            names.Clear();


            var people = new People();
            //   var names2 = (List<string>)people.Names;
            var names2 = new List<string>(people.Names);
            names2.Remove("Jeremy");
            names2.ForEach(s => Console.WriteLine(s));
            Console.ReadLine();
                
        }
    }

        public class People
        {
            private readonly List<string> _names = new List<string>();

            public People()
            {
                _names.AddRange(new[] {
                "Jeremy",
                "Jason",
                "Zed"
            });
            }

            public IEnumerable<string> Names
            {
                get { return _names.ToArray(); }
            }
        }    
}
