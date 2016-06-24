"use strict";

GroceryRecipe.controller("groceryListController", [

  "$scope",
  "$location",
  "$http",
  "$route",
  "ingredientFactory",

  function ($scope, $location, $http, $route, ingredientFactory) {

    $scope.grocerylist = [];
    $scope.ingredient = {
      Name: "",
      Amount: ""
    };

    ingredientFactory.getingredients()
      .then(function (ingredientCollection) {
        Object.keys(ingredientCollection).forEach(function (key) {
          ingredientCollection[key].IngredientId = key;
            $scope.grocerylist.push(ingredientCollection[key]);
          });
        });

    $scope.addingredient = function (ingredient) {
      $http.post(
        "http://localhost:64540/api/ingredient",

        // Remember to stringify objects/arrays before
        // sending them to an API
        JSON.stringify({
          Name: $scope.ingredient.Name,
          Amount: $scope.ingredient.Amount
        })

      // The $http.post() method returns a promise, so you can use then()
      ).then(
        function () { 
        $location.url("/groceryList")
        },      // Handle resolve
        function (response) {
          console.log(response)
        }  // Handle reject
      );
      $route.reload();
    }
    
    
    // pulls the delete function with "ingredient" being passed to only delete one
    $scope.deleteIngredient = function (Ingredient) {
      console.log("search ctrl Ingredient", Ingredient );
      ingredientFactory.deleteIngredient(Ingredient);
      $route.reload();
    }

  }
    
  ]);
