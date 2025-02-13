namespace C4WX1.API.Features.APIAccessKey.Dtos
{
    public class CreateAPIAccessKeyDto
    {
        public string Code { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
