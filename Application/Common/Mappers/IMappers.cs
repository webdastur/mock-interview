using Application.Services.Users;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappers;

public class IMappers : Profile
{
	public IMappers()
	{
		CreateMap<User, UserModel>().ReverseMap();
		CreateMap<User, CreateUserModel>().ReverseMap();
		CreateMap<User, UpdateUserModel>().ReverseMap();
	}
}
