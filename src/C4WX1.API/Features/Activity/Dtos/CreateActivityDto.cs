﻿using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Activity.Dtos;

public sealed class CreateActivityDto : CreateDto
{
    public int ProblemListID_FK { get; set; }
    public int DiseaseID_FK { get; set; }
    public string ActivityDetail { get; set; } = string.Empty;
    public int? DiseaseSubInfoID_FK { get; set; }
}
