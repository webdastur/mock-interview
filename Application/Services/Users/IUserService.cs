using Application.Common.Model;

namespace Application.Services.Users;

public interface IUserService
{
    Task<PaginatedList<UserModel>> GetAllUsers(PaginatedRequestModel paginatedRequestModel);
    Task<PaginatedList<InterviewerModel>> GetAllInterviewers(PaginatedRequestModel paginatedRequestModel);
    Task<UserModel> GetById(int userId);
    UserModel CreateUser(CreateUserModel createUserModel);
    Task<UserModel> UpdateUser(UpdateUserModel updateUserModel);
    Task DeleteUser(int userId);
    Task<UserModel> GetUserInfo();
}
