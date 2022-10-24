using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReportAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ReportServiceDb;User Id=postgres;Password=123456;");
        }
        public DbSet<Report> Reports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>(person =>
            {
                person.ToTable("Reports").HasKey(k => k.Id);
                person.Property(p => p.Id).HasColumnName("Id");
                person.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                person.Property(p => p.CompletedDate).HasColumnName("CompletedDate");
                person.Property(p => p.IsCompleted).HasColumnName("IsCompleted");
                person.Property(p => p.FilePath).HasColumnName("FilePath");



            });

            Report reportSeed = new Report() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, IsCompleted = false };




            modelBuilder.Entity<Report>().HasData(reportSeed);


        }

    }
}
