using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.RecentView.Dtos;

public sealed class UpsertRecentViewDto
{
    public int UserID { get; set; }
    public int PatientID { get; set; }
}