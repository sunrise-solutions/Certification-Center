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
        [HttpGet("[action]")]
        public IEnumerable<Question.Model.Question> GetQuestionsByTopic(int topic/*, int course*/)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            GetQuestionsByTopicHandler handler = new GetQuestionsByTopicHandler(context);
            return handler.Handle(topic/*, course*/);
        }

        [HttpPost("[action]")]
        public bool CreateQuestion([FromBody] CreateQuestionCommand request)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            CreateQuestionHandler handler = new CreateQuestionHandler(context);
            return handler.Handle(request);
        }

        [HttpDelete("[action]")]
        public bool DeleteQuestion(int questionId, int topicId, int courseId)
        {
            QuestionContext context = HttpContext.RequestServices.GetService(typeof(QuestionContext)) as QuestionContext;
            DeleteQuestionHandler handler = new DeleteQuestionHandler(context);
            return handler.Handle(questionId, topicId, courseId);
        }
    }
}
