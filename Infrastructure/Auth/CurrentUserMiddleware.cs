using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Auth;

internal class CurrentUserMiddleware : IMiddleware
{
    private readonly ICurrenctUserInitializer currenctUserInitializer;

    public CurrentUserMiddleware(ICurrenctUserInitializer currenctUserInitializer)
    {
        this.currenctUserInitializer = currenctUserInitializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            _ = int.TryParse(context.User?.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (userId != 0)
            {
                currenctUserInitializer.SetCurrentUserId(userId);
            }

            currenctUserInitializer.SetCurrentUserRoleName(context.User?.FindFirstValue(ClaimTypes.Role));
        }

        await next(context);
    }
}
