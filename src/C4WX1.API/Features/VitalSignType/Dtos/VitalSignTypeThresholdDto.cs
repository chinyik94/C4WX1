using System.Text.Json.Serialization;

namespace C4WX1.API.Features.VitalSignType.Dtos;

public sealed class VitalSignTypeThresholdDto
{
    public int VitalSignTypeID_FK { get; set; }

    [JsonPropertyName("ews_min_1")]
    public decimal? EwsMin1 { get; set; }

    [JsonPropertyName("ews_max_1")]
    public decimal? EwsMax1 { get; set; }

    [JsonPropertyName("ews_min_2")]
    public decimal? EwsMin2 { get; set; }

    [JsonPropertyName("ews_max_2")]
    public decimal? EwsMax2 { get; set; }

    [JsonPropertyName("ews_min_3")]
    public decimal? EwsMin3 { get; set; }

    [JsonPropertyName("ews_max_3")]
    public decimal? EwsMax3 { get; set; }

    [JsonPropertyName("ews_min_4")]
    public decimal? EwsMin4 { get; set; }

    [JsonPropertyName("ews_max_4")]
    public decimal? EwsMax4 { get; set; }

    [JsonPropertyName("ews_min_5")]
    public decimal? EwsMin5 { get; set; }

    [JsonPropertyName("ews_max_5")]
    public decimal? EwsMax5 { get; set; }

    [JsonPropertyName("ews_min_6")]
    public decimal? EwsMin6 { get; set; }

    [JsonPropertyName("ews_max_6")]
    public decimal? EwsMax6 { get; set; }

    [JsonPropertyName("ews_min_7")]
    public decimal? EwsMin7 { get; set; }

    [JsonPropertyName("ews_max_7")]
    public decimal? EwsMax7 { get; set; }
}
