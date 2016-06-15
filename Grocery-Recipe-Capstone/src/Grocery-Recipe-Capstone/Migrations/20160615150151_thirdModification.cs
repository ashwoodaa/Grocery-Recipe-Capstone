using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryRecipeCapstone.Migrations
{
    public partial class thirdModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryList_Ingredient_IngredientId",
                table: "GroceryList");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryList_Recipe_RecipeId",
                table: "GroceryList");

            migrationBuilder.DropIndex(
                name: "IX_GroceryList_IngredientId",
                table: "GroceryList");

            migrationBuilder.DropIndex(
                name: "IX_GroceryList_RecipeId",
                table: "GroceryList");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "GroceryList");

            migrationBuilder.AddColumn<int>(
                name: "IngrendientId",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroceryListId",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_GroceryListId",
                table: "Ingredient",
                column: "GroceryListId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_GroceryList_GroceryListId",
                table: "Ingredient",
                column: "GroceryListId",
                principalTable: "GroceryList",
                principalColumn: "GroceryListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_GroceryList_GroceryListId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_GroceryListId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "IngrendientId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "GroceryListId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "GroceryList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryList_IngredientId",
                table: "GroceryList",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryList_RecipeId",
                table: "GroceryList",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryList_Ingredient_IngredientId",
                table: "GroceryList",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryList_Recipe_RecipeId",
                table: "GroceryList",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
