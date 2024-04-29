using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace Architecture_API.Models
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Course[]> GetAllCourseAsync()
        {
            IQueryable<Course> query = _appDbContext.Courses;
            return await query.ToArrayAsync();
        }

        public async Task<Course?> GetCourseAsync(int courseId)
        {
            IQueryable<Course> query = _appDbContext.Courses.Where(c => c.CourseId == courseId);
            return await query.SingleOrDefaultAsync();
        }


        public async Task<string> UpdateCourseAsync(int courseId,Course updatedCourse)
        {
            var existingCourse = await _appDbContext.Courses.FindAsync(courseId);

            if (existingCourse == null) return "Course not Found";

            existingCourse.Name = updatedCourse.Name;

            existingCourse.Duration = updatedCourse.Duration;

            existingCourse.Description = updatedCourse.Description;
           
            await _appDbContext.SaveChangesAsync();
            return "Course updated successfully.";
        }

        public async Task<string> DeleteCourseAsync(int courseId)
        {
            var courseToDelete = await _appDbContext.Courses.FindAsync(courseId);

            if (courseToDelete == null)
            {
                return "Course not found."; 
            }

            _appDbContext.Courses.Remove(courseToDelete);
            await _appDbContext.SaveChangesAsync();

            return "Course deleted successfully."; 
        }

        public async Task<string> AddCourseAsync(Course course)
        {
             _appDbContext.Add(course);
           await _appDbContext.SaveChangesAsync();
            return "Course Added successfully";
        }


    }
}
