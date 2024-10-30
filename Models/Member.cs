using System.ComponentModel.DataAnnotations;

namespace StudyAbroad.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Member
    {
        public int MemberID { get; set; }
        [Required(ErrorMessage = "Please enter your first name (50 characters or less).")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Please enter your first name (50 characters or less).")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your last name (50 characters or less).")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Please enter your last name (50 characters or less).")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select your gender.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Please enter your age (between 3 and 125).")]
        [Range(3, 125, ErrorMessage = "Please enter your age (between 3 and 125).")]
        public int Age { get; set; }
        [Range(1, 12, ErrorMessage = "Please enter your grade if applicable (between 1 and 12).")]
        public int? Grade { get; set; }
        [Required(ErrorMessage = "Please enter your country (30 characters or less).")]
        [StringLength(30, ErrorMessage = "Please enter your country (30 characters or less).")]
        public string Country { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your region (30 characters or less).")]
        [Display(Name = "State / Province / Prefecture")]
        [StringLength(30, ErrorMessage = "Please enter your region (30 characters or less).")]
        public string Region { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your registration date.")]
        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public string? Note { get; set; }

        /* public string Email { get; set; } - Use Register/Login Information? */
    }
}
