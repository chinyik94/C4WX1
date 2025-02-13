using FastEndpoints;

namespace C4WX1.API.Features.SysConfig.Dtos
{
    public class GetSysConfigDto
    {
        [QueryParam]
        public string ConfigName { get; set; } = null!;
    }
}
