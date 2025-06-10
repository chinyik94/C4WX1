using C4WX1.API.Features.RecentView.Dtos;
using C4WX1.API.Features.RecentView.Extensions;
using C4WX1.API.Features.RecentView.Mappers;
using C4WX1.API.Features.RecentView.Repository;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.RecentView.Endpoints;

public class GetRecentViewListSummary
    : C4WX1GetListSummary<Database.Models.RecentView>
{

}

public class GetList(
    THCC_C4WDEVContext dbContext,
    IRecentViewRepository repository)
    : Endpoint<GetRecentViewListDto, IEnumerable<RecentViewDto>, RecentViewMapper>
{
    public override void Configure()
    {
        Get("recent-view");
        Summary(new GetRecentViewListSummary());
    }

    public override async Task HandleAsync(GetRecentViewListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var query = dbContext.RecentView
            .Where(x => x.UserID_FK == req.UserId);
        var patientIds = await query.Select(x => x.PatientID_FK).ToArrayAsync(ct);
        var canAccessDict = await repository.BatchCanAccessPatientDashboardAsync(
            req.UserId, req.FacilityId, patientIds);
        var data = query
            .AsEnumerable()
            .Where(x => canAccessDict.TryGetValue(x.PatientID_FK, out var canAccess) && canAccess);
        var dtos = data
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(Map.FromEntity)
            .ToList();
        await SendOkAsync(dtos, ct);
    }
}
