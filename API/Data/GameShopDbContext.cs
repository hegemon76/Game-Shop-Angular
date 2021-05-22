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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BankTransfer>();
            builder.Entity<Cash>();
            builder.Entity<Courier>();
            builder.Entity<ParcelLocker>();
            builder.Entity<InPerson>();




            // builder.Entity<User>()
            //.HasOne(b => b.Basket)
            //.WithOne(i => i.User)
            //.HasForeignKey<Basket>(b => b.UserId);

            // builder.Entity<Order>()
            //.HasOne(b => b.Payment)
            //.WithOne(i => i.Order)
            //.HasForeignKey<Payment>(b => b.OrderId);

            // builder.Entity<Order>()
            //.HasOne(b => b.Delivery)
            //.WithOne(i => i.Order)
            //.HasForeignKey<Delivery>(b => b.OrderId);


            base.OnModelCreating(builder);

        }
    }
}
