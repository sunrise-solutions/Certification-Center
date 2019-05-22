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
        [HttpGet]
        public IEnumerable<Topic.Model.Topic> GetAllTopics()
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            GetAllTopicsHandler handler = new GetAllTopicsHandler(context);
            return handler.Handle();
        }

        [HttpGet("{id:int:min(1)}")]
        public IEnumerable<Topic.Model.Topic> GetTopicById(int id)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            GetTopicByIdHandler handler = new GetTopicByIdHandler(context);
            return handler.Handle(id);
        }

        [HttpGet("course/{id:int:min(1)}")]
        public IEnumerable<Topic.Model.Topic> GetTopicsByCourseId(int id)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            GetTopicsByCourseIdHandler handler = new GetTopicsByCourseIdHandler(context);
            return handler.Handle(id);
        }

        [HttpPost]
        public bool CreateTopic([FromBody] CreateTopicCommand request)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            CreateTopicHandler handler = new CreateTopicHandler(context);
            return handler.Handle(request);
        }

        [HttpPut("{id:int:min(1)}")]
        public bool UpdateTopic(int id, [FromBody] CreateTopicCommand request)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            UpdateTopicHandler handler = new UpdateTopicHandler(context);
            return handler.Handle(id, request);
        }

        [HttpDelete("{id:int:min(1)}")]
        public bool DeleteTopic(int id, int courseId)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            DeleteTopicHandler handler = new DeleteTopicHandler(context);
            return handler.Handle(id, courseId);
        }
    }
}
