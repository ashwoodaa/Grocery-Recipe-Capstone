using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Recipe_Capstone.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set;}
        public Recipe Recipe { get; set; }
        public GroceryList GroceryList { get; set; }
    }
}
