using C4WX1.API.Features.BillingProposal.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.BillingProposal.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.BillingProposal> Sort(
        this IQueryable<Database.Models.BillingProposal> query,
        string? orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
        {
            orderBy = SortDirections.Default;
        }

        var order = orderBy.Split(' ');
        var sortColumn = order[0];
        var isDescending = order[1].Equals(SortDirections.Desc, StringComparison.OrdinalIgnoreCase);
        query = sortColumn switch
        {
            BillingProposalSortColumns.Title => isDescending
            ? query.OrderByDescending(x => x.Title)
                : query.OrderBy(x => x.Title),
            BillingProposalSortColumns.Patient => isDescending
                ? query.OrderByDescending(x => x.PatientID_FKNavigation.Firstname + " " + x.PatientID_FKNavigation.Lastname)
                : query.OrderBy(x => x.PatientID_FKNavigation.Firstname + " " + x.PatientID_FKNavigation.Lastname),
            BillingProposalSortColumns.Cost => isDescending
            ? query.OrderByDescending(x => x.TotalCost)
                : query.OrderBy(x => x.TotalCost),
            BillingProposalSortColumns.DateUpdated => isDescending
                ? query.OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                : query.OrderBy(x => x.ModifiedDate ?? x.CreatedDate),
            BillingProposalSortColumns.UpdatedBy => isDescending
                ? query.OrderByDescending(x => x.ModifiedBy_FKNavigation == null
                    ? x.CreatedBy_FKNavigation.Firstname + " " + x.CreatedBy_FKNavigation.Lastname
                    : x.ModifiedBy_FKNavigation.Firstname + " " + x.ModifiedBy_FKNavigation.Lastname)
                : query.OrderBy(x => x.ModifiedBy_FKNavigation == null
                    ? x.CreatedBy_FKNavigation.Firstname + " " + x.CreatedBy_FKNavigation.Lastname
                    : x.ModifiedBy_FKNavigation.Firstname + " " + x.ModifiedBy_FKNavigation.Lastname),
            _ => isDescending
                ? query.OrderByDescending(x => x.ProposalNumber)
                    .ThenByDescending(x => x.Version)
                : query.OrderBy(x => x.ProposalNumber)
                    .ThenBy(x => x.Version)
        };
        return query;
    }
}
