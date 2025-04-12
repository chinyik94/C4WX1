using FastEndpoints;

namespace C4WX1.API.Features.Shared.Dtos;

public class GetListDto
{
    [QueryParam]
    public int? PageIndex { get; set; }

    [QueryParam]
    public int? PageSize { get; set; }

    [QueryParam]
    public string? OrderBy { get; set; }
}
