using Application.Common.Model;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users;

public interface IUserService
{
    Task<PaginatedList<UserModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel);
    Task<UserModel> GetById(int userId);
    UserModel CreateUser(CreateUserModel createUserModel);
    Task<UserModel> UpdateUser(UpdateUserModel updateUserModel);
    Task DeleteUser(int userId);
}
