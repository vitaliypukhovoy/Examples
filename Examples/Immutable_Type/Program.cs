using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts ;

namespace Immutable_Type
{
    class Program
    {
        static void Main(string[] args)
        {

            //Inefficient version using immutable String 
            //String output = "Some text";
            //int count = 100;
            //for (int i = 0; i < count; i++)
            //{
            //    output += i;
            //}
            //return output; 
        }
    }
   public class ProductPile
      {
        public string ProductName { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
 
        public ProductPile(string productName, int amount, decimal price)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(productName));
            Contract.Requires(amount >= 0);
            Contract.Requires(price > 0);
 
            this.ProductName = productName;
            this.Amount = amount;
            this.Price = price;
        }
 
        public ProductPile SubtractOne()
        {
            return new ProductPile(ProductName, Amount-1 , Price);
        }
    }
}
