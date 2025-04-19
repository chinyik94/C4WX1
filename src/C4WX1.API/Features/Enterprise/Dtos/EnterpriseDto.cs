namespace C4WX1.API.Features.Enterprise.Dtos;

public sealed class EnterpriseDto
{
    public string? Name { get; set; }
    public string? Abbr { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? Contact { get; set; }
    public string? Email { get; set; }
    public int? MaxUsers { get; set; }
    public int? MaxPatients { get; set; }
    public DateTime? StartContract { get; set; }
    public DateTime? EndContract { get; set; }
    public string? Status { get; set; }
}
