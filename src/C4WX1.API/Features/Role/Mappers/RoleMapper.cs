using C4WX1.API.Features.Role.Dtos;

namespace C4WX1.API.Features.Role.Mappers;

public class RoleMapper
    : ResponseMapper<RoleDto, Database.Models.Role>
{
    public override RoleDto FromEntity(Database.Models.Role e)
        => new()
        {
            RoleId = e.RoleId,
            RoleDescription = e.RoleDescription,
            OptionText = e.OptionText,
            OptionValue = e.OptionValue,
            Active = e.Active
        };
}
