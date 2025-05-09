using C4WX1.API.Features.DischargeSummaryReport.Dtos;

namespace C4WX1.Tests.DischargeSummaryReport;

public class DischargeSummaryReportFaker
{
    public static CreateDischargeSummaryReportDto CreateDummy
        => new Faker<CreateDischargeSummaryReportDto>()
            .RuleFor(x => x.PatientID_FK, f => f.Random.Int())
            .RuleFor(x => x.DischargeDate, f => f.Date.Past())
            .RuleFor(x => x.VisitDateStart, f => f.Date.Past())
            .RuleFor(x => x.VisitDateEnd, f => f.Date.Future())
            .RuleFor(x => x.VisitedBy_FK, f => f.Random.Int())
            .RuleFor(x => x.SummaryCaseNote, f => f.Lorem.Sentence())
            .RuleFor(x => x.UserId, f => f.Random.Int())
            .Generate();

    public static GetCanAddDto GetCanAddDummy
        => new Faker<GetCanAddDto>()
            .RuleFor(x => x.PatientID, f => f.Random.Int())
            .Generate();

    public static GetByPatientIdDto GetByPatientIdDummy
        => new Faker<GetByPatientIdDto>()
            .RuleFor(x => x.PatientId, f => f.Random.Int())
            .Generate();

    public static CreateDischargeSummaryReportDto CreateDto => new()
    {
        PatientID_FK = 1,
        DischargeDate = new DateTime(2024, 4, 10),
        VisitDateStart = new DateTime(2024, 4, 1),
        VisitDateEnd = new DateTime(2024, 4, 3),
        VisitedBy_FK = 1,
        SummaryCaseNote = "Control-SummaryCaseNote",
        UserId = 1,
        AttachmentList = [
            new DischargeSummaryReportAttachmentDto
            {
                Physical = "Control-Physical",
                Filename = "Control-Filename",
            }
            ]
    };

    public static UpdateDischargeSummaryReportDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        PatientID_FK = 2,
        DischargeDate = new DateTime(2024, 3, 10),
        VisitDateStart = new DateTime(2024, 3, 1),
        VisitDateEnd = new DateTime(2024, 3, 3),
        VisitedBy_FK = 2,
        SummaryCaseNote = "Updated-Control-SummaryCaseNote",
        UserId = 1,
        AttachmentList = [
            new DischargeSummaryReportAttachmentDto
            {
                Physical = "Updated-Control-Physical",
                Filename = "Updated-Control-Filename",
            }
            ]
    };
}
