namespace C4WX1.API.Features.Facility.Dtos;

public sealed class FacilityDto
{
    public int FacilityID { get; set; }
    public string FacilityName { get; set; } = null!;
    public int OrganizationID_FK { get; set; }
    public string OrganizationName { get; set; } = null!;
    public string? Remarks { get; set; }
    public string? IntegrationSource { get; set; }
    public string? C_id { get; set; }
    public bool CanDelete { get; set; }
}
