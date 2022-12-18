using Application.Common.Interfaces;
using Application.Services.Interviews;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Services.Interviews;

public class InterviewTimeService : IInterviewTimeService
{
    private readonly IRepository<InterviewTime> timeRepository;
    private readonly IMapper mapper;

    public InterviewTimeService(IRepository<InterviewTime> timeRepository, IMapper mapper)
    {
        this.timeRepository = timeRepository;
        this.mapper = mapper;
    }
    public InterviewTimeModel CreateInterviewTime(CreateTimeModel interviewTime)
    {
        InterviewTime mappingModel = mapper.Map<InterviewTime>(interviewTime);
        timeRepository.Add(mappingModel);
        return mapper.Map<InterviewTimeModel>(mappingModel);
    }
}
