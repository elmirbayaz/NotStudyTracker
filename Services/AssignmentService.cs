using Microsoft.EntityFrameworkCore;
using StudyTracker.Data;
using StudyTracker.Models;

namespace StudyTracker.Services
{
    public class AssignmentService
    {
        private readonly ApplicationDbContext _context;

        public AssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Assignment>> GetAllAsync()
        {
            return await _context.Assignments
                .Include(a => a.Course)
                .ToListAsync();
        }


        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddOrUpdateAsync(Assignment assignment)
        {
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == assignment.CourseId);
            if (!courseExists)
                throw new InvalidOperationException("Курс не найден.");

           
            if (assignment.Id == 0)
                _context.Assignments.Add(assignment); 
            else
                _context.Assignments.Update(assignment); 

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
