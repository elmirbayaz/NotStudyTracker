using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyTracker.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название курса обязательно")]
        public string Name { get; set; }

        public string? Description { get; set; }  

        [Required(ErrorMessage = "Имя профессора обязательно")]
        public string ProfessorName { get; set; }

        public List<Assignment> Assignments { get; set; } = new();

        public Course() { }

        public Course(int id, string name, string? description, string professorName)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ProfessorName = professorName;
        }
    }
}
