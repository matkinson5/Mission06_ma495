using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_ma495.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: true),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_responses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Science Fiction" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Comedy" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Mike Newell", false, "Julia", "", "PG-13", "The Guernsey Literary and Potato Peel Pie Society", "2018" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 1, "Denis Villeneuve", true, "", "", "PG-13", "Dune", "2021" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 2, "Inigo Montoya", false, "Mom", "", "PG", "The Princess Bride", "1987" });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryID",
                table: "responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
