"use strict";

GroceryRecipe.factory("foodEaterFactory", function ($q, $http) {

	return {

		getFoodEater () {
			return $q(function (resolve, reject) {
				return $http.get("http://localhost:64540/api/FoodEater/").success(function (foodieCollection) {
					console.log("foodieCollection", foodieCollection);
							return resolve(foodieCollection);
						}, function (error) {
							return reject(error);
						});
			});
		},

		

		deleteFoodEater (foodie) {
			$http.delete(`http://localhost:64540/api/FoodEater/${foodie.FoodEaterId}`)
					.then(function () {
        	$location.url("/")
        });
		},

		editFoodEater (foodie) {
			console.log("FoodEater", foodie);
			$http.put(`http://localhost:64540/api/FoodEater/${foodie.FoodEaterId}`,

				 JSON.stringify({
         			FirstName: foodie.FirstName,
         			LastName: foodie.LastName,
         			Username: foodie.Username,
         			Email: foodie.Email
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