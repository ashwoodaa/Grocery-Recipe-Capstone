"use strict";

GroceryRecipe.controller("recipeController", [

  "$scope",
  "$location",
  "$http",
  "$route",
  "recipeFactory",
  "ingredientFactory",

  function ($scope, $location, $http, $route, recipeFactory, ingredientFactory) {

    $scope.searchstring = "";
    $scope.foundRecipes = [];
    $scope.editRecipeVisible = false;

    console.log("recipe controller");
    // this searches all the games
    $scope.searchRecipes = function () {
      // pulls all games from factory
      recipeFactory.getRecipes()
      .then(function(recipeCollection) {
        Object.keys(recipeCollection).forEach(function (key) {
          recipeCollection[key].RecipeId = key;
          // this makes sure you search regardless of case or length of searchstring 
          var string = recipeCollection[key].Name.toLowerCase();
          var patt = new RegExp($scope.searchstring.toLowerCase());
          var result = patt.test(string);
          if (result) {
            $scope.foundRecipes.push(recipeCollection[key]);
          } 
          console.log("foundRecipes", $scope.foundRecipes);
          // resets the search back to empty
          $scope.searchstring = "";
        } );
        // pulls all the reviews from the review factory
        // return ingredientFactory.getIngredients();
      
      })
      // .then(function(ingredientCollection) {
      //   console.log("ingredientCollection", ingredientCollection);
      //   // finds ingredients for each recipe
      //   $scope.foundRecipes.forEach(function (recipe) {
      //     recipe.ingredients = [];
      //     Object.keys(ingredientCollection).forEach(function(key){
      //       let currentingredient = ingredientCollection[key];
            
      //       if(currentingredient.recipeID === recipe.id){
      //         recipe.ingredients.push(currentingredient.review);
      //       }
      //     }); 
          
      //   })
      ;

        console.log("$scope.foundRecipes",$scope.foundRecipes);


      },
      function () {

      };


    // shows the editing form on the search.html
    $scope.showEditrecipe = function (recipe) { 
      console.log("recipe", recipe);
      return $scope.editrecipeVisible = true;

    },
    // pulls the editrecipe function from factory and re-hides the editing fields
    $scope.editRecipe = function(recipe) {
      recipeFactory.editRecipe(recipe);
      return $scope.editrecipeVisible = false;
    },
    // pulls the delete function with "recipe" being passed to only delete one
    $scope.deleterecipe = function (recipe) {
      console.log("search ctrl recipe", recipe );
      recipeFactory.deleterecipe(recipe);
      $route.reload();
    },
    // adds a ingredient and saves the recipe id into the ingredient firebase
    $scope.addingredient = function (recipe) {
      console.log("ingredient", recipe);
      ingredientFactory.addingredient(recipe.ingredient, recipe.id).then (function (response) {
        console.log("response", response);
        recipe.ingredient = '';
      });
    }

  }
    

  ]);
