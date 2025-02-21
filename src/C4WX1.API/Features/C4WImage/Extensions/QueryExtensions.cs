using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.C4WImage.Extensions
{
    public static class QueryExtensions
    {
        /// <summary>
        /// Sorts and returns an iqueryable.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns><![CDATA[IQueryable<Database.Models.C4WImage>]]></returns>
        public static IQueryable<Database.Models.C4WImage> Sort(
            this IQueryable<Database.Models.C4WImage> query,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = SortDirections.Default;
            }

            var order = orderBy.Split(' ');
            var sortColumn = order[0];
            var isDescending = order[1].Equals(SortDirections.Desc, StringComparison.OrdinalIgnoreCase);
            query = isDescending
                ? query.OrderByDescending(x => x.C4WImageId)
                : query.OrderBy(x => x.C4WImageId);
            return query;
        }
    }
}
