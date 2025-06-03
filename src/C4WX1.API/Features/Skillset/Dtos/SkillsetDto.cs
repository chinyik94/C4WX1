namespace C4WX1.API.Features.Skillset.Dtos;

public sealed class SkillsetDto
{
    public int CodeId { get; set; }
    public string CodeName { get; set; } = null!;
    public ICollection<SkillsetServiceDto> Services { get; set; } = [];
}

public sealed class SkillsetServiceDto
{
    public int CodeId { get; set; }
    public string CodeName { get; set; } = null!;
}