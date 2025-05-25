using C4WX1.API.Features.PatientAccessLine.Dtos;

namespace C4WX1.API.Features.PatientAccessLine.Mappers;

public class PatientAccessLineMapper
    : ResponseMapper<PatientAccessLineDto, Database.Models.PatientAccessLine>
{
    public override PatientAccessLineDto FromEntity(Database.Models.PatientAccessLine e)
        => new()
        {
            PatientAccessLineID = e.PatientAccessLineID,
            AccessLine = e.AccessLine,
            DateOfInsertion = e.DateOfInsertion,
            Patent = e.Patent,
            PatentReSited = e.PatentReSited,
            PatentReSitedDate = e.PatentReSitedDate,
            PatentSite = e.PatentSite,
            DateDueForChange = e.DateDueForChange,
            AccessLineRemarks = e.AccessLineRemarks
        };
}
