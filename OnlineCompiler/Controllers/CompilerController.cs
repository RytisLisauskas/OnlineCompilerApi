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
    }
}
