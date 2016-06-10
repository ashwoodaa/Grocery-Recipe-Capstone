using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Recipe_Capstone.Models
{
    public class GroceryList
    {
        public int GroceryListId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public Recipe Recipes { get; set; }
        public Ingredient Ingredients { get; set; }
    }
}
