using Microsoft.AspNetCore.Mvc;
using Question.Commands;
using Question.Data;
using Question.Handlers;
using System.Collections.Generic;

namespace CertificationCenter.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        [HttpGet("{topic:int:min(1)}")]
        public IEnumerable<Question.Model.Question> GetQuestionsByTopic(int topic/*, int course*/)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            GetQuestionsByTopicHandler handler = new GetQuestionsByTopicHandler(context);
            return handler.Handle(topic/*, course*/);
        }

        [HttpPost]
        public bool CreateQuestion([FromBody] CreateQuestionCommand request)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            CreateQuestionHandler handler = new CreateQuestionHandler(context);
            return handler.Handle(request);
        }

        [HttpDelete("{id:int:min(1)}")]
        public bool DeleteQuestion(int id, int topicId, int courseId)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            DeleteQuestionHandler handler = new DeleteQuestionHandler(context);
            return handler.Handle(id, topicId, courseId);
        }

        [HttpPut("{id:int:min(1)}")]
        public bool UpdateQuestion(int id, [FromBody] CreateQuestionCommand request)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            UpdateQuestionHandler handler = new UpdateQuestionHandler(context);
            return handler.Handle(id, request);
        }
    }
}
