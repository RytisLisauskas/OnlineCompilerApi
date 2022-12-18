using Microsoft.AspNetCore.Mvc;
using OnlineCompiler.Models;
using OnlineCompiler.Services;

namespace OnlineCompiler.Controllers
{
    [ApiController]
    [Route("/api")]
    public class CompilerController : Controller
    {
        public ICompilatingService _compilationService;

        public CompilerController(ICompilatingService service)
        {
            _compilationService = service;
        }
       
        [HttpPost]
        [Route("/compile")]
        public async Task<IActionResult> ExecuteProgram(
            [FromBody] CompilationRequestContract body
            )
        {
            var result = await _compilationService.CompileCode(body);
            return Ok(result);
        }

        [HttpPost]
        [Route("/add-task")]
        public IActionResult AddTask(
            [FromBody] AddTaskRequestContract body
            )
        {
            var result = _compilationService.AddTask(body);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("/tasks")]
        public IActionResult GetTasks() 
        {
            return Ok(_compilationService.GetAllTasks());
        }

        [HttpPost]
        [Route("/tasks/delete/{id}")]
        public IActionResult GetTasks([FromRoute] Guid id)
        {
            var result = _compilationService.DeleteTask(id);
            if (!result)
            { 
                return NotFound(); 
            }
            return Ok();
        }

        [HttpPost]
        [Route("/task-submission")]
        public IActionResult CheckSolution(Guid task, Guid user, [FromBody] CompilationRequestContract code)
        {
            _compilationService.CheckSolution(task, user, code);
            return Ok();
        }

        [HttpPost]
        [Route("/question-submission")]
        public IActionResult CheckAnswer(Guid question, Guid user, [FromBody] string answer)
        {
            var result = _compilationService.CheckAnswer(question, user, answer);
            if (!result)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
