using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryRecipeCapstone.Migrations
{
    public partial class secondForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritedRecipe_FavoritedRecipe_FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritedRecipe_Recipe_RecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.DropIndex(
                name: "IX_FavoritedRecipe_FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.DropIndex(
                name: "IX_FavoritedRecipe_RecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.DropColumn(
                name: "FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.AddColumn<int>(
                name: "FavoritedRecipeId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_FavoritedRecipeId",
                table: "Recipe",
                column: "FavoritedRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_FavoritedRecipe_FavoritedRecipeId",
                table: "Recipe",
                column: "FavoritedRecipeId",
                principalTable: "FavoritedRecipe",
                principalColumn: "FavoritedRecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_FavoritedRecipe_FavoritedRecipeId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_FavoritedRecipeId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "FavoritedRecipeId",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipe_FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe",
                column: "FavoritedRecipesFavoritedRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipe_RecipeId",
                table: "FavoritedRecipe",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritedRecipe_FavoritedRecipe_FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe",
                column: "FavoritedRecipesFavoritedRecipeId",
                principalTable: "FavoritedRecipe",
                principalColumn: "FavoritedRecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritedRecipe_Recipe_RecipeId",
                table: "FavoritedRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
