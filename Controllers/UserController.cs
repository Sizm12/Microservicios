using ExampleDocker.Interface;
using ExampleDocker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _IUserService;

        public UserController(IUserService userService)
        {
            _IUserService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserEntities>>> GetAll()
        {
            var usuarios = await _IUserService.GetAll();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntities>> GetById(int id)
        {
            var usuario = await _IUserService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UserEntities>> Create(UserEntities userEntities)
        {
            var usuario = await _IUserService.Create(userEntities);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<UserEntities>> Update(UserEntities userEntities)
        {
            var usuarios = await _IUserService.Update(userEntities);
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var response = await _IUserService.Delete(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
