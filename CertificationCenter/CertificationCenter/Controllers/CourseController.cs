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
        [HttpGet]
        public IEnumerable<MedicalCourse> GetAllCourses()
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            GetAllCoursesHandler handler = new GetAllCoursesHandler(context);
            return handler.Handle();
        }

        [HttpGet("xml")]
        public bool WriteAllCoursesToXML()
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            WriteAllCoursesToXMLHandler handler = new WriteAllCoursesToXMLHandler(context);
            return handler.Handle();
        }

        [HttpGet("xls")]
        public bool WriteAllCoursesToXLS()
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            WriteAllCoursesToXLSHandler handler = new WriteAllCoursesToXLSHandler(context);
            return handler.Handle();
        }

        [HttpGet("{id:int:min(1)}")]
        public MedicalCourse GetCourseById(int id)
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            GetCourseByIdHandler handler = new GetCourseByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost]
        public bool CreateCourse([FromBody] CreateCourseCommand request)
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            CreateCourseHandler handler = new CreateCourseHandler(context);
            return handler.Handle(request);
        }

        [HttpPut("{id:int:min(1)}")]
        public bool UpdateCourse(int id, [FromBody] CreateCourseCommand request)
        {
            CourseContext context = HttpContext.RequestServices.GetService(typeof(CourseContext)) as CourseContext;
            UpdateCourseHandler handler = new UpdateCourseHandler(context);
            return handler.Handle(id, request);
        }
    }
}
