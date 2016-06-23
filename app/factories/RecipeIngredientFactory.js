"use strict";

GroceryRecipe.factory("recipeIngredientFactory", function ($q, $http, ingredientFactory, recipeFactory) {

	 let ingredient = ingredientFactory.ingredientCollection;
	 let recipe = recipeFactory.recipeCollection;

	return {
		getRIngredients () {
			return $q(function (resolve, reject) {
				return $http.get("http://localhost:64540/api/recipeingredients").success(function (ringredientsCollection) {
					return resolve(ringredientsCollection);
				}, function (error) {
					return reject(error);
				});
			});
		},

		addRIngredient (recipe, recipeingredientid) {
			console.log("RecipeIngredient", RecipeIngredient);
      // POST the RecipeIngredient to Firebase
      return $q(function (resolve, reject) {
				return $http.post("http://localhost:64540/api/recipeingredients",

        // Remember to stringify objects/arrays before
        // sending them to an API
	        JSON.stringify({
	          RecipeIngredientId : RecipeIngredientId,
	          IngredientId : ingredient.IngredientId,
	          RecipeId : recipe.RecipeId
	        })
	    	).success (
	    	function (response) {
	    		resolve(response);
	    	});
			});
    },

		deleteRIngredient (RecipeIngredient) {
			$http.delete(`http://localhost:64540/api/recipeingredients/${RecipeIngredientid}`)
				.then(function ( ){
					console.log("what is wrong?", RecipeIngredient.recipeingredientid);
				});
		}

	}
});