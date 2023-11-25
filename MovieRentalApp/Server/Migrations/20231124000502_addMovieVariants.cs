using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRentalApp.Server.Migrations
{
    public partial class addMovieVariants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovieVariants",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieTypeId = table.Column<int>(type: "int", nullable: false),
                    WeekDayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeekendPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieVariants", x => new { x.MovieId, x.MovieTypeId });
                    table.ForeignKey(
                        name: "FK_MovieVariants_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieVariants_MovieTypes_MovieTypeId",
                        column: x => x.MovieTypeId,
                        principalTable: "MovieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Default" });

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "DVD" });

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Blu-ray" });

            migrationBuilder.InsertData(
                table: "MovieVariants",
                columns: new[] { "MovieId", "MovieTypeId", "WeekDayPrice", "WeekendPrice" },
                values: new object[,]
                {
                    { 1, 2, 6.99m, 9.99m },
                    { 2, 2, 6.99m, 9.99m },
                    { 3, 2, 6.99m, 9.99m },
                    { 4, 2, 6.99m, 9.99m },
                    { 5, 2, 6.99m, 9.99m },
                    { 5, 3, 9.99m, 11.99m },
                    { 6, 2, 6.99m, 9.99m },
                    { 7, 2, 6.99m, 9.99m },
                    { 8, 2, 6.99m, 9.99m },
                    { 9, 2, 6.99m, 9.99m },
                    { 9, 3, 9.99m, 11.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieVariants_MovieTypeId",
                table: "MovieVariants",
                column: "MovieTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieVariants");

            migrationBuilder.DropTable(
                name: "MovieTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movies",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 5.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 7.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 5.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 7.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 5.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 7.99m);
        }
    }
}
