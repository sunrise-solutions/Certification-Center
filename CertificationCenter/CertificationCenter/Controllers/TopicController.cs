using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Topic.Commands;
using Topic.Data;
using Topic.Handlers;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Topic.Model.Topic> GetAllTopicsTests()
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            GetAllTopicsHandler handler = new GetAllTopicsHandler(context);
            return handler.Handle();
        }

        [HttpGet("[action]")]
        public IEnumerable<Topic.Model.Topic> GetTopicById(int id)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            GetTopicByIdHandler handler = new GetTopicByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost("[action]")]
        public bool CreateTopic([FromBody] CreateTopicCommand request)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            CreateTopicHandler handler = new CreateTopicHandler(context);
            return handler.Handle(request);
        }
    }
}
