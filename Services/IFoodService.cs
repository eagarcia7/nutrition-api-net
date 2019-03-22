using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodNutrition.Models;

namespace FoodNutrition.Services
{
  interface IFoodService
  {
    bool CreateFood(Food foodToCreate);
    IEnumerable<Food> ListFood();
    Food GetFood(int id);
    IEnumerable<Food> GetFoodByNutrientRange(string query);
  }
}
