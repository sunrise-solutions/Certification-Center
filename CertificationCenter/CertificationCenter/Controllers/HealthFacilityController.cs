using HealthFacility.Commands;
using HealthFacility.Data;
using HealthFacility.Handlers;
using HealthFacility.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<MedicalHealthFacility> GetHealthFacilityById(int id)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            GetHealthFacilityByIdHandler handler = new GetHealthFacilityByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost("[action]")]
        public bool CreateHealthFacility([FromBody] CreateHealthFacitityCommand request)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            CreateHealthFacilityHandler handler = new CreateHealthFacilityHandler(context);
            return handler.Handle(request);
        }
    }
}
