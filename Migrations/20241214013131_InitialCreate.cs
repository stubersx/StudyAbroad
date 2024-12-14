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
                name: "Housings",
                columns: table => new
                {
                    HousingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semester = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    HousingType = table.Column<string>(name: "Housing Type", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HousingCost = table.Column<double>(name: "Housing Cost", type: "float", nullable: true),
                    AdditionalCost = table.Column<double>(name: "Additional Cost", type: "float", nullable: true),
                    MoveinDate = table.Column<DateTime>(name: "Move-in Date", type: "datetime2", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingWebsite = table.Column<string>(name: "Housing Website", type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(name: "Address Line 1", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(name: "Address Line 2", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StateProvincePrefecture = table.Column<string>(name: "State / Province / Prefecture", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ZIPCode = table.Column<string>(name: "ZIP Code", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MealPlan = table.Column<string>(name: "Meal Plan", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MealCost = table.Column<double>(name: "Meal Cost", type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housings", x => x.HousingID);
                });

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
                    StateProvincePrefecture = table.Column<string>(name: "State / Province / Prefecture", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dormitory = table.Column<bool>(type: "bit", nullable: false),
                    MealPlanAvailable = table.Column<bool>(name: "Meal Plan Available", type: "bit", nullable: false)
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
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StateProvincePrefecture = table.Column<string>(name: "State / Province / Prefecture", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegistrationDate = table.Column<DateTime>(name: "Registration Date", type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Housings_HousingID",
                        column: x => x.HousingID,
                        principalTable: "Housings",
                        principalColumn: "HousingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactHours = table.Column<int>(name: "Contact Hours", type: "int", nullable: false),
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
                name: "CourseMembers",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMembers", x => new { x.CourseID, x.MemberID });
                    table.ForeignKey(
                        name: "FK_CourseMembers_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMembers_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Housings",
                columns: new[] { "HousingID", "Additional Cost", "Address Line 1", "Address Line 2", "City", "Contact", "Country", "Housing Cost", "Housing Type", "Housing Website", "Meal Cost", "Meal Plan", "Move-in Date", "Note", "State / Province / Prefecture", "Semester", "Year", "ZIP Code" },
                values: new object[,]
                {
                    { 1, null, "2-6 Midori-cho", null, "Koganei", "090-5566-1234", "Japan", 1200.0, "Homestay", "https://homestay/housing1", null, null, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tokyo", 2, 2025, "184-0003" },
                    { 2, null, "7-3 Hongou", null, "Bunkyo-ku", "080-2233-5678", "Japan", 800.0, "Dormitory", "https://dorm/housing2", 800.0, null, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tokyo", 1, 2025, "113-8654" },
                    { 4, 500.0, "1701 E Front St.", "Apt. 204", "Traverse City", "231-226-1234", "United States", 700.0, "Appartment", "https://appartment/housing3", 1550.0, "PLAN B", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Michigan", 0, 2025, "49686" }
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionID", "Country", "Dormitory", "Education", "Meal Plan Available", "Name", "Note", "State / Province / Prefecture", "Type", "URL" },
                values: new object[,]
                {
                    { 1, "United States", true, 3, true, "Northwestern Michigan College", null, "Michigan", 0, "https://www.nmc.edu/" },
                    { 2, "Canada", true, 3, true, "Georgian College", null, "Ontario", 0, "https://www.georgiancollege.ca/" },
                    { 3, "Philippines", true, 3, false, "Enderun Colleges", null, "National Capital Region", 1, "https://www.enderuncolleges.com/" },
                    { 4, "United Kingdom", true, 4, false, "Regents University London", null, "Greater London", 1, "https://www.regents.ac.uk/" },
                    { 5, "Ireland", true, 4, true, "University of Limerick", null, "Munster", 0, "https://www.ul.ie/" },
                    { 6, "Germany", true, 4, false, "Private University of Applied Sciences, Goettingen", null, "Niedersachsen", 1, "https://www.pfh.de/en" },
                    { 7, "Japan", false, 1, true, "Musashino Higashi Middle School", null, "Tokyo", 1, "https://www.musashino-higashi.org/chugaku/" },
                    { 8, "Japan", true, 2, false, "International College of Technology, Kanazawa", null, "Ishikawa", 1, "https://www.ict-kanazawa.ac.jp/" },
                    { 9, "Japan", true, 2, false, "Toin Gakuen", null, "Kanagawa", 1, "https://toin.ac.jp/ses/" },
                    { 10, "Japan", true, 4, false, "University of Tokyo", null, "Tokyo", 0, "https://www.u-tokyo.ac.jp/ja/index.html" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "Contact Hours", "Description", "Duration", "InstitutionID", "Name", "Note", "Prerequisites", "Tuition" },
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
                table: "Members",
                columns: new[] { "MemberID", "Age", "Country", "First Name", "Gender", "Grade", "HousingID", "Last Name", "Note", "State / Province / Prefecture", "Registration Date" },
                values: new object[,]
                {
                    { 1, 17, "United States", "Clarice", 1, 12, 1, "Langston", null, "Michigan", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 20, "United States", "Alden", 0, null, 2, "Ellisson", null, "Florida", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 22, "France", "Lucas", 0, null, 4, "Barre", null, "Paris", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 14, "Spain", "Roberta", 1, 9, 1, "Garza", null, "Madrid", new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 19, "United Kingdom", "Danny", 0, null, 2, "Salmon", null, "London", new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CourseMembers",
                columns: new[] { "CourseID", "MemberID" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMembers_MemberID",
                table: "CourseMembers",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstitutionID",
                table: "Courses",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_HousingID",
                table: "Members",
                column: "HousingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMembers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Housings");
        }
    }
}
