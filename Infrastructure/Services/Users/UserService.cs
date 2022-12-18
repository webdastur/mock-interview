using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
        if (createUserModel.Role.Equals(Role.Interviewer) && createUserModel.ImageId is null)
            throw new Exception("Image is required for interviewer");

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

    public async Task<PaginatedList<UserModel>> GetAllUsers(PaginatedRequestModel paginatedRequestModel)
    {
        int allUsersCount = await userRepository.GetCountAsync();
        List<User> users = await userRepository.GetAllByIncPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                    query => query.OrderBy(order => order.Id),
                        new string[] { "Experiences", "Projects"}
                            ).ToListAsync();

        return new PaginatedList<UserModel>
            (
                items: mapper.Map<List<UserModel>>(users),
                count: allUsersCount,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }

    public async Task<UserModel> UpdateUser(UpdateUserModel updateUserModel)
    {
        byte[] salt;
        byte[] hash;
        PasswordHasher.CreatePasswordHash(updateUserModel.Password, out salt, out hash);

        User oldUserEntity = await userRepository.GetByIdAsync(updateUserModel.Id);

        if (oldUserEntity is null)
            throw new Exception("user not found");

        User mappingUserModel = mapper.Map(updateUserModel, oldUserEntity);
        mappingUserModel.PasswordHash = hash;
        mappingUserModel.PasswordSalt = salt;
        userRepository.UpdateAsync(mappingUserModel);

        return mapper.Map<UserModel>(mappingUserModel);
    }

    public async Task<PaginatedList<InterviewerModel>> GetAllInterviewers(PaginatedRequestModel paginatedRequestModel)
    {
        int allUsersCount = await userRepository.GetCountExpAsync(x => x.Role == Role.Interviewer);
        List<User> users = await userRepository.GetAllByExpIncPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                    query => query.Role == Role.Interviewer,
                        query => query.OrderBy(order => order.Id),
                            new string[] { "Projects", "Experiences" }
                                ).ToListAsync();

        return new PaginatedList<InterviewerModel>
            (
                items: mapper.Map<List<InterviewerModel>>(users),
                count: allUsersCount,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }
}
