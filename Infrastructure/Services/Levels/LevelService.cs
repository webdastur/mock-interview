using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Levels;
using Application.Services.Users;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Levels
{
    internal class LevelService : ILevelService
    {
        private readonly IRepository<Level> levelRepository;
        private readonly IMapper mapper;

        public LevelService(IRepository<Level> levelRepository, IMapper mapper)
        {
            this.levelRepository = levelRepository;
            this.mapper = mapper;
        }

        public LevelModel CreateLevel(CreateLevelModel createLevelModel)
        {
            Level mappedLevel = mapper.Map<Level>(createLevelModel);
            levelRepository.Add(mappedLevel);
            return mapper.Map<LevelModel>(mappedLevel);
        }

        public async ValueTask DeleteLevel(int levelId)
        {
            Level levelEntity = await levelRepository.GetByIdAsync(levelId);

            if (levelEntity is null)
                throw new Exception("level not found");

            levelRepository.DeleteAsync(levelEntity);
        }

        public async ValueTask<LevelModel> GetById(int levelId)
        {
            Level levelEntity = await levelRepository.GetByIdAsync(levelId);

            if (levelEntity is null)
                throw new Exception("level not found");

            return mapper.Map<LevelModel>(levelEntity);
        }

        public async ValueTask<PaginatedList<LevelModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel)
        {
            int allLevelsCount = await levelRepository.GetCountAsync();
            IList<Level> levels = await levelRepository.GetAllByOrderPage(
                paginatedRequestModel.Page,
                    paginatedRequestModel.PageSize,
                        query => query.OrderBy(order => order.Id)
                            ).ToListAsync();

            return new PaginatedList<LevelModel>
                (
                    items: mapper.Map<List<LevelModel>>(levels),
                    count: allLevelsCount,
                    pageNumber: paginatedRequestModel.Page,
                    pageSize: paginatedRequestModel.PageSize
                );
        }

        public async ValueTask<LevelModel> UpdateLevel(UpdateLevelModel updateLevelModel)
        {
            Level oldLevel = await levelRepository.GetByIdAsync(updateLevelModel.Id);

            if (oldLevel is null) 
                throw new Exception("level not found");

            Level mappedLevel = mapper.Map(updateLevelModel, oldLevel);

            levelRepository.UpdateAsync(mappedLevel);

            return mapper.Map<LevelModel>(mappedLevel);
        }
    }
}
