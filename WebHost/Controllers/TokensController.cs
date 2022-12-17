using Application.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokensController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Get Token
        /// </summary>
        /// <remarks>
        /// Response Example:
        /// 
        ///     Get /api/token
        ///     {
        ///       "login": "login",
        ///       "password": "password"
        ///     }
        /// </remarks>
        /// <response code="200">Returns token</response>
        [HttpPost]
        public TokenResponse Get(TokenRequest tokenRequest) => tokenService.GetTokenAsync(tokenRequest);
    }
}
