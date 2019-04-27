using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Specialist.Commands;
using Specialist.Data;
using Specialist.Model;
using Specialist.Handlers;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class SpecialistController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<MedicalSpecialist> GetAllMedicalSpecialists()
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetAllSpecialistsHandler handler = new GetAllSpecialistsHandler(context);
            return handler.Handle();
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalSpecialist> GetMedicalSpecialistById(int id)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetSpecialistByIdHandler handler = new GetSpecialistByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalSpecialist> GetMedicalSpecialistByEmailAndPassword(string email, string password)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            GetSpecialistByEmailAndPasswordHandler handler = new GetSpecialistByEmailAndPasswordHandler(context);
            return handler.Handle(email, password);
        }

        [HttpPost("[action]")]
        public bool CreateMedicalSpecialist([FromBody] CreateSpecialistCommand request)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            CreateSpecialistHandler handler = new CreateSpecialistHandler(context);
            return handler.Handle(request);
        }
    }
}
