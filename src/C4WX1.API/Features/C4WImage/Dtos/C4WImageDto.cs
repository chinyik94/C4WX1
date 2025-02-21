namespace C4WX1.API.Features.C4WImage.Dtos
{
    public sealed class C4WImageDto
    {
        public int C4WImageId { get; set; }
        public string? WoundImageName { get; set; }
        public string? WoundImageData { get; set; }
        public string? WoundBedImageName { get; set; }
        public string? WoundBedImageData { get; set; }
        public string? TissueImageName { get; set; }
        public string? TissueImageData { get; set; }
        public string? DepthImageName { get; set; }
        public string? DepthImageData { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy_FK { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
