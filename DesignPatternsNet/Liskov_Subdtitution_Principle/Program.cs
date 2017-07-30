using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.

namespace Liskov_Subdtitution_Principle
{
    public interface ISearchPovider
    {
        IList<T> Search<T>(Criteria criteria);        
    }

    public interface IRepository<T>
    {
        T GetById(string id);
        void Delete(T);
        void Save(T);
    }

    public class ProductRepository : ISearchPovider, IRepository<Product>
    {

         public IList<Product> Search(Product criteria)
         {
              return null;
         }

        public  Product GetById(string id)
        {
            return null;
        }

          void Delete(Product product)
          {                    
          }

         void Save(Product product)
         {
         }
    }

    public class SearchController //: Controller
    {
    private ISearchPovider searchProvider;
      public SearchController(ISearchPovider searchProvider)
      {
          this.searchProvider = searchProvider;
      }

        public ActionResult  SearchForProduct(Criteria criteria)
        {

            IList<Product> products =   searchProvider.Search<Product>(criteria)
            return view(products)
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Product
    {
     public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
        public int MyProperty4 { get; set; }
        
    }

    public class Criteria
    {



    }
}
