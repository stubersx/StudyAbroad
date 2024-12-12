using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyAbroad.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Members",
                newName: "Registration Date");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Members",
                newName: "State / Province / Prefecture");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Members",
                newName: "Last Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Members",
                newName: "First Name");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Institutions",
                newName: "State / Province / Prefecture");

            migrationBuilder.RenameColumn(
                name: "MealPlanAvailable",
                table: "Institutions",
                newName: "Meal Plan Available");

            migrationBuilder.RenameColumn(
                name: "DormAvailable",
                table: "Institutions",
                newName: "Dormitory");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Housings",
                newName: "ZIP Code");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Housings",
                newName: "State / Province / Prefecture");

            migrationBuilder.RenameColumn(
                name: "MoveInDate",
                table: "Housings",
                newName: "Move-in Date");

            migrationBuilder.RenameColumn(
                name: "MealPlan",
                table: "Housings",
                newName: "Meal Plan");

            migrationBuilder.RenameColumn(
                name: "MealCost",
                table: "Housings",
                newName: "Meal Cost");

            migrationBuilder.RenameColumn(
                name: "HousingWebsite",
                table: "Housings",
                newName: "Housing Website");

            migrationBuilder.RenameColumn(
                name: "HousingType",
                table: "Housings",
                newName: "Housing Type");

            migrationBuilder.RenameColumn(
                name: "HousingCost",
                table: "Housings",
                newName: "Housing Cost");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Housings",
                newName: "Address Line 2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Housings",
                newName: "Address Line 1");

            migrationBuilder.RenameColumn(
                name: "AdditionalCost",
                table: "Housings",
                newName: "Additional Cost");

            migrationBuilder.RenameColumn(
                name: "ContactHours",
                table: "Courses",
                newName: "Contact Hours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State / Province / Prefecture",
                table: "Members",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "Registration Date",
                table: "Members",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "Last Name",
                table: "Members",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First Name",
                table: "Members",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "State / Province / Prefecture",
                table: "Institutions",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "Meal Plan Available",
                table: "Institutions",
                newName: "MealPlanAvailable");

            migrationBuilder.RenameColumn(
                name: "Dormitory",
                table: "Institutions",
                newName: "DormAvailable");

            migrationBuilder.RenameColumn(
                name: "ZIP Code",
                table: "Housings",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "State / Province / Prefecture",
                table: "Housings",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "Move-in Date",
                table: "Housings",
                newName: "MoveInDate");

            migrationBuilder.RenameColumn(
                name: "Meal Plan",
                table: "Housings",
                newName: "MealPlan");

            migrationBuilder.RenameColumn(
                name: "Meal Cost",
                table: "Housings",
                newName: "MealCost");

            migrationBuilder.RenameColumn(
                name: "Housing Website",
                table: "Housings",
                newName: "HousingWebsite");

            migrationBuilder.RenameColumn(
                name: "Housing Type",
                table: "Housings",
                newName: "HousingType");

            migrationBuilder.RenameColumn(
                name: "Housing Cost",
                table: "Housings",
                newName: "HousingCost");

            migrationBuilder.RenameColumn(
                name: "Address Line 2",
                table: "Housings",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "Address Line 1",
                table: "Housings",
                newName: "AddressLine1");

            migrationBuilder.RenameColumn(
                name: "Additional Cost",
                table: "Housings",
                newName: "AdditionalCost");

            migrationBuilder.RenameColumn(
                name: "Contact Hours",
                table: "Courses",
                newName: "ContactHours");
        }
    }
}
