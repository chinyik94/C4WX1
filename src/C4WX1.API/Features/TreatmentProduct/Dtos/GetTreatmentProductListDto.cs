namespace C4WX1.API.Features.TreatmentProduct.Dtos;

public sealed class GetTreatmentProductListDto
{
    public DateTime MonthFrom { get; set; }
    public DateTime MonthTo { get; set; }
    public string WoundCategory { get; set; } = null!;
    public string WoundStage { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public int ProductType { get; set; }
}
