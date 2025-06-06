using Microsoft.EntityFrameworkCore;
using StudyTracker.Data;
using StudyTracker.Models;

namespace StudyTracker.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Получить все курсы
        public async Task<List<Course>> GetAllAsync()
        {
            return await _db.Courses.ToListAsync();
        }

        // Получить курс по Id
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _db.Courses
                            .Include(c => c.Assignments)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Добавить новый курс
        public async Task AddAsync(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
        }

        // Обновить существующий курс
        public async Task UpdateAsync(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
        }

        // Удалить курс
        public async Task DeleteAsync(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
            }
        }
    }
}
