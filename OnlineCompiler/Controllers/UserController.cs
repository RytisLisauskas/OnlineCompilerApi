using Microsoft.AspNetCore.Mvc;
using OnlineCompiler.Services;

namespace OnlineCompiler.Controllers
{
    [Route("/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }
        [HttpPost]
        [Route("/add")]
        public IActionResult CreateUser(string name, string password)
        {
            var result = _userService.AddUser(name, password);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetAllUsers([FromRoute] Guid id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
          var result = _userService.DeleteById(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
