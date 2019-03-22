using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodNutrition.Models.Repositories
{
  interface IFoodRepository : IRepository<Food>
  {
    IEnumerable<Food> GetFoodByNutrientRange(string query);
    //List<int> GetFoodIdsByNutrientRange(string query);
  }
}
