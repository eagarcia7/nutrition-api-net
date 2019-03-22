using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodNutrition.Models;
using FoodNutrition.Models.Repositories;

namespace FoodNutrition.Services
{
  public class FoodService : IFoodService
  {
    private IFoodRepository _repository;

    public FoodService(FoodRepository repository)
    {
      _repository = repository;
    }

    public bool CreateFood(Food foodToCreate)
    {
      try
      {
        _repository.Add(foodToCreate);
      }
      catch
      {
        return false;
      }
      return true;
    }

    public IEnumerable<Food> ListFood()
    {
      return _repository.GetAll();
    }

    public Food GetFood(int id)
    {
      return _repository.Get(id);
    }

    public IEnumerable<Food> GetFoodByNutrientRange(string query)
    {
      return _repository.GetFoodByNutrientRange(query);
    }
  }
}
