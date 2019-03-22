using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodNutrition.Models
{
  public class FoodNutrient
  {
    public int FoodId { get; set; }
    public int NutrientId { get; set; }
    public string Unit { get; set; }
    public double? Value { get; set; }
    public double? Gm { get; set; }
    public Food Food { get; set; }
    public Nutrient Nutrient { get; set; }
  }
}
