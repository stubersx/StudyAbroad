using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyAbroad.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Please enter the name of the course (50 characters or less).")]
        [StringLength(50, ErrorMessage = "Please enter the name of the course (50 characters or less).")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter the number of contact hours per week (between 1 and 100).")]
        [Display(Name = "Contact Hours")]
        [Column("Contact Hours")]
        [Range(1, 100, ErrorMessage = "Please enter the number of contact hours per week (between 1 and 100).")]
        public int ContactHours { get; set; }

        [Required(ErrorMessage = "Please enter the duration of the course in weeks (between 1 and 150).")]
        [Range(1, 150, ErrorMessage = "Please enter the duration of the course in weeks (between 1 and 150).")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please enter the tuition of the course in US dollars.")]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter the tuition of the course in US dollars.")]
        [DataType(DataType.Currency)]
        public double Tuition { get; set; }

        public string? Prerequisites { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }

        public int InstitutionID { get; set; }
        public Institution? Institution { get; set; }
        public ICollection<CourseMember> CourseMembers { get; set; } = new List<CourseMember>();
    }
}
