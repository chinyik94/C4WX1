using C4WX1.API.Features.Shared;
using FastEndpoints;

namespace C4WX1.API.Features.SysConfig.Dtos
{
    public class GetSysConfigListDto : GetListRequestDto
    {
        [QueryParam]
        public string? ConfigName { get; set; }

        [QueryParam]
        public string? ConfigValue { get; set; }
    }
}
