using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Users;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Users;

public class UserService : IUserService
{
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel createUserModel)
    {
        byte[] salt;
        byte[] hash;
        PasswordHasher.CreatePasswordHash(createUserModel.Password, out salt, out hash);
        User mappedUserModel = mapper.Map<User>(createUserModel);
        mappedUserModel.PasswordHash = hash;
        mappedUserModel.PasswordSalt = salt;

        userRepository.Add(mappedUserModel);
        return mapper.Map<UserModel>(mappedUserModel);
    }

    public async Task DeleteUser(int userId)
    {
        User deletingUser = await userRepository.GetByIdAsync(userId);
        if (deletingUser is null)
            throw new Exception("user not found");

        userRepository.DeleteAsync(deletingUser);
    }

    public async Task<UserModel> GetById(int userId)
    {
        User userEntity = await userRepository.GetByIdAsync(userId);
        if (userEntity is null)
            throw new Exception("user not found");

        return mapper.Map<UserModel>(userEntity);
    }

    public async Task<PaginatedList<User>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel)
    {
        int allUsersCount = await userRepository.GetCountAsync();
        List<User> users = await userRepository.GetAllByOrderPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                    query => query.OrderBy(order => order.Id)
                        ).ToListAsync();

        return new PaginatedList<User>
            (
                items: mapper.Map<List<User>>(users),
                count: allUsersCount,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }

    public async Task<UserModel> UpdateUser(UpdateUserModel updateUserModel)
    {
        User oldUserEntity = await userRepository.GetByIdAsync(updateUserModel.Id);

        if (oldUserEntity is null)
            throw new Exception("user not found");

        User mappingUserModel = mapper.Map(updateUserModel, oldUserEntity);
        userRepository.UpdateAsync(mappingUserModel);

        return mapper.Map<UserModel>(mappingUserModel);
    }
}
