using Application.Services.Levels;
using Application.Services.Files;
using Application.Services.InterviewCategory;
using Application.Services.Interviews;
using Application.Services.Users;
using Infrastructure.Services.Levels;
using Infrastructure.Services.Files;
using Infrastructure.Services.InterviewCategories;
using Infrastructure.Services.Interviews;
using Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.Projects;
using Infrastructure.Services.Projects;
using Application.Services.Experiences;
using Infrastructure.Services.Experiences;
using Application.Services.Payments;
using Infrastructure.Services.Payments;
using Application.Services.ReservedInterviews;
using Infrastructure.Services.ReservedInterviews;

namespace Infrastructure.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILevelService, LevelService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ILevelService, LevelService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IInterviewService, InterviewService>();
        services.AddScoped<IInterviewCategoryService, InterviewCategoryService>();
        services.AddScoped<IInterviewTimeService, InterviewTimeService>();
        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped< IReservedInterviewService , ReservedInterviewService>();

        return services;
    }
}
