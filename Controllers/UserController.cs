using Archi.AppUserManagement.Business;
using Archi.AppUserManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archi.AppUserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        public readonly UsersService _usersService;
        public Users( UsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersService.GetAllUsers());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_usersService.GetUser(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _usersService.AddUser(user);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            _usersService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usersService.RemoveUser(_usersService.GetUser(id));
            return Ok();
        }
    }
}
