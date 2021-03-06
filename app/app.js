"use strict";

let GroceryRecipe = angular.module("GroceryApp", ["ngRoute"])
	.constant("DatAPI", "http://localhost:64540/api/");

// let isAuth =(authFactory) => new Promise((resolve, reject) => {
// 	if (authFactory.isAuthenticated()) {
// 		console.log("User is authenticated, resolve route promise");
// 		resolve();
// 	} else {
// 		console.log("User is not authenticated, reject route promise");
// 		reject();
// 	}
// });

//This is where we set up the routes

GroceryRecipe.config(["$routeProvider",
	function ($routeProvider) {
		$routeProvider.
			when("/", {
				templateUrl: "partials/recipes.html",
				controller: "recipeController",
				// resolve: {isAuth}
			 }).
			// when("/login", {
   //      templateUrl: "partials/login.html",
   //      controller: "loginController"
   //    }).
   //    when("/logout", {
   //      templateUrl: "partials/login.html",
   //      controller: "loginController"
   //    }).
      when("/newRecipe", {
      	templateUrl: "partials/createRecipe.html",
      	controller: "createRecipeController",
      	// resolve: {isAuth}
      }).
      when("/favorites", {
      	templateUrl: "partials/FavoritedRecipes.html",
      	controller: "favoritedRecipesController",
      	// resolve: {isAuth}
      }). 
      when("/groceryList", {
      	templateUrl: "partials/groceryList.html",
      	controller: "groceryListController",
      	// resolve: {isAuth}
      }).
      when("/editUser", {
      	templateUrl: "partials/editFoodEater.html",
      	controller: "editFoodEaterController",
      	// resolve: {isAuth}
      }).
      otherwise({
      	redirectTo: "/"
      });
	}]);

//redirect the user to the login form if there in no authentication

// BoardGameReview.run([
// 	"$location",

// 	($location) => {
// 		let boardGameRef = new Firebase("https://board-game-review.firebaseio.com");

// 		boardGameRef.onAuth(authData => {
// 			if (!authData) {
// 				$location.path("/login");
// 			}
// 		});
// 	}
// ])
;