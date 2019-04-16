using CertificationTest.Data;
using CertificationTest.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CertificationTest.Model;
using System.Threading.Tasks;
using CertificationTest.Commands;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class CertificationTestController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<CertificationTest.Model.CertificationTest> GetAllTrainingTests()
        {
            CertificationTestContext context = HttpContext.RequestServices.GetService(typeof(CertificationTestContext)) as CertificationTestContext;
            GetAllCertificationTestsHandler handler = new GetAllCertificationTestsHandler(context);
            return handler.Handle();
        }

        [HttpGet("[action]")]
        public IEnumerable<CertificationTest.Model.CertificationTest> GetTrainingTestById(int id)
        {
            CertificationTestContext context = HttpContext.RequestServices.GetService(typeof(CertificationTestContext)) as CertificationTestContext;
            GetCertificationTestByIdHandler handler = new GetCertificationTestByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost("[action]")]
        public bool CreateTrainingTest([FromBody] CreateCertificationTestCommand request)
        {
            CertificationTestContext context = HttpContext.RequestServices.GetService(typeof(CertificationTestContext)) as CertificationTestContext;
            CreateCertificationTestHandler handler = new CreateCertificationTestHandler(context);
            return handler.Handle(request);
        }
    }
}
