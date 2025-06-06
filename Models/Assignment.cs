namespace StudyTracker.Models
{
    public enum AssignmentStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }

        public AssignmentStatus Status { get; set; } = AssignmentStatus.NotStarted;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
