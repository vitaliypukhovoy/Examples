using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ref_for_Object
{
    public class MyObject
    {
        public string text = "text";    
    }
    class Program
    {
           public static void Main(string[]args)
            {

                //string a = "Hello";  // Set a to reference the string "Hello"
                //string b = a;        // Set b to reference the same string as a
                //b = "Hi";

                string a = "hello world";
                string b = a;
                a = "hello";

                Console.WriteLine("{0}, {1}", a, b);
                Console.WriteLine(a == b);
                Console.WriteLine(object.ReferenceEquals(a, b));

                MyObject obj = new MyObject();
                int i=0;
                AddSomething(ref i);
                AddSomething(ref i);
                AddSomething(ref i);
                AddSomething(ref i);


                string mystr = "Hello";
                AddSomeText(ref mystr);

                mystr += "1";
                Console.WriteLine(mystr);


                Console.WriteLine("i = {0}", i);

                MyMethod(ref obj);
                obj.text = "text2";

                Console.WriteLine(obj.text);
            }


            public static void AddSomeText(ref string str)
            {
                str+= " World!";
            }


            public static void AddSomething(ref int ii)
            {
                ii+=1;
            }       

       static private void MyMethod(ref MyObject obj)
        {
            obj.text = "text1";        
        }

       static private void TestI(ref string str)
       {
           str = "after passing";
       }

    }
}
