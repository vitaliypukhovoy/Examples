using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majority50PerItemOfArray
{
    class Program
    {
        //Given an unsorted array which has a number in the majority (a number appears more than 50% 
        //in the array), find that number?      
        static void Main(string[] args)
        {

            var arr =  new int [] {1,2,2,3,2,6,8,9,2,2,2,2,3,4,5};            
            var half = arr.Length/2;
            var dic = new Dictionary<int, int>();            
            foreach(var i in arr)
            {
                if (dic.ContainsKey(i))
                { 
                int newValue = dic[i]++;
                //AddOrUpdate(dic, i, newValue);                
                    //if (dic.Max(k => k.Value)>= half)
                    if(dic[i] >= half)
                    break;
                }
                else 
                {
                    dic.Add(i, 1);
                    //AddOrUpdate(dic, i, 1); 
                }
            }
                Console.WriteLine(dic.SingleOrDefault(i => i.Value == dic.Max(k => k.Value)).Key);
                Console.WriteLine(dic.Max(i=>i.Value));
                Console.ReadKey();
        }

        public static void AddOrUpdate(Dictionary<int, int> dic, int key, int newValue)
        {
           int val;         
           if( dic.TryGetValue(key, out val))
           {
               dic[key] = newValue;
           }
           else
           {
               dic.Add(key, newValue);
           }                
        
        }
    }
}
