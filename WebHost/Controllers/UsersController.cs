using Application.Common.Model;
using Application.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Create New User
        /// </summary>
        /// <remarks>
        /// Response Example:
        /// 
        ///     Post /users
        ///     {
        ///       "last_name": "string",
        ///       "first_name": "string",
        ///       "middle_name": "string",
        ///       "phone": "string",
        ///       "login": "string",
        ///       "password": "string",
        ///       "role": "string"
        ///     }
        /// </remarks>
        /// <param name="createUserModel"></param>
        [HttpPost]
        public IActionResult PostUser(CreateUserModel createUserModel)
        {
            UserModel userModel = userService.CreateUser(createUserModel);
            return Ok(userModel);
        }

        /// <summary>
        /// Update New User
        /// </summary>
        /// <remarks>
        /// Response Example:
        /// 
        ///     Put /users
        ///     {
        ///       "last_name": "string",
        ///       "first_name": "string",
        ///       "middle_name": "string",
        ///       "phone": "string",
        ///       "login": "string",
        ///       "password": "string",
        ///       "role": "string"
        ///     }
        /// </remarks>
        /// <param name="updateUserModel"></param>
        [HttpPut]
        public async Task<IActionResult> PutUser(UpdateUserModel updateUserModel)
        {
            UserModel userModel = await userService.UpdateUser(updateUserModel);

            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            UserModel userModel = await userService.GetById(id);

            return Ok(userModel);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllUser([FromQuery]PaginatedRequestModel paginatedRequestModel)
        {
            PaginatedList<UserModel> userModels = await userService.GetPaginatedList(paginatedRequestModel);

            return Ok(userModels);
        }
    }
}
