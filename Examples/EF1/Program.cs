using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF1
{
    class Program
    {
        static void Main(string[] args)
        {

          ContextDB db = new ContextDB();
          
          //var  listCars = db.Cars.ToList();
          //foreach (var item in listCars) 
          //Console.WriteLine(item.NameCar);

          Customer headOffice = new Customer();
          headOffice.CompanyName = "Head Office";
          db.Customers.Add(headOffice);
          db.SaveChanges();

          Customer suboffice = new Customer();
          suboffice.CompanyName = "sub office";
          suboffice.HeadOffice = headOffice;
          db.Customers.Add(suboffice);
          db.SaveChanges();


          var listCustomers = db.Customers.ToList();
          foreach (var item in listCustomers)
              Console.WriteLine("Name {0}  headOffice {1}", item.CompanyName, item.HeadOffice);

          Console.WriteLine("Done.");
          Console.ReadLine();


          //var _user = new User { UserName = "Vasya" };
          //db.Users.Add(_user);
          //db.SaveChanges();

          //var _emp = new Employee { FirstName = "Ivanov", LastName = "Pavlo", User = _user };
          ////var _emp = new Employee {IdEmployee = _user.IdEmployee, FirstName = "Ivanov", LastName = "Pavlo" };

          //db.Employees.Add(_emp);
          //db.SaveChanges();


          //var listEmp = db.Employees.ToList();
          //foreach (var item in listEmp)
          //    Console.WriteLine(item.LastName);




        }
    }
}

