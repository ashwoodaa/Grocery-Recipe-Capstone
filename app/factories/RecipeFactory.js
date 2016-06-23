"use strict";

GroceryRecipe.factory("recipeFactory", function ($q, $http) {

	return {

		getRecipes () {
			return $q(function (resolve, reject) {
				return $http.get("http://localhost:64540/api/recipe").success(function (recipeCollection) {
					console.log("recipeCollection", recipeCollection);
							return resolve(recipeCollection);
						}, function (error) {
							return reject(error);
						});
			});
		},



		deleteRecipe (recipe) {
			$http.delete(`http://localhost:64540/api/recipe/${recipe.RecipeId}`)
					.then(function () {
        	$location.url("/")
        });
		},

		editRecipe (recipe) {
			console.log("recipe", recipe);
			$http.put(`http://localhost:64540/api/recipe/${recipe.RecipeId}`,

				 JSON.stringify({
         			Name: recipe.Name,
          			ProcessToCook: recipe.ProcessToCook,
          			Type: recipe.Type
        		})
			).then
			(function (response) {
				console.log("success", response);
			},
			function (response) {
				console.log("failure", response);
			})
		}

	}

});