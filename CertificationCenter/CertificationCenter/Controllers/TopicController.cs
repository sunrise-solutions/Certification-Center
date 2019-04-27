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
        public IEnumerable<Topic.Model.Topic> GetAllTopics()
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

        [HttpGet("[action]")]
        public IEnumerable<Topic.Model.Topic> GetTopicsByCourseId(int courseId)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            GetTopicsByCourseIdHandler handler = new GetTopicsByCourseIdHandler(context);
            return handler.Handle(courseId);
        }

        [HttpPost("[action]")]
        public bool CreateTopic([FromBody] CreateTopicCommand request)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            CreateTopicHandler handler = new CreateTopicHandler(context);
            return handler.Handle(request);
        }

        [HttpDelete("[action]")]
        public bool DeleteTopic(int topicId, int courseId)
        {
            TopicContext context = HttpContext.RequestServices.GetService(typeof(TopicContext)) as TopicContext;
            DeleteTopicHandler handler = new DeleteTopicHandler(context);
            return handler.Handle(topicId, courseId);
        }
    }
}
