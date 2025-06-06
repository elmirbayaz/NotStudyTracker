using StudyTracker.Models;

namespace StudyTracker.ViewModels
{
    public class CoursesVm
    {
        public List<Course> Courses { get; set; }
        public List<Assignment> Assignments { get; set; }

        public CoursesVm(List<Course> courses, List<Assignment> assignments)
        {
            this.Courses = courses;
            this.Assignments = assignments;
        }


        public CoursesVm(List<Course> courses)
        {
            this.Courses = courses;
            this.Assignments = new List<Assignment>();
        }

        public CoursesVm()
        {
            Courses = new List<Course>();
            Assignments = new List<Assignment>();
        }
    }
}
