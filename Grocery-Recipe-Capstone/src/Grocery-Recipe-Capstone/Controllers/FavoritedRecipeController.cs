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
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/FavoritedRecipe")]
    public class FavoritedRecipeController : Controller
    {
        private GroceryRecipeContext _context;

        public FavoritedRecipeController(GroceryRecipeContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] int? recipeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<FavoritedRecipe> FavoritedRecipes = from FavoritedRecipe in _context.FavoritedRecipe
                                                           select new FavoritedRecipe
                                                           {
                                                               FavoritedRecipeId = FavoritedRecipe.RecipeId,
                                                               RecipeId = FavoritedRecipe.RecipeId,
                                                               FoodEaterId = FavoritedRecipe.FoodEaterId
                                                            };
            if (recipeId != null)
            {
                FavoritedRecipes = FavoritedRecipes.Where(g => g.RecipeId == recipeId);
            }
            if (FavoritedRecipes == null)
            {
                return NotFound();
            }

            return Ok(FavoritedRecipes);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetFavoritedRecipe")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FavoritedRecipe Favoritedrecipe = _context.FavoritedRecipe.Single(r => r.FavoritedRecipeId == id);

            if (Favoritedrecipe == null)
            {
                return NotFound();
            }

            return Ok(Favoritedrecipe);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] FavoritedRecipe Favoritedrecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFavoritedRecipe = from g in _context.FavoritedRecipe
                                          where g.RecipeId == Favoritedrecipe.RecipeId
                                          select g;

            if (existingFavoritedRecipe.Count<FavoritedRecipe>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.FavoritedRecipe.Add(Favoritedrecipe);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FavoritedRecipeExists(Favoritedrecipe.FavoritedRecipeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetFavoritedRecipe", new { id = Favoritedrecipe.FavoritedRecipeId }, Favoritedrecipe);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FavoritedRecipe Favoritedrecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Favoritedrecipe.FavoritedRecipeId)
            {
                return BadRequest();
            }

            _context.Entry(Favoritedrecipe).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritedRecipeExists(Favoritedrecipe.FavoritedRecipeId))
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

            FavoritedRecipe Favoritedrecipe = _context.FavoritedRecipe.Single(m => m.FavoritedRecipeId == id);
            if (Favoritedrecipe == null)
            {
                return NotFound();
            }

            _context.FavoritedRecipe.Remove(Favoritedrecipe);
            _context.SaveChanges();

            return Ok(Favoritedrecipe);
        }

        private bool FavoritedRecipeExists(int id)
        {
            return _context.FavoritedRecipe.Count(e => e.FavoritedRecipeId == id) > 0;
        }
    }
}
