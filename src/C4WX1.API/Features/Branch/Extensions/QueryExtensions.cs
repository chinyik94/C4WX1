using C4WX1.API.Features.Branch.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.Branch.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<Database.Models.Branch> Sort(
            this IQueryable<Database.Models.Branch> query,
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
                BranchSortColumns.Address => isDescending
                ? query.OrderByDescending(x => x.Address1)
                    : query.OrderBy(x => x.Address1),
                BranchSortColumns.Contact => isDescending
                    ? query.OrderByDescending(x => x.Contact)
                    : query.OrderBy(x => x.Contact),
                BranchSortColumns.Email => isDescending
                ? query.OrderByDescending(x => x.Email)
                    : query.OrderBy(x => x.Email),
                BranchSortColumns.Status => isDescending
                    ? query.OrderByDescending(x => x.Status)
                    : query.OrderBy(x => x.Status),
                BranchSortColumns.Currency => isDescending
                    ? query.OrderByDescending(x => x.CurrencyID_FKNavigation.CodeName)
                    : query.OrderBy(x => x.CurrencyID_FKNavigation.CodeName),
                _ => isDescending
                    ? query.OrderByDescending(x => x.BranchName)
                    : query.OrderBy(x => x.BranchName)
            };
            return query;
        }
    }
}
