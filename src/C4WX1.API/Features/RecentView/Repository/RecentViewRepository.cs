using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.RecentView.Repository;

public class RecentViewRepository(IConfiguration configuration) 
    : C4WX1Repository(configuration), IRecentViewRepository
{
    protected override string CanDeleteSql => throw new NotImplementedException();

    protected override string BatchCanDeleteSql => throw new NotImplementedException();
}
