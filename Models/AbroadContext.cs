using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace StudyAbroad.Models
{
    public class AbroadContext : DbContext
    {
        public AbroadContext(DbContextOptions<AbroadContext> options) : base(options) { }
        public DbSet<MyBoard> MyBoards { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>().HasData(
                new Institution
                {
                    InstitutionID = 1,
                    Name = "Northwestern Michigan College",
                    Education = EducationType.College,
                    Type = SchoolType.Public,
                    Country = "United States",
                    Region = "Michigan",
                    URL = "https://www.nmc.edu/"
                },
                new Institution
                {
                    InstitutionID = 2,
                    Name = "Georgian College",
                    Education = EducationType.College,
                    Type = SchoolType.Public,
                    Country = "Canada",
                    Region = "Ontario",
                    URL = "https://www.georgiancollege.ca/"
                },
                new Institution
                {
                    InstitutionID = 3,
                    Name = "Enderun Colleges",
                    Education = EducationType.College,
                    Type = SchoolType.Private,
                    Country = "Philippines",
                    Region = "National Capital Region",
                    URL = "https://www.enderuncolleges.com/"
                },
                new Institution
                {
                    InstitutionID = 4,
                    Name = "Regents University London",
                    Education = EducationType.University,
                    Type = SchoolType.Private,
                    Country = "United Kingdom",
                    Region = "Greater London",
                    URL = "https://www.regents.ac.uk/"
                },
                new Institution
                {
                    InstitutionID = 5,
                    Name = "University of Limerick",
                    Education = EducationType.University,
                    Type = SchoolType.Public,
                    Country = "Ireland",
                    Region = "Munster",
                    URL = "https://www.ul.ie/"
                },
                new Institution
                {
                    InstitutionID = 6,
                    Name = "Private University of Applied Sciences, Goettingen",
                    Education = EducationType.University,
                    Type = SchoolType.Private,
                    Country = "Germany",
                    Region = "Niedersachsen",
                    URL = "https://www.pfh.de/en"
                },
                new Institution
                {
                    InstitutionID = 7,
                    Name = "Musashino Higashi Middle School",
                    Education = EducationType.Middle,
                    Type = SchoolType.Private,
                    Country = "Japan",
                    Region = "Tokyo",
                    URL = "https://www.musashino-higashi.org/chugaku/"
                },
                new Institution
                {
                    InstitutionID = 8,
                    Name = "International College of Technology, Kanazawa",
                    Education = EducationType.High,
                    Type = SchoolType.Private,
                    Country = "Japan",
                    Region = "Ishikawa",
                    URL = "https://www.ict-kanazawa.ac.jp/"
                },
                new Institution
                {
                    InstitutionID = 9,
                    Name = "Toin Gakuen",
                    Education = EducationType.High,
                    Type = SchoolType.Private,
                    Country = "Japan",
                    Region = "Kanagawa",
                    URL = "https://toin.ac.jp/ses/"
                },
                new Institution
                {
                    InstitutionID = 10,
                    Name = "University of Tokyo",
                    Education = EducationType.University,
                    Type = SchoolType.Public,
                    Country = "Japan",
                    Region = "Tokyo",
                    URL = "https://www.u-tokyo.ac.jp/ja/index.html"
                }
            );
            modelBuilder.Entity<MyBoard>().HasData(
                new MyBoard { ID = 1, InstitutionID = 2 },
                new MyBoard { ID = 2, InstitutionID = 6 },
                new MyBoard { ID = 3, InstitutionID = 2 },
                new MyBoard { ID = 4, InstitutionID = 1 },
                new MyBoard { ID = 5, InstitutionID = 9 }
            );
        }
    }
}
