using System;
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
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DormAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MealPlanAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactHours = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Tuition = table.Column<double>(type: "float", nullable: false),
                    Prerequisites = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyBoards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    HousingType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HousingCost = table.Column<double>(type: "float", nullable: true),
                    AdditionalCost = table.Column<double>(type: "float", nullable: true),
                    MoveInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyOwner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MealPlan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MealCost = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBoards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyBoards_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_MyBoards_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID");
                    table.ForeignKey(
                        name: "FK_MyBoards_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionID", "Country", "CourseID", "DormAvailable", "Education", "MealPlanAvailable", "Name", "Note", "Region", "Type", "URL" },
                values: new object[,]
                {
                    { 1, "United States", 0, true, 3, true, "Northwestern Michigan College", null, "Michigan", 0, "https://www.nmc.edu/" },
                    { 2, "Canada", 0, true, 3, true, "Georgian College", null, "Ontario", 0, "https://www.georgiancollege.ca/" },
                    { 3, "Philippines", 0, true, 3, false, "Enderun Colleges", null, "National Capital Region", 1, "https://www.enderuncolleges.com/" },
                    { 4, "United Kingdom", 0, true, 4, false, "Regents University London", null, "Greater London", 1, "https://www.regents.ac.uk/" },
                    { 5, "Ireland", 0, true, 4, true, "University of Limerick", null, "Munster", 0, "https://www.ul.ie/" },
                    { 6, "Germany", 0, true, 4, false, "Private University of Applied Sciences, Goettingen", null, "Niedersachsen", 1, "https://www.pfh.de/en" },
                    { 7, "Japan", 0, false, 1, true, "Musashino Higashi Middle School", null, "Tokyo", 1, "https://www.musashino-higashi.org/chugaku/" },
                    { 8, "Japan", 0, true, 2, false, "International College of Technology, Kanazawa", null, "Ishikawa", 1, "https://www.ict-kanazawa.ac.jp/" },
                    { 9, "Japan", 0, true, 2, false, "Toin Gakuen", null, "Kanagawa", 1, "https://toin.ac.jp/ses/" },
                    { 10, "Japan", 0, true, 4, false, "University of Tokyo", null, "Tokyo", 0, "https://www.u-tokyo.ac.jp/ja/index.html" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "Age", "Country", "FirstName", "Gender", "Grade", "LastName", "Note", "Region", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 17, "United States", "Clarice", 1, 12, "Langston", null, "Michigan", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 20, "United States", "Alden", 0, null, "Ellisson", null, "Florida", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 22, "France", "Lucas", 0, null, "Barre", null, "Paris", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 14, "Spain", "Roberta", 1, 9, "Garza", null, "Madrid", new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 19, "United Kingdom", "Danny", 0, null, "Salmon", null, "London", new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "ContactHours", "Description", "Duration", "InstitutionID", "Name", "Note", "Prerequisites", "Tuition" },
                values: new object[,]
                {
                    { 1, 20, "Improve your listening, reading, writing, and speaking skills.", 24, 1, "ESL: English as a Second Language", null, "TOEIC 400 or higher", 7500.0 },
                    { 2, 20, "Learn about American culture and gain valuable experience with locals.", 8, 1, "Summer Program", null, null, 5000.0 },
                    { 3, 40, "Choose a local major and learn with local students.", 48, 10, "Exchange Program", null, "JLPT 2 or higher", 15000.0 },
                    { 4, 20, "Choose a major and learn with local students.", 24, 4, "Exchange Program", null, "TOEFL 100 or higher", 8000.0 },
                    { 5, 12, "Learn German by taking listening, reading, writing, and speaking classes.", 12, 6, "Language Program", null, "TOEIC 400 or higher", 5500.0 },
                    { 6, 20, "Learn about Japanese culture and gain valuable experience with locals.", 4, 7, "Summer Program", null, null, 2500.0 }
                });

            migrationBuilder.InsertData(
                table: "MyBoards",
                columns: new[] { "ID", "AdditionalCost", "AddressLine1", "AddressLine2", "City", "Contact", "Country", "CourseID", "HousingCost", "HousingType", "HousingWebsite", "InstitutionID", "MealCost", "MealPlan", "MemberID", "MoveInDate", "Note", "PropertyOwner", "Region", "Semester", "Year", "ZipCode" },
                values: new object[,]
                {
                    { 5, null, null, null, null, null, null, null, null, null, null, null, null, null, 1, null, null, null, null, 0, 2026, null },
                    { 1, null, "2-6 Midori-cho", null, "Koganei", "090-5566-1234", "Japan", 6, 1200.0, "Homestay", "https://homestay/housing1", 7, null, null, 4, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Riku Aoki", "Tokyo", 2, 2025, "184-0003" },
                    { 2, null, "7-3 Hongou", null, "Bunkyo-ku", "080-2233-5678", "Japan", 3, 800.0, "Dormitory", "https://dorm/housing2", 10, 800.0, null, 2, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kazumi Saitou", "Tokyo", 1, 2025, "113-8654" },
                    { 3, null, null, null, null, null, null, 5, null, null, null, 6, null, null, 5, null, null, null, null, 1, 2025, null },
                    { 4, 500.0, "1701 E Front St.", "Apt. 204", "Traverse City", "231-226-1234", "United States", 1, 700.0, "Appartment", "https://appartment/housing3", 1, 1550.0, "PLAN B", 3, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jon Green", "Michigan", 0, 2025, "49686" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstitutionID",
                table: "Courses",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_MyBoards_CourseID",
                table: "MyBoards",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_MyBoards_InstitutionID",
                table: "MyBoards",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_MyBoards_MemberID",
                table: "MyBoards",
                column: "MemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyBoards");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
