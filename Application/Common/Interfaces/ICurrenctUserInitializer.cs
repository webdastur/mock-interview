namespace Application.Common.Interfaces;

public interface ICurrenctUserInitializer
{
    void SetCurrentUserId(int userId);
    void SetCurrentUserRoleName(string roleName);
}
