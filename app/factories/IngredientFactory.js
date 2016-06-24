"use strict";

GroceryRecipe.factory("ingredientFactory", function ($q, $http) {

	return {

		getingredients () {
			return $q(function (resolve, reject) {
				return $http.get("http://localhost:64540/api/ingredient/").success(function (ingredientCollection) {
					console.log("ingredientCollection", ingredientCollection);
							return resolve(ingredientCollection);
						}, function (error) {
							return reject(error);
						});
			});
		},

		

		deleteIngredient (ingredient) {
			$http.delete(`http://localhost:64540/api/ingredient/${ingredient.IngredientId}`)
					.then(function () {
        	$location.url("/groceryList")
        });
		},

		editingredient (ingredient) {
			console.log("ingredient", ingredient);
			$http.put(`http://localhost:64540/api/ingredient/${ingredient.IngredientId}`,

				 JSON.stringify({
         			Name: ingredient.Name,
          			Amount: ingredient.Amount
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