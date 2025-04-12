namespace C4WX1.API.Features.EnquiryConfig.Dtos;

public sealed class EnquiryConfigDto
{
    public int EnquiryConfigID { get; set; }
    public int? SCMID_FK { get; set; }
    public string? EmailContent { get; set; }
    public int? EscalatingPersonID_FK { get; set; }
    public decimal? EscalationPeriod { get; set; }
    public string? EscalationEmail { get; set; }
    public string? EmailtoCMContent { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
}
