using Microsoft.EntityFrameworkCore;
using StudyTracker.Data;
using StudyTracker.Models;

namespace StudyTracker.Repositories
{
    public class AssignmentRepository
    {
        private readonly ApplicationDbContext _db;

        public AssignmentRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Assignment>> GetAllAsync()
            => await _db.Assignments.Include(a => a.Course).ToListAsync();

        public async Task<Assignment?> GetByIdAsync(int id)
            => await _db.Assignments.Include(a => a.Course)
                                    .FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(Assignment assignment)
        {
            _db.Assignments.Add(assignment);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            _db.Assignments.Update(assignment);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a = await _db.Assignments.FindAsync(id);
            if (a != null)
            {
                _db.Assignments.Remove(a);
                await _db.SaveChangesAsync();
            }
        }
    }
}
