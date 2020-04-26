using Core.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> Options)
            : base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //create table of Owner with aleatoire value of Id

            modelBuilder.Entity<Owner>().Property(x => x.id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.id).HasDefaultValueSql("NEWID()");

            //add data
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    id = Guid.NewGuid(),
                    Avatar="Avatar.jpg",
                    FullName="Khalid essaadani",
                    profil="Microsoft MVP/ .NET Consultant"

                }
                );
           
          

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

    }
}
