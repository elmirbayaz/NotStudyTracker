using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudyTracker.ViewModels
{
    public class AssignmentVm
    {
        public int? Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public DateTime? Deadline { get; set; }  
        public string Status { get; set; } = null!;
        public int? CourseId { get; set; }

        public List<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Statuses { get; set; } = new List<SelectListItem>();
    }
}
