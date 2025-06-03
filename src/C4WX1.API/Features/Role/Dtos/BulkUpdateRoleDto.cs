namespace C4WX1.API.Features.Role.Dtos;

public sealed class BulkUpdateRoleDto
{
    public ICollection<UpdateRoleDto> Roles { get; set; } = [];
}

public sealed class UpdateRoleDto
{
    public int RoleId { get; set; }
    public bool Active { get; set; }
}