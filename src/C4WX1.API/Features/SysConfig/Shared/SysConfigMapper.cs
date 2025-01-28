using FastEndpoints;

namespace C4WX1.API.Features.SysConfig.Shared
{
    public class SysConfigMapper : ResponseMapper<SysConfigDto, Database.Models.SysConfig>
    {
        public override SysConfigDto FromEntity(Database.Models.SysConfig e) => new()
        {
            ConfigName = e.ConfigName,
            ConfigValue = e.ConfigValue,
            ModifiedDate = e.ModifiedDate,
            ModifiedBy_FK = e.ModifiedBy_FK,
            IsConfigurable = e.IsConfigurable,
            Description = e.Description
        };
    }
}
