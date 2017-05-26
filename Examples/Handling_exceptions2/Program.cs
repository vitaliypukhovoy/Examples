using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;

namespace Handling_exceptions2
{
    class Program
    {          
        static void Main(string[] args)
        {
            ExceptionDispatchInfo possibleException = null;
            try 
            { 
                string s = Console.ReadLine(); 
                int.Parse(s); 
            } 
            catch (FormatException ex) 
            { 
                possibleException =  ExceptionDispatchInfo.Capture(ex); 
            }

            if (possibleException != null)
            {
                possibleException.Throw();
            }
        }
    }
}
