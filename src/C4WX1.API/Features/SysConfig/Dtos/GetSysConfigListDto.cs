using C4WX1.API.Features.Shared.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.SysConfig.Dtos
{
    public sealed class GetSysConfigListDto : GetListDto
    {
        [QueryParam]
        public string? ConfigName { get; set; }

        [QueryParam]
        public string? ConfigValue { get; set; }
    }
}
