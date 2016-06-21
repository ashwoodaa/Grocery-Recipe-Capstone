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
    [Route("api/Recipe")]
    public class RecipeController : Controller
    {
        private GroceryRecipeContext _context;

        public RecipeController(GroceryRecipeContext context)
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
            IQueryable<Recipe> Recipes = from Recipe in _context.Recipe
                                        select new Recipe
                                        {
                                                   RecipeId = Recipe.RecipeId,
                                                   ProcessToCook = Recipe.ProcessToCook,
                                                   Name = Recipe.Name,
                                                   Type = Recipe.Type
                                               };
            if (name != null)
            {
                Recipes = Recipes.Where(g => g.Name == name);
            }
            if (Recipes == null)
            {
                return NotFound();
            }

            return Ok(Recipes);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRecipe")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Recipe recipe = _context.Recipe.Single(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRecipe = from g in _context.Recipe
                                 where g.Name == recipe.Name
                                 select g;

            if (existingRecipe.Count<Recipe>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.Recipe.Add(recipe);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RecipeExists(recipe.RecipeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetRecipe", new { id = recipe.RecipeId }, recipe);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(recipe.RecipeId))
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

            Recipe recipe = _context.Recipe.Single(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipe.Remove(recipe);
            _context.SaveChanges();

            return Ok(recipe);
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Count(e => e.RecipeId == id) > 0;
        }
    }
}
