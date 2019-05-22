using Course.Commands;
using Course.Data;
using Course.Handlers;
using Course.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<MedicalCourse> GetAllCourses()
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            GetAllCoursesHandler handler = new GetAllCoursesHandler(context);
            return handler.Handle();
        }

        [HttpGet("{id:int:min(1)}")]
        public IEnumerable<MedicalCourse> GetCourseById(int id)
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            GetCourseByIdHandler handler = new GetCourseByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost("[action]")]
        public bool CreateCourse([FromBody] CreateCourseCommand request)
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            CreateCourseHandler handler = new CreateCourseHandler(context);
            return handler.Handle(request);
        }

        [HttpPut("[action]")]
        public bool UpdateCourse(int courseId, [FromBody] CreateCourseCommand request)
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            UpdateCourseHandler handler = new UpdateCourseHandler(context);
            return handler.Handle(courseId, request);
        }
    }
}
