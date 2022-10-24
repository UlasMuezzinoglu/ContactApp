using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ContactAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ContactDemoAppDb;User Id=postgres;Password=123456;");
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactModel> ContactModels { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(person =>
            {
                person.ToTable("Persons").HasKey(k => k.Id);
                person.Property(p => p.Id).HasColumnName("Id");
                person.Property(p => p.Firstname).HasColumnName("Firstname");
                person.Property(p => p.Lastname).HasColumnName("Lastname");
                person.Property(p => p.Company).HasColumnName("Company");


            });



            Person someFeatureEntitySeed = new Person() { Id = Guid.NewGuid(), Firstname = "Ulaş", Lastname = "Müezzinoglu",  Company = "xyz Company", };
           



            modelBuilder.Entity<Person>().HasData(someFeatureEntitySeed);


        }
    }
}
