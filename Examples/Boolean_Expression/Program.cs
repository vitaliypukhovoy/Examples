using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean_Expression
{
    class Program
    {
       
        static void Main(string[] args)
        {

            bool x = true;
            bool y = false;

            bool result1 = x || y;
            Console.WriteLine(result1); // Displays True           
            int value = 42;
            bool result = (0 < value) && (value < 100);
            Console.WriteLine(result);
            OrShortCircuit();

            Process(null);
        }

      static  public void OrShortCircuit() 
        { 
            bool x = true; 
            bool result = x || GetY(); 
        } 
 
      static  private bool GetY() 
        { 
            Console.WriteLine("This method doesn’t get called"); 
            return true; 
        }
       static public void Process(string input) 
        { 
            bool result = (input != null) && (input.StartsWith("v"));
            Console.WriteLine(result);
            // Do something with the result 
        }       // XOR operator
        //Left operand Right operand Result
        //True         True          False
        //True         False         True
        //False        True          True
        //False        False         False






    }
}
