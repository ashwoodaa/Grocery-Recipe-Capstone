using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Recipe_Capstone.Models
{
    public class GroceryRecipeContext : DbContext
    {
        public GroceryRecipeContext(DbContextOptions<GroceryRecipeContext> options)
           : base(options)
        { }

        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<FavoritedRecipe> FavoritedRecipe { get; set; }
        public DbSet<FoodEater> FoodEater { get; set; }
        public DbSet<GroceryList> GroceryList { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
    }
}
