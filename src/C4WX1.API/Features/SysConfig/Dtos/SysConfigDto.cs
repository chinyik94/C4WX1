namespace C4WX1.API.Features.SysConfig.Dtos
{
    public class SysConfigDto
    {
        public string ConfigName { get; set; } = null!;
        public string? ConfigValue { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy_FK { get; set; }
        public bool? IsConfigurable { get; set; }
        public string? Description { get; set; }
    }
}
