using Application.Services.Files;
using Application.Services.Levels;
using Application.Services.Projects;
using Application.Services.InterviewCategory;
using Application.Services.Interviews;
using Application.Services.Users;
using AutoMapper;
using Domain.Entities;
using File = Domain.Entities.File;

namespace Application.Common.Mappers;

public class IMappers : Profile
{
	public IMappers()
	{
		CreateMap<User, UserModel>().ReverseMap();
		CreateMap<User, CreateUserModel>().ReverseMap();
		CreateMap<User, UpdateUserModel>().ReverseMap();
		CreateMap<File, FileModel>().ReverseMap();
		CreateMap<File, FileCreateModel>().ReverseMap();
		CreateMap<User, InterviewerModel>().ReverseMap();
        CreateMap<Level, CreateLevelModel>().ReverseMap();
        CreateMap<Level, UpdateLevelModel>().ReverseMap();
        CreateMap<Level, LevelModel>().ReverseMap();
        CreateMap<Project, ProjectCreateModel>().ReverseMap();
        CreateMap<Project, ProjectModel>().ReverseMap();
    }
		CreateMap<Interview, InterviewModel>().ReverseMap();
		CreateMap<Interview, InterviewCreateModel>().ReverseMap();
		CreateMap<InterviewCategory, InterviewCategoryModel>().ReverseMap();
		CreateMap<InterviewCategory, InterviewCategoryCreateModel>().ReverseMap();
	}
}
