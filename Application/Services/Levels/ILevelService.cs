using Application.Common.Model;

namespace Application.Services.Levels;

public interface ILevelService
{
    ValueTask<PaginatedList<LevelModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel);
    ValueTask<LevelModel> GetById(int levelId);
    LevelModel CreateLevel(CreateLevelModel createLevelModel);
    ValueTask<LevelModel> UpdateLevel(UpdateLevelModel updateLevelModel);
    ValueTask DeleteLevel(int levelId);
}
