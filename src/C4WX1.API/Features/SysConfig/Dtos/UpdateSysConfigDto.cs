namespace C4WX1.API.Features.SysConfig.Dtos
{
    public class UpdateSysConfigDto
    {
        public string ConfigName { get; set; } = null!;
        public string ConfigValue { get; set; } = null!;
        public int UserID { get; set; }
    }
}
