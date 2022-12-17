using Application.Common.Interfaces;

namespace Infrastructure.Auth;

internal class CurrentUser : ICurrenctUserInitializer, ICurrentUser
{
    private int userId;
    private string roleName;

    public int GetUserId() => userId;

    public void SetCurrentUserId(int userId) => this.userId = userId;

    public void SetCurrentUserRoleName(string roleName) => this.roleName = roleName;
}
