using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntimateHomeCookedFood.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Mothers_MotherId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "MotherId",
                table: "Meals",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Mothers_MotherId",
                table: "Meals",
                column: "MotherId",
                principalTable: "Mothers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Mothers_MotherId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "MotherId",
                table: "Meals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Mothers_MotherId",
                table: "Meals",
                column: "MotherId",
                principalTable: "Mothers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
