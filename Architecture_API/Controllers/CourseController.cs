using Architecture_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Architecture_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var results = await _courseRepository.GetAllCourseAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        [HttpGet]
        [Route("GetCourse/{courseId}")]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            try
            {
                var results = await _courseRepository.GetCourseAsync(courseId);

                if (results == null) return NotFound("Course not Found");

                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        [HttpPut]
        [Route("UpdateCourse/{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, Course course)
        {
            try
            {
                var results = await _courseRepository.UpdateCourseAsync(courseId,course);
                return Ok(new { message = results });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        [HttpPost]
        [Route("DeleteCourse/{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            try
            {
                var results = await _courseRepository.DeleteCourseAsync(courseId);
                return Ok(new { message = results });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        [HttpPost]
        [Route("AddCourse")]
        public async Task<IActionResult> AddCourse(Course crse)
        {
            string result;
            var course = new Course
            {
                Name= crse.Name,
                Duration=crse.Duration,
                Description=crse.Description
            };

            try
            {
                 result= await _courseRepository.AddCourseAsync(course);
               
            }
            catch (Exception)
            {
                return BadRequest("Invalid Transaction");
            }

            return Ok(new { message = result });
        }





    }
}
