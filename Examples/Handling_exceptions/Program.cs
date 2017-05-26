using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handling_exceptions
{
    class Program
    {
     public static void Main() 
        {

            while (true)
            {
                string s = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(s)) break ;

                try
                {
                    int i = int.Parse(s);
                    if (i == 22) Environment.FailFast("Special number entered");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("You need to enter a value");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("{0} is not a valid number. Please try again", s);
                    Console.WriteLine("Message: {0}", e.Message);
                    Console.WriteLine("StackTrace: {0}", e.StackTrace);
                    Console.WriteLine("HelpLink: {0}", e.HelpLink);
                    Console.WriteLine("InnerException: {0}", e.InnerException);
                    Console.WriteLine("TargetSite: {0}", e.TargetSite);
                    Console.WriteLine("Source: {0}", e.Source);

                }
                finally
                {
                    Console.WriteLine("Program complete.");
                }
            }


        }

       //  try
       //  {
       // // do something
       //   }
       // catch(Exception logExp)
       //  {
       //log(logExp)
       //    throw;
       //   }

    }
}


