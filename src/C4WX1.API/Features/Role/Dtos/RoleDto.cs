namespace C4WX1.API.Features.Role.Dtos;

public sealed class RoleDto
{
    public int RoleId { get; set; }
    public string RoleDescription { get; set; } = null!;
    public string OptionText { get; set; } = null!;
    public string OptionValue { get; set; } = null!;
    public bool? Active { get; set; }
}
