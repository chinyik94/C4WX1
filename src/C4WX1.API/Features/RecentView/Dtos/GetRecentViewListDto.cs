using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.RecentView.Dtos;

public sealed class GetRecentViewListDto : GetListDto
{
    public int UserId { get; set; }
    public int FacilityId { get; set; }
}
