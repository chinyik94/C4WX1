using System.Text.Json.Serialization;

namespace C4WX1.API.Features.Type.Dtos;

public class TypeDto
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = null!;

    [JsonPropertyName("codeValue")]
    public string CodeValue { get; set; } = null!;

    [JsonPropertyName("parentCode")]
    public string? ParentCode { get; set; }

    [JsonPropertyName("ordering")]
    public int Ordering { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }
}
