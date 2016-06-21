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
    [Route("api/FoodEater")]
    public class FoodEaterController : Controller
    {
        private GroceryRecipeContext _context;

        public FoodEaterController(GroceryRecipeContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<FoodEater> FoodEaters = from FoodEater in _context.FoodEater
                                               select new FoodEater
                                               {
                                                   FoodEaterId = FoodEater.FoodEaterId,
                                                   Username = FoodEater.Username,
                                                   Email = FoodEater.Email,
                                                   FirstName = FoodEater.FirstName,
                                                   LastName = FoodEater.LastName
                                               };
            if (username != null)
            {
                FoodEaters = FoodEaters.Where(g => g.Username == username);
            }
            if (FoodEaters == null)
            {
                return NotFound();
            }

            return Ok(FoodEaters);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetFoodEater")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodEater foodeater = _context.FoodEater.Single(f => f.FoodEaterId == id);

            if (foodeater == null)
            {
                return NotFound();
            }

            return Ok(foodeater);
        }

        // POST api/values
        [Route("api/FoodEater/post")]
        [EnableCors("AllowDevelopmentEnvironment")]
        [HttpPost(Name = "PostitPlease")]
        public IActionResult Post([FromBody] FoodEater foodeater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFoodie = from g in _context.FoodEater
                                 where g.Username == foodeater.Username
                                 select g;

            if (existingFoodie.Count<FoodEater>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.FoodEater.Add(foodeater);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FoodEaterExists(foodeater.FoodEaterId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetFoodEater", new { id = foodeater.FoodEaterId }, foodeater);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FoodEater foodeater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodeater.FoodEaterId)
            {
                return BadRequest();
            }

            _context.Entry(foodeater).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodEaterExists(foodeater.FoodEaterId))
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

            FoodEater foodeater = _context.FoodEater.Single(m => m.FoodEaterId == id);
            if (foodeater == null)
            {
                return NotFound();
            }

            _context.FoodEater.Remove(foodeater);
            _context.SaveChanges();

            return Ok(foodeater);
        }

        private bool FoodEaterExists(int id)
        {
            return _context.FoodEater.Count(e => e.FoodEaterId == id) > 0;
        }
    }
}
