using HealthFacility.Commands;
using HealthFacility.Data;
using HealthFacility.Handlers;
using HealthFacility.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class HealthFacilityController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<MedicalHealthFacility> GetAllHealthFacilities()
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            GetAllHealthFacilitiesHandler handler = new GetAllHealthFacilitiesHandler(context);
            return handler.Handle();
        }

        [HttpGet("[action]")]
        public IEnumerable<MedicalHealthFacility> GetMedicalSpecialistById(int id)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            GetHealthFacilityByIdHandler handler = new GetHealthFacilityByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost("[action]")]
        public MedicalHealthFacility CreateMedicalSpecialist([FromBody] CreateHealthFacitityCommand request)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            CreateHealthFacilityHandler handler = new CreateHealthFacilityHandler(context);
            return handler.Handle(request);
        }
    }
}
