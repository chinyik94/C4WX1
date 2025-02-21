namespace C4WX1.API.Features.Chat.Dtos
{
    public sealed class CreateChatDto
    {
        public string? Attachment { get; set; }
        public string? Attachment_Physical { get; set; }
        public int CreatedBy_FK { get; set; }
        public int? ParentID_FK { get; set; }
        public int? PatientID_FK { get; set; }
        public string? Comment { get; set; }
        public bool? Family { get; set; }
    }
}
