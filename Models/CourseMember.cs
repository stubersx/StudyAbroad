namespace StudyAbroad.Models
{
    public class CourseMember
    {
        public int CourseID { get; set; }
        public Course? Course { get; set; }
        public int MemberID { get; set; }
        public Member? Member { get; set; }
    }
}
