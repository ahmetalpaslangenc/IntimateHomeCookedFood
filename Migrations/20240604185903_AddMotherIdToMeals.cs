using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntimateHomeCookedFood.Migrations
{
    /// <inheritdoc />
    public partial class AddMotherIdToMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookName",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Meals",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Meals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mothers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FavoriteMeals = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mothers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MotherId",
                table: "Meals",
                column: "MotherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Mothers_MotherId",
                table: "Meals",
                column: "MotherId",
                principalTable: "Mothers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Mothers_MotherId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Mothers");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MotherId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Meals",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CookName",
                table: "Meals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
