using StudyTracker.Models;
using StudyTracker.Services;
using StudyTracker.ViewModels;

namespace StudyTracker.ViewModelBuilders
{
    public class CoursesVmBuilder
    {
        private readonly CourseService _courseService;
        private readonly AssignmentService _assignmentService;

        public CoursesVmBuilder(CourseService courseService, AssignmentService assignmentService)
        {
            _courseService = courseService;
            _assignmentService = assignmentService;
        }

        public async Task<CoursesVm> GetCoursesVmAsync()
        {
            var courses = await _courseService.GetAllAsync();
            var assignments = await _assignmentService.GetAllAsync();

            return new CoursesVm
            {
                Courses = courses,
                Assignments = assignments
            };
        }
    }
}
