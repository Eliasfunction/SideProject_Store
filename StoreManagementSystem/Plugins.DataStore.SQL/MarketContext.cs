using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(t => t.CategoryId);
            //種子資料
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "飲料", Description = "飲料" },
                new Category { CategoryId = 2, Name = "食品", Description = "食品" },
                new Category { CategoryId = 3, Name = "乳製品", Description = "乳製品" },
                new Category { CategoryId = 4, Name = "衛生紙", Description = "衛生紙" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "黑松茶花綠茶", Quantity = 100, Price = 20 },
                new Product { ProductId = 2, CategoryId = 2, Name = "雪碧500ml", Quantity = 200, Price = 25 },
                new Product { ProductId = 3, CategoryId = 3, Name = "可口可樂800ml", Quantity = 50, Price = 32 },
                new Product { ProductId = 4, CategoryId = 3, Name = "泰山礦泉水650ml", Quantity = 80, Price = 9 }
                );
        }




    }
}
