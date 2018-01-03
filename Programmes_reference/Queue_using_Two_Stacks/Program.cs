using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_using_Two_Stacks
{

    class Solution
    {
        static void Main(String[] args)
        {
            Stack<int> st1 = new Stack<int>();
            Stack<int> st2 = new Stack<int>();
            List<List<int>> list = new List<List<int>>();

            string line;
            while ((line = Console.ReadLine()) != null && line != null)
            {
                list.Add(line.Split(' ').Select(Int32.Parse).ToList());              
            }
            
            
            list.Reverse();
                        
            foreach (var item in list)
            {
                st1.Push(item[0]);
                if (item.FindIndex(i => i == 1) != -1)
                    st2.Push(item[1]);                
                else
                    st2.Push(0);                
            }
            
            st1.Pop();
            st2.Pop();

            int tmp = 0; ;
            for (int i = 0; i < st1.Count; i++)
            {
                if(st1.Peek() ==1)
                {
                   tmp = st2.Peek(); 
                }
                else if(st1.Peek() == 2)
                        {
                            st2.Peek();
                            st2.Peek();
                        }

                else if (st1.Peek() == 3)
                {

                    Console.WriteLine(tmp);
                
                }
                 
                //Console.WriteLine(st1.ElementAt(i) + " " + st2.ElementAt(i));

            }

        }

    }
}


//10
//1 42
//2
//1 14
//3
//1 28
//3
//1 60
//1 78
//2
//2


