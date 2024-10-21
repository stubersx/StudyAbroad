using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyAbroad.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Education = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionID);
                });

            migrationBuilder.CreateTable(
                name: "MyBoards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBoards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyBoards_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionID", "Country", "Education", "Name", "Note", "Region", "Type", "URL" },
                values: new object[,]
                {
                    { 1, "United States", 3, "Northwestern Michigan College", null, "Michigan", 0, "https://www.nmc.edu/" },
                    { 2, "Canada", 3, "Georgian College", null, "Ontario", 0, "https://www.georgiancollege.ca/" },
                    { 3, "Philippines", 3, "Enderun Colleges", null, "National Capital Region", 1, "https://www.enderuncolleges.com/" },
                    { 4, "United Kingdom", 4, "Regents University London", null, "Greater London", 1, "https://www.regents.ac.uk/" },
                    { 5, "Ireland", 4, "University of Limerick", null, "Munster", 0, "https://www.ul.ie/" },
                    { 6, "Germany", 4, "Private University of Applied Sciences, Goettingen", null, "Niedersachsen", 1, "https://www.pfh.de/en" },
                    { 7, "Japan", 1, "Musashino Higashi Middle School", null, "Tokyo", 1, "https://www.musashino-higashi.org/chugaku/" },
                    { 8, "Japan", 2, "International College of Technology, Kanazawa", null, "Ishikawa", 1, "https://www.ict-kanazawa.ac.jp/" },
                    { 9, "Japan", 2, "Toin Gakuen", null, "Kanagawa", 1, "https://toin.ac.jp/ses/" },
                    { 10, "Japan", 4, "University of Tokyo", null, "Tokyo", 0, "https://www.u-tokyo.ac.jp/ja/index.html" }
                });

            migrationBuilder.InsertData(
                table: "MyBoards",
                columns: new[] { "ID", "InstitutionID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 6 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyBoards_InstitutionID",
                table: "MyBoards",
                column: "InstitutionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyBoards");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
