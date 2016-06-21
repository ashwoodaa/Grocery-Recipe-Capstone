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
    [Route("api/RecipeIngredient")]
    public class RecipeIngredientController : Controller
    {
        private GroceryRecipeContext _context;

        public RecipeIngredientController(GroceryRecipeContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] int? RecipeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<RecipeIngredient> RecipeIngredients = from RecipeIngredient in _context.RecipeIngredient
                                                             select new RecipeIngredient
                                                             {
                                                                 RecipeIngredientId = RecipeIngredient.RecipeIngredientId,
                                                                 RecipeId = RecipeIngredient.RecipeId,
                                                                 IngredientId = RecipeIngredient.IngredientId
                                                              };
            if (RecipeId != null)
            {
                RecipeIngredients = RecipeIngredients.Where(g => g.RecipeId == RecipeId);
            }
            if (RecipeIngredients == null)
            {
                return NotFound();
            }

            return Ok(RecipeIngredients);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRecipeIngredient")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RecipeIngredient recipeIngredient = _context.RecipeIngredient.Single(r => r.RecipeIngredientId == id);

            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return Ok(recipeIngredient);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] RecipeIngredient recipeIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRecipeIngredient = from g in _context.RecipeIngredient
                                           where g.RecipeId == recipeIngredient.RecipeId
                                           select g;

            if (existingRecipeIngredient.Count<RecipeIngredient>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.RecipeIngredient.Add(recipeIngredient);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RecipeIngredientExists(recipeIngredient.RecipeIngredientId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetRecipeIngredient", new { id = recipeIngredient.RecipeIngredientId }, recipeIngredient);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RecipeIngredient recipeIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeIngredient.RecipeIngredientId)
            {
                return BadRequest();
            }

            _context.Entry(recipeIngredient).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(recipeIngredient.RecipeIngredientId))
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RecipeIngredient recipeIngredient = _context.RecipeIngredient.Single(m => m.RecipeIngredientId == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            _context.RecipeIngredient.Remove(recipeIngredient);
            _context.SaveChanges();

            return Ok(recipeIngredient);
        }

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredient.Count(e => e.RecipeIngredientId == id) > 0;
        }
    }
}
