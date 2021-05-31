using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class GameShopDbContext: DbContext
    {
        private string _connectionString= "Server=.;Database=GameShopDb;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public DbSet<Address> Adresses { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<BankTransfer> BankTransfer { get; set; }
        public DbSet<Cash> Cash { get; set; }
        public DbSet<Courier> Courier { get; set; }
        public DbSet<ParcelLocker> ParcelLocker { get; set; }
        public DbSet<InPerson> InPerson { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
