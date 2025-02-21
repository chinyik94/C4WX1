using C4WX1.API.Features.Shared.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.APIAccessKey.Dtos
{
    public sealed class GetAPIAccessKeyDto : GetByIdDto
    {
        [QueryParam]
        public string? AccessKey { get; set; } = string.Empty;
    }
}
