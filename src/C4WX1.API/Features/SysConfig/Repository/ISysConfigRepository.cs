namespace C4WX1.API.Features.SysConfig.Repository;

public interface ISysConfigRepository
{
    Task<string> GenerateNewBillingInvoiceNumberAsync(
        int userId,
        CancellationToken ct = default);
    Task<string> GenerateNewBillingProposalNumberAsync(
        int userId, 
        CancellationToken ct = default);
    Task<string> GenerateNewReceiptNumberAsync(
        int userId,
        CancellationToken ct = default);
    Task<string> GetEnterpriseAbbrAsync(CancellationToken ct = default);
}
