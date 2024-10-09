using System.ComponentModel.DataAnnotations;

namespace StudyAbroad.Models
{
    public class Institution
    {
        public enum SchoolType
        {
            Public,
            Private
        }
        public enum EducationType
        {
            Elementary,
            Middle,
            High,
            College,
            University,
            Vocational
        }

        public int InstitutionID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please enter the name of the institution (50 characters or less).")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please select the type of education.")]
        public EducationType? Education { get; set; }
        [Required(ErrorMessage = "Please select the type of institution.")]
        public SchoolType? Type { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Please enter the country of the institution (30 characters or less).")]
        public string? Country { get; set; }
        [Required]
        [Display(Name = "State / Province / Prefecture")]
        [StringLength(30, ErrorMessage = "Please enter the region of the institution (30 characters or less).")]
        public string? Region { get; set; }
        [Required(ErrorMessage = "Please enter the website link to the institution.")]
        public string? URL { get; set; }
        public string? Note { get; set; }

        /*
        public string? Duration { get; set; }
        public string? Housing { get; set; }
        public string? Meal { get; set; }
        public int? Tuition { get; set; }
        public string? Program {  get; set; }
        public bool? Member {  get; set; }
        public int? Age { get; set; }
        public string? Grade { get; set; }
        public string? Gender { get; set; }
        */
    }
}
