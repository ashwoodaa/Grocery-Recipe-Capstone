using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Grocery_Recipe_Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery_Recipe_Capstone.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    [Route("api/Ingredient")]
    public class IngredientController : Controller
    {
        private GroceryRecipeContext _context;

        public IngredientController(GroceryRecipeContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<Ingredient> Ingredients = from Ingredient in _context.Ingredient
                                            select new Ingredient
                                            {
                                                IngredientId = Ingredient.IngredientId,
                                                Amount = Ingredient.Amount,
                                                Name = Ingredient.Name
                                            };
            if (name != null)
            {
                Ingredients = Ingredients.Where(g => g.Name == name);
            }
            if (Ingredients == null)
            {
                return NotFound();
            }

            return Ok(Ingredients);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetIngredient")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ingredient ingredient = _context.Ingredient.Single(i => i.IngredientId == id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingIngredient = from g in _context.Ingredient
                                     where g.Name == ingredient.Name
                                 select g;

            if (existingIngredient.Count<Ingredient>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.Ingredient.Add(ingredient);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IngredientExists(ingredient.IngredientId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetIngredient", new { id = ingredient.IngredientId }, ingredient);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient.IngredientId)
            {
                return BadRequest();
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(ingredient.IngredientId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}", Name = "DeleteIngredient")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ingredient ingredient = _context.Ingredient.Single(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _context.Ingredient.Remove(ingredient);
            _context.SaveChanges();

            return Ok(ingredient);
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Count(e => e.IngredientId == id) > 0;
        }
    }
}
