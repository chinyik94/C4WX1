using C4WX1.API.Features.SysConfig.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.SysConfig.Mappers
{
    public class SysConfigCreateMapper : RequestMapper<CreateSysConfigDto, Database.Models.SysConfig>
    {
        public override Database.Models.SysConfig ToEntity(CreateSysConfigDto r) => new()
        {
            ConfigName = r.ConfigName,
            ConfigValue = r.ConfigValue,
            ModifiedDate = DateTime.Now,
            IsConfigurable = r.IsConfigurable,
            Description = r.Description
        };
    }
}
