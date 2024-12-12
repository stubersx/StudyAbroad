using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyAbroad.Models
{
    public enum SchoolType
    {
        Public,
        Private
    }
    public enum Education
    {
        Elementary,
        Middle,
        High,
        College,
        University,
        Vocational
    }

    public class Institution
    {
        public int InstitutionID { get; set; }

        [Required(ErrorMessage = "Please enter the name of the institution (50 characters or less).")]
        [StringLength(50, ErrorMessage = "Please enter the name of the institution (50 characters or less).")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select the type of education.")]
        public Education Education { get; set; }
        
        [Required(ErrorMessage = "Please select the type of institution.")]
        public SchoolType Type { get; set; }
        
        [Required(ErrorMessage = "Please enter the country of the institution (30 characters or less).")]
        [StringLength(30, ErrorMessage = "Please enter the country of the institution (30 characters or less).")]
        public string Country { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter the region of the institution (30 characters or less).")]
        [Display(Name = "State / Province / Prefecture")]
        [Column("State / Province / Prefecture")]
        [StringLength(30, ErrorMessage = "Please enter the region of the institution (30 characters or less).")]
        public string Region { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter the website link to the institution.")]
        public string URL { get; set; } = string.Empty;
        
        public string? Note { get; set; }
        
        [Required(ErrorMessage = "Please indicate if dorms are available for international students.")]
        [Display(Name = "Dormitory")]
        [Column("Dormitory")]
        public bool DormAvailable { get; set; }
        
        [Required(ErrorMessage = "Please indicate if meal plans are available for international students.")]
        [Display(Name = "Meal Plan")]
        [Column("Meal Plan Available")]
        public bool MealPlanAvailable { get; set; }
        
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
