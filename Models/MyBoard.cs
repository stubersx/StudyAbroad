using System.ComponentModel.DataAnnotations;

namespace StudyAbroad.Models
{
    public enum Semester
    {
        Fall,
        Spring,
        Summer
    }

    public class MyBoard
    {
        public int ID { get; set; }
        public Member Member { get; set; } = default!;
        public int MemberID { get; set; }
        public Institution Institution { get; set; } = default!;
        public int? InstitutionID { get; set; }
        public Course Course { get; set; } = default!;
        public int? CourseID { get; set; }
        public Semester? Semester { get; set; }
        [Range(2024, 2029, ErrorMessage = "Please enter the year you will attend (between 2024 and 2029).")]
        public int? Year { get; set; }
        [StringLength(30, ErrorMessage = "Please enter the type of housing (30 characters or less).")]
        [Display(Name = "Housing Type")]
        public string? HousingType { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter the cost of housing in US dollars.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Housing Cost")]
        public double? HousingCost { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter any additional costs for housing in US dollars.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Additional Cost")]
        public double? AdditionalCost { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Move-in Date")]
        public DateTime? MoveInDate { get; set; }
        [Display(Name = "Property Owner")]
        [StringLength(50, ErrorMessage = "Please enter the name of the property owner (50 characters or less).")]
        public string? PropertyOwner { get; set; }
        public string? Contact { get; set; }
        [Display(Name = "Housing Website")]
        public string? HousingWebsite { get; set; }
        [StringLength(100, ErrorMessage = "Please enter Address Line 1 (100 characters or less).")]
        [Display(Name = "Address Line 1")]
        public string? AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Please enter Address Line 2 (100 characters or less).")]
        public string? AddressLine2 { get; set; }
        [StringLength(30, ErrorMessage = "Please enter the city (30 characters or less).")]
        public string? City { get; set; }
        [Display(Name = "State / Province / Prefecture")]
        [StringLength(30, ErrorMessage = "Please enter the region (30 characters or less).")]
        public string? Region { get; set; }
        [Display(Name = "ZIP Code")]
        [StringLength(20, ErrorMessage = "Please enter the zip code (20 characters or less).")]
        public string? ZipCode { get; set; }
        [StringLength(30, ErrorMessage = "Please enter the country (30 characters or less).")]
        public string? Country { get; set; }
        [Display(Name = "Meal Plan")]
        [StringLength(20, ErrorMessage = "Please enter the meal plan you selected (20 characters or less).")]
        public string? MealPlan { get; set; }
        [Display(Name = "Meal Cost")]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter the cost of the meal in US dollars.")]
        [DataType(DataType.Currency)]
        public double? MealCost { get; set; }
        public string? Note { get; set; } 
    }
}
