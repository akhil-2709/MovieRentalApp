using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRentalApp.Server.Migrations
{
    public partial class NewVariants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MovieVariants",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "MovieVariants",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 1, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 2, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 3, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 4, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 5, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 5, 3 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 6, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 7, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 8, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 9, 2 },
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 9, 3 },
                column: "Visible",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MovieVariants");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "MovieVariants");
        }
    }
}
