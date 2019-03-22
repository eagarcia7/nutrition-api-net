using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodNutrition.Data;

namespace FoodNutrition.Models.Repositories
{
  public class NutrientRepository : Repository<Nutrient>, INutrientRepository
  {
    public NutrientRepository(FoodNutritionDBContext context) : base(context)
    {
    }
  }
}
