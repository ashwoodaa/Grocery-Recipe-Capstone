using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroceryRecipeCapstone.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_GroceryList_GroceryListId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_FavoritedRecipe_FavoritedRecipeId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_FavoritedRecipeId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IngredientId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_GroceryListId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FavoritedRecipeId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "GroceryListId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "GroceryList");

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    RecipeIngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.RecipeIngredientId);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipe_RecipeId",
                table: "FavoritedRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId",
                table: "RecipeIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritedRecipe_Recipe_RecipeId",
                table: "FavoritedRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritedRecipe_Recipe_RecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.DropIndex(
                name: "IX_FavoritedRecipe_RecipeId",
                table: "FavoritedRecipe");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.CreateTable(
                name: "GroceryList",
                columns: table => new
                {
                    GroceryListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryList", x => x.GroceryListId);
                });

            migrationBuilder.AddColumn<int>(
                name: "FavoritedRecipeId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_FavoritedRecipeId",
                table: "Recipe",
                column: "FavoritedRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IngredientId",
                table: "Recipe",
                column: "IngredientId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_GroceryList_GroceryListId",
                table: "Ingredient",
                column: "GroceryListId",
                principalTable: "GroceryList",
                principalColumn: "GroceryListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_FavoritedRecipe_FavoritedRecipeId",
                table: "Recipe",
                column: "FavoritedRecipeId",
                principalTable: "FavoritedRecipe",
                principalColumn: "FavoritedRecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId",
                table: "Recipe",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
