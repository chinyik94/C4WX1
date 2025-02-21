namespace C4WX1.API.Features.SysConfig.Repository
{
    public interface ISysConfigRepository
    {
        Task<string> GenerateNewBillingProposalNumberAsync(int userId, CancellationToken ct = default);
    }
}
