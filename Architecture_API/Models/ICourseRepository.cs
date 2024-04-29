using Microsoft.AspNetCore.Mvc;

namespace Architecture_API.Models
{
    public interface ICourseRepository
    {
        // Course
        Task<Course[]> GetAllCourseAsync();

        Task<Course?> GetCourseAsync(int courseId);

        Task<string> UpdateCourseAsync(int courseId,Course course);

        Task<string> AddCourseAsync(Course course);

        Task<string> DeleteCourseAsync(int courseId);


    }
}
