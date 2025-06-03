using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Skillset.Dtos;

public sealed class UpdateSkillsetDto : UpdateDto
{
    public string CodeName { get; set; } = null!;
    public ICollection<int> Services { get; set; } = [];
}
