using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodNutrition.Data;
using FoodNutrition.Models;
using FoodNutrition.Services;
using FoodNutrition.Models.Validation;
using FoodNutrition.Models.Repositories;

namespace FoodNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutrientsController : ControllerBase
    {
        private INutrientService _service;

        public NutrientsController(FoodNutritionDBContext context)
        {
          _service = new NutrientService(new NutrientRepository(context));
        }

        // GET: api/Nutrients
        [HttpGet]
        public IEnumerable<Nutrient> GetNutrient()
        {
            return _service.ListNutrients();
        }

        // GET: api/Nutrients/5
        [HttpGet("{id}")]
        public ActionResult GetNutrient([FromRoute] int id)
        {
            var nutrient = _service.GetNutrient(id);
            return Ok(nutrient);
        }

        // POST: api/Nutrients
        [HttpPost]
        public ActionResult PostNutrient([FromBody] Nutrient nutrient)
        {
            if (!ModelState.IsValid)
            {
              return BadRequest(ModelState);
            }
            bool result =  _service.CreateNutrient(nutrient);
            return CreatedAtAction("GetNutrient", new { id = nutrient.Id }, nutrient);
        }
    }
}
