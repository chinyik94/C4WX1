using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.DischargeSummaryReport;

public class DischargeSummaryReportFaker : C4WX1Faker
{
    public static CreateDischargeSummaryReportDto CreateDto()
        => new Faker<CreateDischargeSummaryReportDto>()
            .RuleFor(x => x.PatientID_FK, f => f.Random.Int())
            .RuleFor(x => x.DischargeDate, f => f.Date.Past())
            .RuleFor(x => x.VisitDateStart, f => f.Date.Past())
            .RuleFor(x => x.VisitDateEnd, f => f.Date.Future())
            .RuleFor(x => x.VisitedBy_FK, f => f.Random.Int())
            .RuleFor(x => x.SummaryCaseNote, f => f.Lorem.Sentence())
            .RuleFor(x => x.UserId, f => f.Random.Int())
            .Generate();

    public static GetCanAddDto GetCanAddDto()
        => new Faker<GetCanAddDto>()
            .RuleFor(x => x.PatientID, f => f.Random.Int())
            .Generate();

    public static GetByPatientIdDto GetByPatientIdDto()
        => new Faker<GetByPatientIdDto>()
            .RuleFor(x => x.PatientId, f => f.Random.Int())
            .Generate();
}
