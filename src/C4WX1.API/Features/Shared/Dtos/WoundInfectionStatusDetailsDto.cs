namespace C4WX1.API.Features.Shared.Dtos;

public class WoundInfectionStatusDetailsDto
{
    public bool? InfectionStatus { get; set; }
    public int? InfectionItemsValue { get; set; }
    public bool? BSlowHealing { get; set; }
    public bool? BIncreasedPain { get; set; }
    public bool? BIncreasedExudate { get; set; }
    public bool? BSwelling { get; set; }
    public bool? BRedness { get; set; }
    public bool? BSmell { get; set; }
    public bool? BWarmToTouch { get; set; }
    public int? ExudateValue { get; set; }
    public int? PrevExudateValue { get; set; }
    public int? PatientWoundVisitId { get; set; }
    public string? PrevExudate { get; set; }
    public string? Exudate { get; set; }
    public int? BPDias { get; set; }
    public int? BPSys { get; set; }
    public int? PulseRate { get; set; }
    public decimal? Temperature { get; set; }
}
