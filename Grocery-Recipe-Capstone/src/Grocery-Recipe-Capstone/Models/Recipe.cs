using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Recipe_Capstone.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ProcessToCook { get; set; }
        public int IngrendientId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public FavoritedRecipe FavoritedRecipe { get; set; }
    }
}
