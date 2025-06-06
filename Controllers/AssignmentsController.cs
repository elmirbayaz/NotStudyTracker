using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyTracker.Models;
using StudyTracker.Services;
using StudyTracker.ViewModels;

namespace StudyTracker.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AssignmentService _svc;
        private readonly CourseService _courseSvc;

        public AssignmentsController(AssignmentService svc, CourseService courseSvc)
        {
            _svc = svc;
            _courseSvc = courseSvc;
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var vm = new AssignmentVm();
            var courses = await _courseSvc.GetAllAsync();
            vm.Courses = courses.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
            vm.Statuses = Enum.GetValues<AssignmentStatus>()
                              .Select(s => new SelectListItem(s.ToString(), s.ToString()))
                              .ToList();

            if (id.HasValue)
            {
                var a = await _svc.GetByIdAsync(id.Value);
                if (a == null) return NotFound();
                vm.Id = a.Id;
                vm.Title = a.Title;
                vm.Description = a.Description;  
                vm.Deadline = a.Deadline;        
                vm.Status = a.Status.ToString();
                vm.CourseId = a.CourseId;
            }

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(AssignmentVm vm)
        {
            var courses = await _courseSvc.GetAllAsync();
            vm.Courses = courses.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
            vm.Statuses = Enum.GetValues<AssignmentStatus>()
                              .Select(s => new SelectListItem(s.ToString(), s.ToString()))
                              .ToList();

            if (!ModelState.IsValid) return View(vm);

            var assignment = new Assignment
            {
                Id = vm.Id ?? 0,
                Title = vm.Title,
                Description = vm.Description, 
                Deadline = vm.Deadline,        
                Status = Enum.Parse<AssignmentStatus>(vm.Status),
                CourseId = vm.CourseId!.Value
            };

            await _svc.AddOrUpdateAsync(assignment);
            return RedirectToAction("Index", "Courses");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return RedirectToAction("Index", "Courses");
        }
    }
}
