namespace C4WX1.API.Features.Chat.Dtos
{
    public sealed class GetChatListDto
    {
        public int? ChatID { get; set; }
        public int? PatientID { get; set; }
        public int? UserID { get; set; }
        public int Count { get; set; }
        public bool? Family { get; set; }
    }
}
