using C4WX1.API.Features.SysConfig.Dtos;

namespace C4WX1.Tests.SysConfig
{
    public class SysConfigState : StateFixture
    {
        public SysConfigDto Control { get; private set; } = new()
        {
            ConfigName = "Control-ConfigName",
            ConfigValue = "Control-ConfigValue",
            IsConfigurable = true,
            Description = "Control-Description"
        };
    }
}
