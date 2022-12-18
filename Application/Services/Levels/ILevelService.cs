using Application.Common.Model;
using Application.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Levels
{
    public interface ILevelService
    {
        ValueTask<PaginatedList<LevelModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel);
        ValueTask<LevelModel> GetById(int levelId);
        LevelModel CreateLevel(CreateLevelModel createLevelModel);
        ValueTask<LevelModel> UpdateLevel(UpdateLevelModel updateLevelModel);
        ValueTask DeleteLevel(int levelId);
    }
}
