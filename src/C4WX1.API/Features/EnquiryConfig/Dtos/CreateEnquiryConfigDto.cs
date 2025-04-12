using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.EnquiryConfig.Dtos;

public sealed class CreateEnquiryConfigDto : CreateDto
{
    public int? SCMID_FK { get; set; }
    public string? EmailContent { get; set; }
    public int? EscalatingPersonID_FK { get; set; }
    public decimal? EscalationPeriod { get; set; }
    public string? EscalationEmail { get; set; }
    public string? EmailtoCMContent { get; set; }
    public ICollection<int> SCMList { get; set; } = [];
    public ICollection<int> EscPersonList { get; set; } = [];
}
