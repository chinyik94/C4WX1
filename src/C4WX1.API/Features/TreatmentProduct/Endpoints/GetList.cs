using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.TreatmentProduct.Dtos;

namespace C4WX1.API.Features.TreatmentProduct.Endpoints;

public class GetTreatmentProductListSummary
    : C4WX1GetListSummary<Database.Models.PatientWoundVisitTreatmentList>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetTreatmentProductListDto, TreatmentProductDto>
{
    public override void Configure()
    {
        Get("treatment-product");
        Summary(new GetTreatmentProductListSummary());
    }

    public override async Task HandleAsync(GetTreatmentProductListDto req, CancellationToken ct)
    {
        var dtos = await dbContext.PatientWoundVisitTreatmentList
            .Include(x => x.TListItemID_FKNavigation)
                .ThenInclude(x => x.TListTypeID_FKNavigation)
            .Include(x => x.PatientWoundVisitID_FKNavigation)
                .ThenInclude(x => x.PatientWoundID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.TListItemID_FKNavigation.TListTypeID_FKNavigation.CodeTypeId_FK == CodetableTypeKeys.TreatmentListType
                && x.CreatedDate > req.MonthFrom && x.CreatedDate < req.MonthTo
                && (string.IsNullOrWhiteSpace(req.ProductName) || x.TListItemID_FKNavigation.ItemName == req.ProductName)
                && (req.ProductType == 0 || x.TListItemID_FKNavigation.TListTypeID_FK == req.ProductType)
                && (string.IsNullOrWhiteSpace(req.WoundCategory) || x.PatientWoundVisitID_FKNavigation.PatientWoundID_FKNavigation.Category == req.WoundCategory)
                && (string.IsNullOrWhiteSpace(req.WoundStage) || x.PatientWoundVisitID_FKNavigation.PatientWoundID_FKNavigation.Stage == req.WoundStage))
            .GroupBy(x => x.TListItemID_FK)
            .Select(x => new TreatmentProductDataDto
            {
                ProductName = x.First().TListItemID_FKNavigation.ItemName,
                ProductType = x.First().TListItemID_FKNavigation.TListTypeID_FKNavigation.CodeName,
                UseCount = x.Count(),
                Cost = x.First().TListItemID_FKNavigation.Cost,
                TotalCost = x.Count() * x.First().TListItemID_FKNavigation.Cost
            })
            .OrderBy(x => x.UseCount)
            .ToListAsync(ct);
        var dto = new TreatmentProductDto
        {
            Data = dtos,
            Count = dtos.Count
        };
        await SendOkAsync(dto, ct);
    }
}
