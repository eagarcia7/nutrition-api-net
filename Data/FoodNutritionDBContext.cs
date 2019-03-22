using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodNutrition.Models;

namespace FoodNutrition.Data
{
  public class FoodNutritionDBContext : DbContext
  {
    public FoodNutritionDBContext(DbContextOptions<FoodNutritionDBContext> options)
        : base(options)
    {
    }

    public DbSet<Food> Food { get; set; }
    public DbSet<Nutrient> Nutrient { get; set; }
    public DbSet<FoodNutrient> FoodNutrient { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Food>().ToTable("Food");
      modelBuilder.Entity<Nutrient>().ToTable("Nutrient");
      modelBuilder.Entity<FoodNutrient>().ToTable("FoodNutrient");

      modelBuilder.Entity<FoodNutrient>()
                .HasKey(c => new { c.FoodId, c.NutrientId });

      modelBuilder.Entity<FoodNutrient>()
        .HasOne(fn => fn.Food)
        .WithMany(n => n.Nutrients)
        .HasForeignKey(fn => fn.FoodId);

      modelBuilder.Entity<FoodNutrient>()
          .HasOne(fn => fn.Nutrient)
          .WithMany(n => n.Food)
          .HasForeignKey(fn => fn.NutrientId);
    }
  }
}
