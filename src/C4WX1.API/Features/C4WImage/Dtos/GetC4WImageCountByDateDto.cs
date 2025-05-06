namespace C4WX1.API.Features.C4WImage.Dtos;

public sealed class GetC4WImageCountByDateDto
{
    [QueryParam]
    public DateTime FromDate { get; set; }

    [QueryParam]
    public DateTime ToDate { get; set; }
}
