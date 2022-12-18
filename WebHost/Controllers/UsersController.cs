using Application.Common.Model;
using Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                UserModel userModel = userService.CreateUser(createUserModel);
                return Ok(new ResponseModel(userModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Update User
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
            try
            {
                UserModel userModel = await userService.UpdateUser(updateUserModel);

                return Ok(new ResponseModel(userModel));
            }
            catch(Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }


        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                UserModel userModel = await userService.GetById(id);

                return Ok(new ResponseModel(userModel));
            }
            catch(Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="paginatedRequestModel"></param>
        [HttpGet("list")]
        public async Task<IActionResult> GetAllUser([FromQuery] PaginatedRequestModel paginatedRequestModel)
        {
            try
            {
                PaginatedList<UserModel> userModels = await userService.GetAllUsers(paginatedRequestModel);

                return Ok(new ResponseModel(userModels));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get All Interviewers
        /// </summary>
        /// <param name="paginatedRequestModel"></param>
        [AllowAnonymous]
        [HttpGet("interviewers")]
        public async Task<IActionResult> GetInterviewer([FromQuery] PaginatedRequestModel paginatedRequestModel)
        {
            try
            {
                PaginatedList<InterviewerModel> interviewers = await userService.GetAllInterviewers(paginatedRequestModel);
                return Ok(new ResponseModel(interviewers));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get Current User Info
        /// </summary>
        /// <returns></returns>
        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            try
            {
                return Ok(new ResponseModel(await userService.GetUserInfo()));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }
    }
}
