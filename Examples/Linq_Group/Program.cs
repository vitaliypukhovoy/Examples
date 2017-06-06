using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] source = { "abc", "hello", "def", "there", "four" };
            // This time "values" will be an IEnumerable<char>, the first character of each 
            // source string contributing to the group 
            var groups = source.GroupBy(x => x.Length,
                                        x => x, //x[0], 
                                        (key, values) => key + ":" + string.Join(";", values));
            foreach (var item in groups)
            {
                Console.WriteLine(item);
            }


            List<Person> persons = new List<Person>
         {
             new Person { PersonID = 1, car = "Ferrari" },
             new Person { PersonID = 2, car = "BMW" },
             new Person { PersonID = 3, car = "Audi" }
         };
            //persons[0] = new Person { PersonID = 1, car = "Ferrari" };
            //persons[1] = new Person { PersonID = 1, car = "BMW" };
            //persons[2] = new Person { PersonID = 2, car = "Audi" };

            //var results= persons.GroupBy(n => new { n.PersonID, n.car})
            //    .Select(g => new {
            //                   g.Key.PersonID,
            //                   g.Key.car}).ToList();

            var results = persons.GroupBy(p => p.PersonID,
                               p => p.car,
                               (key, g) => new
                               {
                                   PersonID = key,
                                   Cars = g.ToList()
                               }
                              );
            foreach (var item in persons)
            {
                Console.WriteLine("{0}  {1}", item.PersonID, item.car);
            }

        }

        class Person
        {
            public int PersonID;
            public string car;
        }




    }

}
