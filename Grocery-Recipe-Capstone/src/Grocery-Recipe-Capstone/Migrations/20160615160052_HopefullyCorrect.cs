using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryRecipeCapstone.Migrations
{
    public partial class HopefullyCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "IngrendientId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IngredientId",
                table: "Recipe",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId",
                table: "Recipe",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IngredientId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "IngrendientId",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
