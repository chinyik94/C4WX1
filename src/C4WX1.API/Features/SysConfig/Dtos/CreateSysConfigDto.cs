namespace C4WX1.API.Features.SysConfig.Dtos;

public sealed class CreateSysConfigDto
{
    public string ConfigName { get; set; } = null!;
    public string? ConfigValue { get; set; }
    public bool? IsConfigurable { get; set; }
    public string? Description { get; set; }
}
