using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Experiences;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Experiences;

public class ExperienceService : IExperienceService
{
    private readonly IRepository<Experience> experienceRepository;
    private readonly IMapper mapper;
    private readonly ICurrentUser currentUser;

    public ExperienceService(
        IRepository<Experience> experienceRepository,
        IMapper mapper,
        ICurrentUser currentUser)
    {
        this.experienceRepository = experienceRepository;
        this.mapper = mapper;
        this.currentUser = currentUser;
    }
    public ExperienceModel CreateExperience(ExperienceCreateModel experience)
    {
        Experience experienceModel = mapper.Map<Experience>(experience);
        experienceModel.UserId = currentUser.GetUserId();
        experienceRepository.Add(experienceModel);

        return mapper.Map<ExperienceModel>(experienceModel);
    }

    public async Task<PaginatedList<ExperienceModel>> GetExperiences(PaginatedRequestModel paginatedRequestModel)
    {
        int count = await experienceRepository.GetCountExpAsync(x => x.UserId.Equals(currentUser.GetUserId()));

        List<Experience> experiences = await experienceRepository.GetAllByExpIncPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                    query => query.UserId.Equals(currentUser.GetUserId()),
                        query => query.OrderBy(order => order.Id),
                            new string[] { "Level" }
                                ).ToListAsync();

        return new PaginatedList<ExperienceModel>
            (
                items: mapper.Map<List<ExperienceModel>>(experiences),
                count: count,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }
}
