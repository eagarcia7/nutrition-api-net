using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodNutrition.Models
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FoodNutrient> Food { get; set; }
  }
}
