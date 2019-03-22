using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodNutrition.Services;
using FoodNutrition.Models;
using FoodNutrition.Models.Validation;
using FoodNutrition.Models.Repositories;
using FoodNutrition.Data;

namespace FoodNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
      private IFoodService _service;

      public FoodsController(FoodNutritionDBContext context)
      {
        _service = new FoodService(new FoodRepository(context));
      }

      // GET: api/Foods
      [HttpGet]
      public IEnumerable<Food> GetFood([FromQuery(Name = "filter")] string filter)
      {
        return _service.GetFoodByNutrientRange(filter);
      }

    // GET: api/Foods/5
    [HttpGet("{id}")]
      public ActionResult GetFood([FromRoute] int id)
      {
        Food food = _service.GetFood(id);
        return Ok(food);
      }

    // POST: api/Foods
    [HttpPost]
    public ActionResult PostFood([FromBody] Food food)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      bool result = _service.CreateFood(food);
      return CreatedAtAction("GetFood", new { id = food.Id }, food);
    }
  }
}
