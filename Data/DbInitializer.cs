using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FoodNutrition.Models;

namespace FoodNutrition.Data
{
  public class DbInitializer
  {
    public static void Initialize(FoodNutritionDBContext context)
    {
      //context.Database.EnsureCreated();

      // Look for any nutrient.
      if (context.Nutrient.Any())
      {
        return;   // DB has been seeded
      }

      var nutrients = new Nutrient[]
      {
        new Nutrient { Id=203 ,Name = "Protein"},
        new Nutrient { Id=204 ,Name = "Total lipid (fat)"},
        new Nutrient { Id=205 ,Name = "Carbohydrate, by difference"},
        new Nutrient { Id=207 ,Name = "Ash"},
        new Nutrient { Id=208 ,Name = "Energy"},
        new Nutrient { Id=221 ,Name = "Alcohol, ethyl"},
        new Nutrient { Id=269 ,Name = "Sugars, total"},
        new Nutrient { Id=291 ,Name = "Fiber, total dietary"},
      };

      foreach (Nutrient n in nutrients)
      {
        context.Nutrient.Add(n);
      }
      context.Database.OpenConnection();
      try
      {
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Nutrient ON");
        context.SaveChanges();
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Nutrient OFF");
      }
      finally
      {
        context.Database.CloseConnection();
      }

      var food = new Food[]
      {
        new Food { Code = 9001, Name = "Acerola, (west indian cherry), raw", Weight = 98.0, Measure = "1.0 cup" },
        new Food { Code = 9002, Name = "Acerola juice, raw", Weight = 242.0, Measure = "1.0 cup" },
        new Food { Code = 14005, Name = "Alcoholic beverage, beer, light, BUDWEISER SELECT", Weight = 29.5, Measure = "1.0 fl oz" },
        new Food { Code = 14006, Name = "Alcoholic beverage, beer, light", Weight = 29.5, Measure = "1.0 fl oz" },
        new Food { Code = 14007, Name = "Alcoholic beverage, beer, light, BUD LIGHT", Weight = 29.5, Measure = "1.0 fl oz" },
      };

      foreach (Food f in food)
      {
        context.Food.Add(f);
      }
      context.SaveChanges();



      var foodNutrients = new FoodNutrient[]
      {
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 221,
                Unit = "g",
                Value=0.0,
                Gm = 0.0
                },
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 203,
                Unit = "g",
                Value=0.97,
                Gm = 0.4
                },
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 204,
                Unit = "g",
                Value=0.73,
                Gm = 0.3
                },
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 205,
                Unit = "g",
                Value=11.62,
                Gm = 4.8
                },
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 269,
                Unit = "g",
                Value=10.89,
                Gm = 4.5
                },
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 207,
                Unit = "g",
                Value=0.48,
                Gm = 0.2
                },
            new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 208,
                Unit = "kcal",
                Value=56,
                Gm = 23
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola juice, raw" ).Id,
                NutrientId = 291,
                Unit = "g",
                Value = null,
                Gm = null
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 221,
                Unit = "g",
                Value = 0,
                Gm = 0
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 203,
                Unit = "g",
                Value = 0.39,
                Gm = 0.4
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 204,
                Unit = "g",
                Value = 0.29,
                Gm = 0.3
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 205,
                Unit = "g",
                Value = 7.54,
                Gm = 7.89
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 269,
                Unit = "g",
                Value = null,
                Gm = null
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 207,
                Unit = "g",
                Value = 0.2,
                Gm = 0.2
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 208,
                Unit = "kcal",
                Value = 31,
                Gm = 32
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Acerola, (west indian cherry), raw" ).Id,
                NutrientId = 291,
                Unit = "g",
                Value = 1.1,
                Gm = 1.1
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 221,
                Unit = "g",
                Value = 0.9,
                Gm = 3.1
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 203,
                Unit = "g",
                Value = 0.07,
                Gm = 0.24
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 204,
                Unit = "g",
                Value = 0,
                Gm = 0
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 205,
                Unit = "g",
                Value = 0.48,
                Gm = 1.64
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 269,
                Unit = "g",
                Value = null,
                Gm = null
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 207,
                Unit = "g",
                Value = 0.03,
                Gm = 0.09
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 208,
                Unit = "kcal",
                Value = 9,
                Gm = 29
                }
            ,new FoodNutrient {
                FoodId = food.Single(f => f.Name == "Alcoholic beverage, beer, light" ).Id,
                NutrientId = 291,
                Unit = "g",
                Value = null,
                Gm = null
                }
        };

        foreach (FoodNutrient fn in foodNutrients)
        {
          context.FoodNutrient.Add(fn);
        }
        context.SaveChanges();
      }
  }
}
