using Microsoft.AspNetCore.Mvc;
using StudyTracker.Models;
using StudyTracker.Services;
using StudyTracker.ViewModelBuilders;
using System.Threading.Tasks;

namespace StudyTracker.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseService _courseService;
        private readonly CoursesVmBuilder _vmBuilder;

        public CoursesController(CourseService courseService, CoursesVmBuilder vmBuilder)
        {
            _courseService = courseService;
            _vmBuilder = vmBuilder;
        }

        // GET: /Courses
        public async Task<IActionResult> Index()
        {
            var vm = await _vmBuilder.GetCoursesVmAsync();
            return View(vm);
        }

        // GET: /Courses/CreateOrEdit/5
        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            if (id == null) return View(new Course());  
            var course = await _courseService.GetByIdAsync(id.Value);  
            if (course == null) return NotFound();  
            return View(course);  
        }

        // POST: /Courses/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Course course)
        {
            if (!ModelState.IsValid)
                return View(course);

            if (course.Id == 0) 
                await _courseService.AddAsync(course);  
            else 
                await _courseService.UpdateAsync(course);  

            return RedirectToAction(nameof(Index));  
        }

        // POST: /Courses/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteAsync(id);  
            return RedirectToAction(nameof(Index));  
        }
    }
}
