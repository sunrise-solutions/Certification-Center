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
        [HttpGet]
        public IEnumerable<MedicalHealthFacility> GetAllHealthFacilities()
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            GetAllHealthFacilitiesHandler handler = new GetAllHealthFacilitiesHandler(context);
            return handler.Handle();
        }

        [HttpGet("{id:int:min(1)}")]
        public IEnumerable<MedicalHealthFacility> GetHealthFacilityById(int id)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            GetHealthFacilityByIdHandler handler = new GetHealthFacilityByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost]
        public bool CreateHealthFacility([FromBody] CreateHealthFacitityCommand request)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            CreateHealthFacilityHandler handler = new CreateHealthFacilityHandler(context);
            return handler.Handle(request);
        }

        [HttpPut("{id:int:min(1)}")]
        public bool UpdateHealthFacility(int id, [FromBody] CreateHealthFacitityCommand request)
        {
            HealthFacilityContext context = HttpContext.RequestServices.GetService(typeof(HealthFacilityContext)) as HealthFacilityContext;
            UpdateHealthFacilityHandler handler = new UpdateHealthFacilityHandler(context);
            return handler.Handle(id, request);
        }
    }
}
