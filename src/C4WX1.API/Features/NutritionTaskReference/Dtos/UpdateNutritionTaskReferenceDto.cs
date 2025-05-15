using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Dtos;

public sealed class UpdateNutritionTaskReferenceDto : UpdateDto
{
    public string? ReferenceImage { get; set; }
    public int? Value { get; set; }
    public string ReferenceDetail { get; set; } = null!;
}
