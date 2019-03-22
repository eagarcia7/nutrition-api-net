using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodNutrition.Models
{
    public class Food
    {
        public int Id {get; set;}
        public int Code { get; set; }
        public string Name {get; set;}
        public double Weight {get; set;}
        public string Measure {get; set;}

        public ICollection<FoodNutrient> Nutrients { get; set; }

  }
}
