namespace C4WX1.API.Features.BillingProposal.Dtos;

public sealed class BillingProposalServiceDto
{
    public int BillingInvoiceServiceID { get; set; }
    public int BillingProposalID_FK { get; set; }
    public int ServiceID_FK { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal UnitCost { get; set; }
    public string? Duration1 { get; set; }
    public string? Duration2 { get; set; }
    public int Visit { get; set; }
    public int Session { get; set; }
    public decimal Discount { get; set; }
    public string? ServiceDescription { get; set; }
    public string CategoryName { get; set; } = null!;
}
