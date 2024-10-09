using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace StudyAbroad.Models
{
    public class AbroadContext : DbContext
    {
        public AbroadContext(DbContextOptions<AbroadContext> options) : base(options) { }
        public DbSet<Institution> Institutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>().HasData(
                new Institution
                {
                    InstitutionID = 1,
                    Name = "Northwestern Michigan College",
                    Education = Institution.EducationType.College,
                    Type = Institution.SchoolType.Public,
                    Country = "United States",
                    Region = "Michigan",
                    URL = "https://www.nmc.edu/"
                },
                new Institution
                {
                    InstitutionID = 2,
                    Name = "Georgian College",
                    Education = Institution.EducationType.College,
                    Type = Institution.SchoolType.Public,
                    Country = "Canada",
                    Region = "Ontario",
                    URL = "https://www.georgiancollege.ca/"
                },
                new Institution
                {
                    InstitutionID = 3,
                    Name = "Enderun Colleges",
                    Education = Institution.EducationType.College,
                    Type = Institution.SchoolType.Private,
                    Country = "Philippines",
                    Region = "National Capital Region",
                    URL = "https://www.enderuncolleges.com/"
                },
                new Institution
                {
                    InstitutionID = 4,
                    Name = "Regents University London",
                    Education = Institution.EducationType.University,
                    Type = Institution.SchoolType.Private,
                    Country = "United Kingdom",
                    Region = "Greater London",
                    URL = "https://www.regents.ac.uk/"
                },
                new Institution
                {
                    InstitutionID = 5,
                    Name = "University of Limerick",
                    Education = Institution.EducationType.University,
                    Type = Institution.SchoolType.Public,
                    Country = "Ireland",
                    Region = "Munster",
                    URL = "https://www.ul.ie/"
                },
                new Institution
                {
                    InstitutionID = 6,
                    Name = "Private University of Applied Sciences, Goettingen",
                    Education = Institution.EducationType.University,
                    Type = Institution.SchoolType.Private,
                    Country = "Germany",
                    Region = "Niedersachsen",
                    URL = "https://www.pfh.de/en"
                },
                new Institution
                {
                    InstitutionID = 7,
                    Name = "Musashino Higashi Middle School",
                    Education = Institution.EducationType.Middle,
                    Type = Institution.SchoolType.Private,
                    Country = "Japan",
                    Region = "Tokyo",
                    URL = "https://www.musashino-higashi.org/chugaku/"
                },
                new Institution
                {
                    InstitutionID = 8,
                    Name = "International College of Technology, Kanazawa",
                    Education = Institution.EducationType.High,
                    Type = Institution.SchoolType.Private,
                    Country = "Japan",
                    Region = "Ishikawa",
                    URL = "https://www.ict-kanazawa.ac.jp/"
                },
                new Institution
                {
                    InstitutionID = 9,
                    Name = "Toin Gakuen",
                    Education = Institution.EducationType.High,
                    Type = Institution.SchoolType.Private,
                    Country = "Japan",
                    Region = "Kanagawa",
                    URL = "https://toin.ac.jp/ses/"
                },
                new Institution
                {
                    InstitutionID = 10,
                    Name = "University of Tokyo",
                    Education = Institution.EducationType.University,
                    Type = Institution.SchoolType.Public,
                    Country = "Japan",
                    Region = "Tokyo",
                    URL = "https://www.u-tokyo.ac.jp/ja/index.html"
                }
            );
        }
    }
}
