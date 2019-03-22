using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FoodNutrition.Models.Validation
{
  public class FoodValidator : AbstractValidator<Food>
  {
    public FoodValidator()
    {
      RuleFor(food => food.Code).NotNull();
      RuleFor(food => food.Name).NotNull().MinimumLength(1);
    }
  }
}
