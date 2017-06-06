using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstExistingDatabase
{

    class Program
    {
        // private const string ConnectionString =
        //    @"Server=.;Database=EntityWhichReferencesSameType;integrated security=SSPI;";

        static void Main(string[] args)
        {

            Database.SetInitializer<MyContext>(new Initialize());

            Customer headOffice = new Customer();
            headOffice.CompanyName = "Head Office";

            MyContext context = new MyContext();
            context.Customers.Add(headOffice);
            context.SaveChanges();

            //Customer subOffice = new Customer();
            //subOffice.CompanyName = "Sub Office";
            //subOffice.HeadOffice = headOffice;
            //context.Customers.Add(subOffice);
            //context.SaveChanges();

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }

    public class MyContext
        : DbContext
    {
        public MyContext()
            : base("ExampleOneToMany")
        {

        }

        public DbSet<Customer> Customers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CustomerConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}
    }

    public class CustomerConfiguration
        : EntityTypeConfiguration<Customer>
    {
        //public CustomerConfiguration()
        //    : base()
        //{
        //    HasKey(p => p.Id);
        //    Property(p => p.Id)
        //        .HasColumnName("Id")
        //        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
        //        .IsRequired();
        //    Property(p => p.CompanyName)
        //        .HasColumnName("Name")
        //        .IsRequired();
        //    HasOptional(p => p.HeadOffice).WithMany()
        //        .Map(p => p.MapKey("HeadOfficeId"));
        //    ToTable("Customers");
        //}
    }

    public class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public Customer HeadOffice { get; set; }
    }

    public class Initialize : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {

        }
    }

}