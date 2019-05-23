using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Test.Commands;
using Test.Data;
using Test.Handlers;
using Test.Model;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IEnumerable<TrainingTest> GetAllTrainingTests()
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            GetAllTestsHandler handler = new GetAllTestsHandler(context);
            return handler.Handle();
        }

        [HttpGet("{id:int:min(1)}")]
        public TrainingTest GetTrainingTestById(int id)
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            GetTestByIdHandler handler = new GetTestByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost]
        public bool CreateTrainingTest([FromBody] CreateTestCommand request)
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            CreateTestHandler handler = new CreateTestHandler(context);
            return handler.Handle(request);
        }

        [HttpPut("{id:int:min(1)}")]
        public bool UpdateTrainingTest(int id, [FromBody] CreateTestCommand request)
        {
            TestContext context = HttpContext.RequestServices.GetService(typeof(TestContext)) as TestContext;
            UpdateTestHandler handler = new UpdateTestHandler(context);
            return handler.Handle(id, request);
        }
    }
}
