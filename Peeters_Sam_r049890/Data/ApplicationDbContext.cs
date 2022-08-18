using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Models;

namespace Peeters_Sam_r049890.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Smartphone> Smartphones { get; set; }
    public DbSet<Merk> Merken { get; set; }

    public DbSet<Klant> Klanten { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Smartphone>().ToTable("Smartphone").Property(s => s.Prijs).HasColumnType("decimal(18,2)");
      base.OnModelCreating(modelBuilder);
    }
    

  }
}
