using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF1
{
    public class ContextDB : DbContext
    {
        public ContextDB()
            : base("CarDB")
        {
            //    this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new Initializer());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomerConfiguration
        : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
            : base()
        {
            HasKey(p => p.Id);
            Property(p => p.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(p => p.CompanyName)
                .HasColumnName("Name")
                .IsRequired();
            HasOptional(p => p.HeadOffice).WithMany()
                .Map(p => p.MapKey("HeadOfficeId"));
            ToTable("Customers");
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string NameCar { get; set; }
        public string Color { get; set; }
        public string TypeCar { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        //     public int?  CustomerId { get; set; }
        public Customer HeadOffice { get; set; }
    }


    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdEmployee { get; set; }
        public string UserName { get; set; }
        public virtual Employee Employee { get; set; }
    }


    public class Employee
    {
        [Key]
        [ForeignKey("User")]
        public int IdEmployee { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //      public Employee DepartmentHead { get; set; }
        //      public Employee ManagerCompany { get; set; }
        public virtual User User { get; set; }

    }
}
