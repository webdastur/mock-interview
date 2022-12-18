﻿using Application.Services.Files;
using Application.Services.Levels;
using Application.Services.Projects;
using Application.Services.InterviewCategory;
using Application.Services.Interviews;
using Application.Services.Users;
using AutoMapper;
using Domain.Entities;
using File = Domain.Entities.File;
using Application.Services.ReservedInterviews;
using Application.Services.Payments;
using Application.Services.Experiences;

namespace Application.Common.Mappers;

public class IMappers : Profile
{
    public IMappers()
    {
        CreateMap<User, UserModel>().ForMember(member => member.Image, source => source.MapFrom(map => map.Image))
                                    .ForMember(member => member.Experiences, source => source.MapFrom(map => map.Experiences))
                                    .ForMember(member => member.Projects, source => source.MapFrom(map => map.Projects)).ReverseMap();
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
        CreateMap<Interview, InterviewModel>().ReverseMap();
        CreateMap<Interview, InterviewCreateModel>().ReverseMap();
        CreateMap<InterviewCategory, InterviewCategoryModel>().ReverseMap();
        CreateMap<InterviewCategory, InterviewCategoryCreateModel>().ReverseMap();
        CreateMap<ReservedInterview, ReservedInterviewCreateModel>().ReverseMap();
        CreateMap<ReservedInterview, ReservedInterviewModel>().ForMember(member => member.Interview, source => source.MapFrom(map => map.Interview)).ReverseMap();
        CreateMap<Payment, PaymentModel>().ReverseMap();
        CreateMap<Payment, PaymentCreateModel>().ReverseMap(); 
		CreateMap<Interview, InterviewModel>().ReverseMap();
		CreateMap<Interview, InterviewCreateModel>().ReverseMap();
		CreateMap<InterviewCategory, InterviewCategoryModel>().ReverseMap();
		CreateMap<InterviewCategory, InterviewCategoryCreateModel>().ReverseMap();
		CreateMap<InterviewTime, InterviewTimeModel>().ReverseMap();
		CreateMap<InterviewTime, CreateTimeModel>().ReverseMap();
        CreateMap<Experience, ExperienceModel>().ReverseMap();
        CreateMap<Experience, ExperienceCreateModel>().ReverseMap();
	}
}
