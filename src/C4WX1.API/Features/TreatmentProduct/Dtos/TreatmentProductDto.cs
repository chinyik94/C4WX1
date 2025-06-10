namespace C4WX1.API.Features.TreatmentProduct.Dtos;

public class TreatmentProductDto
{
    public ICollection<TreatmentProductDataDto> Data { get; set; } = [];
    public int Count { get; set; }
}

public class TreatmentProductDataDto
{
    public string ProductName { get; set; } = null!;
    public string ProductType { get; set; } = null!;
    public int UseCount { get; set; }
    public decimal? Cost { get; set; }
    public decimal? TotalCost { get; set; }
}