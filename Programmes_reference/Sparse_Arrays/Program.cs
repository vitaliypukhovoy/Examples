using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparse_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int tmp = 0;
            List<string> list = new List<string>();
           // Dictionary<Tuple<int, string>, int> dic = new Dictionary<Tuple<int, string>, int>();
            Dictionary<Tuple<int, string>, int> dic = new Dictionary<Tuple<int, string>, int>();

            //string line;
            //while((line = Console.ReadLine()) != null && line != "")
            //{
            //    list.Add(line); 
            //}
            list.Add("4");
            list.Add("aba");
            list.Add("baba");
            list.Add("aba");
            list.Add("xzxb");
            list.Add("3");
            list.Add("aba");
            list.Add("xzxb");
            list.Add("ab");

            list.ForEach(n =>
            {
                bool a = int.TryParse(n, out result);
                if (a == true)
                {
                    tmp = int.Parse(n);
                }
                else
                {
                    if (dic.ContainsKey(Tuple.Create(tmp, n)))
                    {
                        dic[Tuple.Create(tmp, n)]++;
                    }
                    else
                    {
                        dic.Add(Tuple.Create(tmp, n), 1);
                    }
                }
            });

            var sortDict = dic
                 .GroupBy(i => i.Key.Item2)
                 .Select(group => new { elem = group.Key, count = group.Count(), items = group.ToList() })
                 .ToList();
            string item = null;
            foreach (var j in sortDict)
            {

                if (j.items.Count > 1)
                {
                    Console.WriteLine(j.items.Max(i => i.Value));
                    item = j.elem;
                }
                else if (j.items.Count == 1 && j.items[0].Value > 1)
                    Console.WriteLine(j.items[0].Value);

                else if (j.elem.Contains(item))
                    continue;
                else if (j.items.Count == 1 && j.items[0].Value == 1)
                    Console.WriteLine(0);
                else if (j.items.Count == 1 && j.items[0].Value >= 1)
                    Console.WriteLine(0);
            }
            Console.ReadLine();
        }
    }
}

//4
//aba
//baba
//aba
//xzxb
//3
//aba
//xzxb
//ab
//Sample Output

//2
//1
//0
