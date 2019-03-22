using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodNutrition.Models;
using FoodNutrition.Models.Repositories;

namespace FoodNutrition.Services
{
  public class NutrientService : INutrientService
  {
    private INutrientRepository _repository;

    public NutrientService(NutrientRepository repository)
    {
      _repository = repository;
    }

    public bool CreateNutrient(Nutrient nutrientToCreate)
    {
      try
      {
        _repository.Add(nutrientToCreate);
      }
      catch
      {
        return false;
      }
      return true;
    }

    public IEnumerable<Nutrient> ListNutrients()
    {
      return _repository.GetAll();
    }

    public Nutrient GetNutrient(int id)
    {
      return _repository.Get(id);
    }
  }
}
