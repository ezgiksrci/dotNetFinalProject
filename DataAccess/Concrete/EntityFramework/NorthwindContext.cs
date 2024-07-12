﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: DB Tabloları <--> Class bağlamak
    public class NorthwindContext : DbContext
    {
        // OnConfiguring(): Proje hangi DB ile ilişkili
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // @ : string içerisindeki ters slash'ın (\) bir anlamı vardır. Ama bizim stringimiz de \ içeriyorsa onu özel olarak algılama demek. 
            // @"Connection_String"
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        // DbSet: DB'de hangi tabloya ne karşılık gelecek...
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
