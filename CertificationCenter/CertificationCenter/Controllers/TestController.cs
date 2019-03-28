using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Commands;
using Test.Data;
using Test.Model;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<TrainingTest> GetAllTrainingTests()
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            return context.GetAllTrainingTests();
        }

        [HttpGet("[action]")]
        public IEnumerable<TrainingTest> GetTrainingTestById(int id)
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            return context.GetTrainingTestById(id);
        }

        [HttpPost("[action]")]
        public bool CreateTrainingTest([FromBody] CreateTestCommand request)
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            var test = request.Adapt<TrainingTest>();
            return context.CreateTrainingTest(test);
        }
    }
}
