using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Recipe_Capstone.Models
{
    public class FoodEater
    {
        public int FoodEaterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<FavoritedRecipe> FavoritedRecipe { get; set; }
    }
}
