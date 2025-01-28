using FastEndpoints;

namespace C4WX1.API.Features.Shared
{
    public class GetListRequestDto
    {
        public const string Asc = "asc";
        public const string Desc = "desc";

        [QueryParam]
        public int? PageIndex { get; set; }

        [QueryParam]
        public int? PageSize { get; set; }

        [QueryParam]
        public string? OrderBy { get; set; }
    }
}
