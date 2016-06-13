using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroceryRecipeCapstone.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodEater",
                columns: table => new
                {
                    FoodEaterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEater", x => x.FoodEaterId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProcessToCook = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "FavoritedRecipe",
                columns: table => new
                {
                    FavoritedRecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FavoritedRecipesFavoritedRecipeId = table.Column<int>(nullable: true),
                    FoodEaterId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedRecipe", x => x.FavoritedRecipeId);
                    table.ForeignKey(
                        name: "FK_FavoritedRecipe_FavoritedRecipe_FavoritedRecipesFavoritedRecipeId",
                        column: x => x.FavoritedRecipesFavoritedRecipeId,
                        principalTable: "FavoritedRecipe",
                        principalColumn: "FavoritedRecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoritedRecipe_FoodEater_FoodEaterId",
                        column: x => x.FoodEaterId,
                        principalTable: "FoodEater",
                        principalColumn: "FoodEaterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritedRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroceryList",
                columns: table => new
                {
                    GroceryListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryList", x => x.GroceryListId);
                    table.ForeignKey(
                        name: "FK_GroceryList_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryList_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipe_FavoritedRecipesFavoritedRecipeId",
                table: "FavoritedRecipe",
                column: "FavoritedRecipesFavoritedRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipe_FoodEaterId",
                table: "FavoritedRecipe",
                column: "FoodEaterId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipe_RecipeId",
                table: "FavoritedRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryList_IngredientId",
                table: "GroceryList",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryList_RecipeId",
                table: "GroceryList",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritedRecipe");

            migrationBuilder.DropTable(
                name: "GroceryList");

            migrationBuilder.DropTable(
                name: "FoodEater");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
