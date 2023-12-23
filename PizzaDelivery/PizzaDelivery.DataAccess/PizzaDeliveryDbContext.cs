using Microsoft.EntityFrameworkCore;
using PizzaDelivery.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.DataAccess
{
    public class PizzaDeliveryDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PizzaEntity> Pizzas { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PizzaInOrderEntity> PizzasInOrders { get; set; }

        public PizzaDeliveryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                 .HasMany(user => user.Orders)
                 .WithOne(order => order.User);

            modelBuilder.Entity<PizzaEntity>()
                .HasMany(pizza => pizza.PizzasInOrders)
                .WithOne(pizzaInOrder => pizzaInOrder.Pizza);

            modelBuilder.Entity<OrderEntity>()
                .HasMany(order => order.PizzasInOrders)
                .WithOne(pizzaInOrder => pizzaInOrder.Order);
        }
    }
}
