using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FoodNutrition.Models.Validation
{
  public class NutrientValidator : AbstractValidator<Nutrient>
  {
    public NutrientValidator()
    {
      RuleFor(nutrient => nutrient.Name).NotNull().MinimumLength(1);
    }
  }
}
