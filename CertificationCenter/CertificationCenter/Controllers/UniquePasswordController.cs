using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniquePassword.Commands;
using UniquePassword.Data;
using UniquePassword.Handlers;
using UniquePassword.Model;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class UniquePasswordController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<EverydayUniquePassword> GetUniquePasswordByDate(DateTime date)
        {
            UniquePasswordContext context = HttpContext.RequestServices.GetService(typeof(UniquePasswordContext)) as UniquePasswordContext;
            GetUniquePasswordByDateHandler handler = new GetUniquePasswordByDateHandler(context);
            return handler.Handle(date);
        }

        [HttpPost("[action]")]
        public bool CreateUniquePassword([FromBody] CreateUniquePasswordCommand request)
        {
            UniquePasswordContext context = HttpContext.RequestServices.GetService(typeof(UniquePasswordContext)) as UniquePasswordContext;
            CreateUniquePasswordHandler handler = new CreateUniquePasswordHandler(context);
            return handler.Handle(request);
        }
    }
}
