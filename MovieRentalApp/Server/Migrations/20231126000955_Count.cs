using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRentalApp.Server.Migrations
{
    public partial class Count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "MovieVariants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 1, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 2, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 3, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 4, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 5, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 5, 3 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 6, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 7, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 8, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 9, 2 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MovieVariants",
                keyColumns: new[] { "MovieId", "MovieTypeId" },
                keyValues: new object[] { 9, 3 },
                column: "Count",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "MovieVariants");
        }
    }
}
