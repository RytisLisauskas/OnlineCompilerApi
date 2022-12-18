using Microsoft.AspNetCore.Mvc;
using OnlineCompiler.Models.DTO;
using OnlineCompiler.Services;

namespace OnlineCompiler.Controllers
{   [ApiController]
    [Route("/questions")]
    public class QuestionnaireController : Controller
    {

        private readonly IQuestionService _questionService;

        public QuestionnaireController(IQuestionService service)
        {
            _questionService = service;
        }

        [HttpPost]
        [Route("/add-question")]
        public IActionResult AddQuestion([FromBody] QuestionDTO question)
        {
            var result = _questionService.AddQuestion(question);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var result = _questionService.GetQuestions();
            return Ok(result);
        }

        [HttpPost]
        [Route("/delete-question/{id}")]
        public IActionResult DeleteQuestion([FromRoute] Guid id)
        { 
            var result = _questionService.DeleteQuestion(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        [Route("/question/{id}")]
        public IActionResult GetQuestionById([FromRoute] Guid id)
        { 
            var result = _questionService.GetQuestionById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
