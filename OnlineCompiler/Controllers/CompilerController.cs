using Microsoft.AspNetCore.Mvc;
using OnlineCompiler.Models;
using OnlineCompiler.Services;

namespace OnlineCompiler.Controllers
{
    [ApiController]
    [Route("/lets-zoink")]
    public class CompilerController : Controller
    {
        public ICompilatingService _compilationService;

        public CompilerController(ICompilatingService service)
        {
            _compilationService = service;
        }
       
        [HttpPost]
        public async Task<IActionResult> ExecuteProgram(
            [FromBody] CompilationRequestContract body
            )
        {
            var result = await _compilationService.CompileCode(body);
            return Ok(result);
        }
    }
}
