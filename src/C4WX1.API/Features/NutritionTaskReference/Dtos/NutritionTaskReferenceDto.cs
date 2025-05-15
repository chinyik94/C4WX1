namespace C4WX1.API.Features.NutritionTaskReference.Dtos;

public sealed class NutritionTaskReferenceDto
{
    public int ReferenceID { get; set; }
    public int CodeId_FK { get; set; }
    public string ReferenceDetail { get; set; } = null!;
    public int? Value { get; set; }
    public string? ReferenceImage { get; set; }
    public int GroupID_FK { get; set; }
    public string GroupName { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy_FK { get; set; }
    public bool CanDelete { get; set; }
}
