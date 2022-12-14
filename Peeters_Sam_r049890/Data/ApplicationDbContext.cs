using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Areas.Identity.Data;
using Peeters_Sam_r049890.Models;

namespace Peeters_Sam_r049890.Data
{
  public class ApplicationDbContext: IdentityDbContext<CustomUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Smartphone> Smartphones { get; set; }
    public DbSet<Merk> Merken { get; set; }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      modelBuilder.Entity<Smartphone>().ToTable("Smartphone").Property(s => s.Prijs).HasColumnType("decimal(18,2)");
      modelBuilder.Entity<OrderItem>().ToTable("OrderItem").Property(s => s.Prijs).HasColumnType("decimal(18,2)");
      base.OnModelCreating(modelBuilder);
    }
    

  }
}
