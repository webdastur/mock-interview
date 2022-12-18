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
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostUser(CreateUserModel createUserModel)
        {
            UserModel userModel = userService.CreateUser(createUserModel);
            return Ok(userModel);
        }
    }
}
