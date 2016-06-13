using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Recipe_Capstone.Models
{
    public class FavoritedRecipe
    {
        public int FavoritedRecipeId { get; set; }
        public int FoodEaterId { get; set; }
        public int RecipeId { get; set; }
        public FoodEater FoodEater { get; set; }
        public List<Recipe> Recipe { get; set; }
    }
}
