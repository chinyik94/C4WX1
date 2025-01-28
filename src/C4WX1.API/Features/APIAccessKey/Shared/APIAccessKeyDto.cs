namespace C4WX1.API.Features.APIAccessKey.Shared
{
    public sealed class APIAccessKeyDto
    {
        public int APIAccessKeyID { get; set; }
        public string TokenCode { get; set; } = string.Empty;
        public string AccessKey { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId_FK { get; set; }
    }
}
