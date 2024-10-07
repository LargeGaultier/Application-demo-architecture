using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Archi.AppUserManagement.Application.User.Commands.AddUserCommand;
using Archi.AppUserManagement.Application.User.Commands.UpdateUserCommand;
using Microsoft.Identity.Client;
using Archi.AppUserManagement.Application.User.Commands.DeleteUserCommand;
using Archi.AppUserManagement.Application.User.Queries.GetAllUserQuery;
using Archi.AppUserManagement.Application.User.Queries.GetUserByIdQuery;

namespace Archi.AppUserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly AddUserCommand _addUserCommand;
        private readonly UpdateUserCommand _updateUserCommand;
        private readonly DeleteUserCommand _deleteUserCommand;
        private readonly GetAllUserQuery _getAllUserQuery;
        private readonly GetUserByIdQuery _getUserByIdQuery

       public Users(AddUserCommand addUserCommand, UpdateUserCommand updateUserCommand, DeleteUserCommand deleteUserCommand, GetAllUserQuery getAllUserQuery, GetUserByIdQuery getUserByIdQuery)
        {
            _addUserCommand = addUserCommand;
            _updateUserCommand = updateUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _getAllUserQuery = getAllUserQuery;
            _getUserByIdQuery = getUserByIdQuery;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_getAllUserQuery.Execute());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_getUserByIdQuery.Execute(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserCreateDTO user)
        {
            _addUserCommand.Execute(user);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(long id, [FromBody] UserCreateDTO user)
        {
            _updateUserCommand.Execute(user, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _deleteUserCommand.Execute(id);
            return Ok();
        }
    }
}
