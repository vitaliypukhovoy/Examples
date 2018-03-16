using System;
using System.Collections.Generic;
using System.Text;

namespace Operator_ternal_null_coalescing
{
    class Program
    {
        static Customer customer;
        static int amount;

        //2.  Sometimes the conditional and null-coalescing operators can make the code confusing, par-
        //    ticularly if their operands are complicated expressions. Rewrite the following code to use if 
        //    statements instead of ?: and ??.
        static void Main(string[] args)
        {
            var ForeColor = (amount < 0) ? Color.Red : Color.Blue;
            Customer orderedBy = customer ?? new Customer();

            if (amount < 0)
            {
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Blue;
            }


            if (customer != null)
            {
                orderedBy = customer;
            }
            else
            {
                orderedBy = new Customer();
            }
        }
    }

    public class Customer
    {

    }

    enum Color
    {
        Red = 1,
        Blue = 2,
        Green = 3
    }
}
