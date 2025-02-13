namespace C4WX1.API.Features.Chat.Dtos
{
    public class ChatDto
    {
        public int ChatID { get; set; }
        public string? Comment { get; set; }
        public string? Attachment { get; set; }
        public string? Attachment_Physical { get; set; }
        public int? ParentID_FK { get; set; }
        public int? PatientID_FK { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy_FK { get; set; }
        public bool IsDeleted { get; set; }
        public bool? Family { get; set; }
        public ChatUserDto? UserData { get; set; }
        public ChatPatientDto? PatientData { get; set; }
        public ICollection<ChatDto> CommentList { get; set; } = [];
    }

    public class ChatUserDto
    {
        public int UserId { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? Photo { get; set; }
    }

    public class ChatPatientDto
    {
        public int PatientID { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? Photo { get; set; }
    }
}
