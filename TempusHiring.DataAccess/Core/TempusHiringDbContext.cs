using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.DataAccess.Core
{
    public class TempusHiringDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<BodyMaterial> BodyMaterials { get; set; }
        public DbSet<GlassMaterial> GlassMaterials { get; set; }
        public DbSet<Mechanism> Mechanisms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Strap> Straps { get; set; }
        public DbSet<StrapMaterial> StrapMaterials { get; set; }
        public DbSet<Watch> Watches { get; set; }  
        public DbSet<OrderHistory> OrdersHistory { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderWatchLink> OrderWatchLinks { get; set; }
        public DbSet<WristSize> WristSizes { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public TempusHiringDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.LogTo(_ =>
            {
                Console.WriteLine(_);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Environment.NewLine}{new string('*', 80)}{Environment.NewLine}");
                Console.ResetColor();
            }, new[] { RelationalEventId.CommandExecuted });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Watch>().Property(_ => _.Gender)
                .HasConversion<string>();

            builder.Entity<Mechanism>().Property(_ => _.MechanismType)
                .HasConversion<string>();

            builder.Entity<Manufacturer>().Property(_ => _.Country)
                .HasConversion<string>();

            builder.Entity<Order>().Property(_ => _.PaymentMethod)
                .HasConversion<string>();

            base.OnModelCreating(builder);
        }
    }
}
