using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Specialist.Commands;
using Specialist.Data;
using Specialist.Model;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class SpecialistController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<MedicalSpecialist> GetAllMedicalSpecialists()
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            return context.GetAllSpecialists();
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalSpecialist> GetMedicalSpecialistById(int id)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            return context.GetSpecialistById(id);
        }

        [HttpPost("[action]")]
        public bool CreateMedicalSpecialist([FromBody] CreateSpecialistCommand request)
        {
            SpecialistContext context = HttpContext.RequestServices.GetService(typeof(SpecialistContext)) as SpecialistContext;
            var specialist = request.Adapt<MedicalSpecialist>();
            string tempHash = Hash.FindHash(specialist.PasswordHash);
            specialist.PasswordHash = tempHash;
            return context.CreateSpecialist(specialist);
        }
    }
}
