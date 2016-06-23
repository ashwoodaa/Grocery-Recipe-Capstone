"use strict";

GroceryRecipe.controller("createRecipeController",
[
  "$scope",
  "$location",
  "$http",

  function ($scope, $location, $http) {
    console.log("create Recipe control present");
    // Default property values for keys bound to input fields
    $scope.recipe = {
      Name: "",
      ProcessToCook: "",
      Type: ""
    };

    // Function bound to the Add Recipe button in the view template
    $scope.addRecipe = function () {

      // POST the recipe to api
      $http.post(
        "http://localhost:64540/api/recipe",

        // Remember to stringify objects/arrays before
        // sending them to an API
        JSON.stringify({
          Name: $scope.recipe.Name,
          ProcessToCook: $scope.recipe.ProcessToCook,
          Type: $scope.recipe.Type
        })

      // The $http.post() method returns a promise, so you can use then()
      ).then(
        function () { 
        $location.url("/")
        },      // Handle resolve
        function (response) {
          console.log(response)
        }  // Handle reject
      );
    };
  }
]);