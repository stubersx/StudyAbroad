using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace StudyAbroad.Models
{
    public class AbroadContext : DbContext
    {
        public AbroadContext(DbContextOptions<AbroadContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<MyBoard> MyBoards { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>().HasData(
                new Institution
                {
                    InstitutionID = 1,
                    Name = "Northwestern Michigan College",
                    Education = Education.College,
                    Type = SchoolType.Public,
                    Country = "United States",
                    Region = "Michigan",
                    URL = "https://www.nmc.edu/",
                    DormAvailable = true,
                    MealPlanAvailable = true
                },
                new Institution
                {
                    InstitutionID = 2,
                    Name = "Georgian College",
                    Education = Education.College,
                    Type = SchoolType.Public,
                    Country = "Canada",
                    Region = "Ontario",
                    URL = "https://www.georgiancollege.ca/",
                    DormAvailable = true,
                    MealPlanAvailable = true
                },
                new Institution
                {
                    InstitutionID = 3,
                    Name = "Enderun Colleges",
                    Education = Education.College,
                    Type = SchoolType.Private,
                    Country = "Philippines",
                    Region = "National Capital Region",
                    URL = "https://www.enderuncolleges.com/",
                    DormAvailable = true,
                    MealPlanAvailable = false
                },
                new Institution
                {
                    InstitutionID = 4,
                    Name = "Regents University London",
                    Education = Education.University,
                    Type = SchoolType.Private,
                    Country = "United Kingdom",
                    Region = "Greater London",
                    URL = "https://www.regents.ac.uk/",
                    DormAvailable = true,
                    MealPlanAvailable = false
                },
                new Institution
                {
                    InstitutionID = 5,
                    Name = "University of Limerick",
                    Education = Education.University,
                    Type = SchoolType.Public,
                    Country = "Ireland",
                    Region = "Munster",
                    URL = "https://www.ul.ie/",
                    DormAvailable = true,
                    MealPlanAvailable = true
                },
                new Institution
                {
                    InstitutionID = 6,
                    Name = "Private University of Applied Sciences, Goettingen",
                    Education = Education.University,
                    Type = SchoolType.Private,
                    Country = "Germany",
                    Region = "Niedersachsen",
                    URL = "https://www.pfh.de/en",
                    DormAvailable = true,
                    MealPlanAvailable = false
                },
                new Institution
                {
                    InstitutionID = 7,
                    Name = "Musashino Higashi Middle School",
                    Education = Education.Middle,
                    Type = SchoolType.Private,
                    Country = "Japan",
                    Region = "Tokyo",
                    URL = "https://www.musashino-higashi.org/chugaku/",
                    DormAvailable = false,
                    MealPlanAvailable = true
                },
                new Institution
                {
                    InstitutionID = 8,
                    Name = "International College of Technology, Kanazawa",
                    Education = Education.High,
                    Type = SchoolType.Private,
                    Country = "Japan",
                    Region = "Ishikawa",
                    URL = "https://www.ict-kanazawa.ac.jp/",
                    DormAvailable = true,
                    MealPlanAvailable = false
                },
                new Institution
                {
                    InstitutionID = 9,
                    Name = "Toin Gakuen",
                    Education = Education.High,
                    Type = SchoolType.Private,
                    Country = "Japan",
                    Region = "Kanagawa",
                    URL = "https://toin.ac.jp/ses/",
                    DormAvailable = true,
                    MealPlanAvailable = false
                },
                new Institution
                {
                    InstitutionID = 10,
                    Name = "University of Tokyo",
                    Education = Education.University,
                    Type = SchoolType.Public,
                    Country = "Japan",
                    Region = "Tokyo",
                    URL = "https://www.u-tokyo.ac.jp/ja/index.html",
                    DormAvailable = true,
                    MealPlanAvailable = false
                }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseID = 1,
                    Name = "ESL: English as a Second Language",
                    ContactHours = 20,
                    Duration = 24,
                    Tuition = 7500,
                    Prerequisites = "TOEIC 400 or higher",
                    Description = "Improve your listening, reading, writing, and speaking skills.",
                    InstitutionID = 1
                },
                new Course
                {
                    CourseID = 2,
                    Name = "Summer Program",
                    ContactHours = 20,
                    Duration = 8,
                    Tuition = 5000,
                    Description = "Learn about American culture and gain valuable experience with locals.",
                    InstitutionID = 1
                },
                new Course
                {
                    CourseID = 3,
                    Name = "Exchange Program",
                    ContactHours = 40,
                    Duration = 48,
                    Tuition = 15000,
                    Prerequisites = "JLPT 2 or higher",
                    Description = "Choose a local major and learn with local students.",
                    InstitutionID = 10
                },
                new Course
                {
                    CourseID = 4,
                    Name = "Exchange Program",
                    ContactHours = 20,
                    Duration = 24,
                    Tuition = 8000,
                    Prerequisites = "TOEFL 100 or higher",
                    Description = "Choose a major and learn with local students.",
                    InstitutionID = 4
                },
                new Course
                {
                    CourseID = 5,
                    Name = "Language Program",
                    ContactHours = 12,
                    Duration = 12,
                    Tuition = 5500,
                    Prerequisites = "TOEIC 400 or higher",
                    Description = "Learn German by taking listening, reading, writing, and speaking classes.",
                    InstitutionID = 6
                },
                new Course
                {
                    CourseID = 6,
                    Name = "Summer Program",
                    ContactHours = 20,
                    Duration = 4,
                    Tuition = 2500,
                    Description = "Learn about Japanese culture and gain valuable experience with locals.",
                    InstitutionID = 7
                }
            );
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberID = 1,
                    FirstName = "Clarice",
                    LastName = "Langston",
                    Gender = Gender.Female,
                    Age = 17,
                    Grade = 12,
                    Country = "United States",
                    Region = "Michigan",
                    RegistrationDate = DateTime.Parse("2024-10-27"),
                },
                new Member
                {
                    MemberID = 2,
                    FirstName = "Alden",
                    LastName = "Ellisson",
                    Gender = Gender.Male,
                    Age = 20,
                    Country = "United States",
                    Region = "Florida",
                    RegistrationDate = DateTime.Parse("2024-9-10"),
                },
                new Member
                {
                    MemberID = 3,
                    FirstName = "Lucas",
                    LastName = "Barre",
                    Gender = Gender.Male,
                    Age = 22,
                    Country = "France",
                    Region = "Paris",
                    RegistrationDate = DateTime.Parse("2024-10-14"),
                },
                new Member
                {
                    MemberID = 4,
                    FirstName = "Roberta",
                    LastName = "Garza",
                    Gender = Gender.Female,
                    Age = 14,
                    Grade = 9,
                    Country = "Spain",
                    Region = "Madrid",
                    RegistrationDate = DateTime.Parse("2024-8-17"),
                },
                new Member
                {
                    MemberID = 5,
                    FirstName = "Danny",
                    LastName = "Salmon",
                    Gender = Gender.Male,
                    Age = 19,
                    Country = "United Kingdom",
                    Region = "London",
                    RegistrationDate = DateTime.Parse("2024-9-22"),
                }
            );
            modelBuilder.Entity<MyBoard>().HasData(
                new MyBoard
                {
                    ID = 1,
                    MemberID = 4,
                    InstitutionID = 7,
                    CourseID = 6,
                    Semester = Semester.Summer,
                    Year = 2025,
                    HousingType = "Homestay",
                    HousingCost = 1200,
                    MoveInDate = DateTime.Parse("2025-6-20"),
                    PropertyOwner = "Riku Aoki",
                    Contact = "090-5566-1234",
                    HousingWebsite = "https://homestay/housing1",
                    AddressLine1 = "2-6 Midori-cho",
                    City = "Koganei",
                    Region = "Tokyo",
                    ZipCode = "184-0003",
                    Country = "Japan"
                },
                new MyBoard
                { 
                    ID = 2,
                    MemberID = 2,
                    InstitutionID = 10,
                    CourseID = 3,
                    Semester = Semester.Spring,
                    Year = 2025,
                    HousingType = "Dormitory",
                    HousingCost = 800,
                    MoveInDate = DateTime.Parse("2025-8-25"),
                    PropertyOwner = "Kazumi Saitou",
                    Contact = "080-2233-5678",
                    HousingWebsite = "https://dorm/housing2",
                    AddressLine1 = "7-3 Hongou",
                    City = "Bunkyo-ku",
                    Region = "Tokyo",
                    ZipCode = "113-8654",
                    Country = "Japan",
                    MealCost = 800
                },
                new MyBoard
                { 
                    ID = 3,
                    MemberID = 5,
                    InstitutionID = 6,
                    CourseID = 5,
                    Semester = Semester.Spring,
                    Year = 2025
                },
                new MyBoard
                { 
                    ID = 4,
                    MemberID = 3,
                    InstitutionID = 1,
                    CourseID = 1,
                    Semester = Semester.Fall,
                    Year = 2025,
                    HousingType = "Appartment",
                    HousingCost = 700,
                    AdditionalCost = 500,
                    MoveInDate = DateTime.Parse("2025-8-25"),
                    PropertyOwner = "Jon Green",
                    Contact = "231-226-1234",
                    HousingWebsite = "https://appartment/housing3",
                    AddressLine1 = "1701 E Front St.",
                    AddressLine2 = "Apt. 204",
                    City = "Traverse City",
                    Region = "Michigan",
                    ZipCode = "49686",
                    Country = "United States",
                    MealPlan = "PLAN B",
                    MealCost = 1550
                },
                new MyBoard
                {
                    ID = 5,
                    MemberID = 1,
                    Semester = Semester.Fall,
                    Year = 2026
                }
            );
        }
    }
}
