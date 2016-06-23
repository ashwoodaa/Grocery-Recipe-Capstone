"use strict";

GroceryRecipe.factory("favoritesFactory", function ($q, $http, foodEaterFactory, recipeFactory) {

	 let foodie = foodEaterFactory.foodieCollection;
	 let recipe = recipeFactory.recipeCollection;

	return {
		getfavorites () {
			return $q(function (resolve, reject) {
				return $http.get("http://localhost:64540/api/favoritedrecipes").success(function (favoritesCollection) {
					return resolve(favoritesCollection);
				}, function (error) {
					return reject(error);
				});
			});
		},

		addfavorite (favoritedRecipe, recipeid) {
			console.log("favoritedRecipe", favoritedRecipe);
      // POST the favoritedRecipe to Firebase
      return $q(function (resolve, reject) {
				return $http.post("http://localhost:64540/api/favoritedrecipes",

        // Remember to stringify objects/arrays before
        // sending them to an API
	        JSON.stringify({
	          FavoritedRecipeId : FavoritedRecipeId,
	          FoodEaterId: foodie.FoodEaterId,
	          RecipeId : recipe.RecipeId
	        })
	    	).success (
	    	function (response) {
	    		resolve(response);
	    	});
			});
    },

		deletefavoritedRecipe (favoritedRecipe) {
			$http.delete(`http://localhost:64540/api/favoritedrecipes/${favoritedRecipeid}`)
				.then(function ( ){
					console.log("what is wrong?", favoritedRecipe.id);
				});
		}

	}
});