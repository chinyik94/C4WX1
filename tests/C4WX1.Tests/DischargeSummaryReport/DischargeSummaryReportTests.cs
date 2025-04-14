using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.Tests.DischargeSummaryReport;

[Collection<C4WX1TestCollection>]
public class DischargeSummaryReportTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private CreateDischargeSummaryReportDto NewControlData => new()
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

    private UpdateDischargeSummaryReportDto UpdatedControlData => new()
    {
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

    private async Task<int> SetupAsync(CreateDischargeSummaryReportDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateDischargeSummaryReportDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        state.InsertedIds.Add(res);
        return res;
    }

    private async Task CleanupAsync()
    {
        await using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "DischargeSummaryReport" CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        state.InsertedIds = [];
        var reqs = Enumerable.Range(0, state.CreateCount)
            .Select(x => DischargeSummaryReportFaker.CreateDto());

        foreach (var req in reqs)
        {
            var (resp, res) = await app.Client.POSTAsync<Create, CreateDischargeSummaryReportDto, int>(
                req);
            resp.IsSuccessStatusCode.ShouldBeTrue();
            res.ShouldBeGreaterThan(0);
            state.InsertedIds.Add(res);
        }

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        state.InsertedIds = [];
        var createCount = state.CreateCount;
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(NewControlData);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetCountDto, int>(
            new()
            {
                PatientID = NewControlData.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        state.InsertedIds = [];
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(NewControlData);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetDischargeSummaryReportListDto, IEnumerable<DischargeSummaryReportDto>>(
            new()
            {
                PatientId = NewControlData.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCanAdd_WithExistingPatientId_AndExistingStatusIsActive()
    {
        state.InsertedIds = [];
        await SetupAsync(NewControlData);

        var (resp, res) = await app.Client.GETAsync<GetCanAdd, GetCanAddDto, bool>(
            new()
            {
                PatientID = NewControlData.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCanAdd_WithNonExistentPatientId()
    {
        var (resp, res) = await app.Client.GETAsync<GetCanAdd, GetCanAddDto, bool>(
            DischargeSummaryReportFaker.GetCanAddDto());

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeFalse();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        state.InsertedIds = [];
        var id = await SetupAsync(NewControlData);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, DischargeSummaryReportDto>(
            new()
            {
                Id = id
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.PatientID_FK.ShouldBe(NewControlData.PatientID_FK);
        res.DischargeDate.ShouldBe(NewControlData.DischargeDate);
        res.VisitDateStart.ShouldBe(NewControlData.VisitDateStart);
        res.VisitDateEnd.ShouldBe(NewControlData.VisitDateEnd);
        res.VisitedBy_FK.ShouldBe(NewControlData.VisitedBy_FK);
        res.SummaryCaseNote.ShouldBe(NewControlData.SummaryCaseNote);
        res.CreatedBy_FK.ShouldBe(NewControlData.UserId);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, DischargeSummaryReportDto>(
            DischargeSummaryReportFaker.GetByIdDto());

        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetByPatientId_WithExistingPatientId()
    {
        state.InsertedIds = [];
        await SetupAsync(NewControlData);

        var (resp, res) = await app.Client.GETAsync<GetByPatientId, GetByPatientIdDto, DischargeSummaryReportDto>(
            new()
            {
                PatientId = NewControlData.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.PatientID_FK.ShouldBe(NewControlData.PatientID_FK);
        res.DischargeDate.ShouldBe(NewControlData.DischargeDate);
        res.VisitDateStart.ShouldBe(NewControlData.VisitDateStart);
        res.VisitDateEnd.ShouldBe(NewControlData.VisitDateEnd);
        res.VisitedBy_FK.ShouldBe(NewControlData.VisitedBy_FK);
        res.SummaryCaseNote.ShouldBe(NewControlData.SummaryCaseNote);
        res.CreatedBy_FK.ShouldBe(NewControlData.UserId);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByPatientId_WithNonExistentPatientId()
    {
        var (resp, res) = await app.Client.GETAsync<GetByPatientId, GetByPatientIdDto, DischargeSummaryReportDto>(
            DischargeSummaryReportFaker.GetByPatientIdDto());

        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        state.InsertedIds = [];
        var id = await SetupAsync(NewControlData);

        var req = UpdatedControlData;
        req.DischargeSummaryReportID = id;
        var resp = await app.Client.PUTAsync<Update, UpdateDischargeSummaryReportDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = UpdatedControlData;
        req.DischargeSummaryReportID = DischargeSummaryReportFaker.Id();
        var resp = await app.Client.PUTAsync<Update, UpdateDischargeSummaryReportDto>(req);

        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
