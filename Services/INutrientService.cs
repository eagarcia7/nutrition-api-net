using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodNutrition.Models;

namespace FoodNutrition.Services
{
  public interface INutrientService
  {
    bool CreateNutrient(Nutrient nutrientToCreate);
    IEnumerable<Nutrient> ListNutrients();
    Nutrient GetNutrient(int id);
  }
}
