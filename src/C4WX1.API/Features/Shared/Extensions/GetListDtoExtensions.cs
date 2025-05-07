using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Shared.Extensions;

public static class GetListDtoExtensions
{
    public static (int startRowIndex, int pageSize) GetPaginationDetails(
        this GetListDto dto)
    {
        var pageIndex = dto.PageIndex ?? PaginationDefaults.Index;
        var pageSize = dto.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);
        return (startRowIndex, pageSize);
    }
}
