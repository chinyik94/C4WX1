namespace C4WX1.API.Features.Branch.Repository
{
    public interface IBranchRepository
    {
        Task<bool> CanDeleteBranchAsync(int branchId);
        Task<Dictionary<int, bool>> BatchCanDeleteBranchAsync(IEnumerable<int> branchIds);
    }
}
