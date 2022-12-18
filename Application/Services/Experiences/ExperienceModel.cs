using Application.Common.Model;
using Application.Services.Levels;

namespace Application.Services.Experiences;

public class ExperienceModel : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public LevelModel Level { get; set; }
}
