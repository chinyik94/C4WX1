using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.DischargeSummaryReport;

[Collection<C4WX1TestCollection>]
public class DischargeSummaryReportTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private async Task<int> SetupAsync(CreateDischargeSummaryReportDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateDischargeSummaryReportDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => DischargeSummaryReportFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
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
        var reqs = Enumerable.Range(0, state.CreateCount)
            .Select(x => DischargeSummaryReportFaker.CreateDummy);

        foreach (var req in reqs)
        {
            var (resp, res) = await app.Client.POSTAsync<Create, CreateDischargeSummaryReportDto, int>(
                req);
            resp.IsSuccessStatusCode.ShouldBeTrue();
            res.ShouldBeGreaterThan(0);
        }

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(DischargeSummaryReportFaker.CreateDto);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetCountDto, int>(
            new()
            {
                PatientID = DischargeSummaryReportFaker.CreateDto.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(DischargeSummaryReportFaker.CreateDto);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetDischargeSummaryReportListDto, IEnumerable<DischargeSummaryReportDto>>(
            new()
            {
                PatientId = DischargeSummaryReportFaker.CreateDto.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCanAdd_WithExistingPatientId_AndExistingStatusIsActive()
    {
        await SetupAsync(DischargeSummaryReportFaker.CreateDto);

        var (resp, res) = await app.Client.GETAsync<GetCanAdd, GetCanAddDto, bool>(
            new()
            {
                PatientID = DischargeSummaryReportFaker.CreateDto.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCanAdd_WithNonExistentPatientId()
    {
        var (resp, res) = await app.Client.GETAsync<GetCanAdd, GetCanAddDto, bool>(
            DischargeSummaryReportFaker.GetCanAddDummy);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeFalse();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var id = await SetupAsync(DischargeSummaryReportFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, DischargeSummaryReportDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.PatientID_FK.ShouldBe(DischargeSummaryReportFaker.CreateDto.PatientID_FK);
        res.DischargeDate.ShouldBe(DischargeSummaryReportFaker.CreateDto.DischargeDate);
        res.VisitDateStart.ShouldBe(DischargeSummaryReportFaker.CreateDto.VisitDateStart);
        res.VisitDateEnd.ShouldBe(DischargeSummaryReportFaker.CreateDto.VisitDateEnd);
        res.VisitedBy_FK.ShouldBe(DischargeSummaryReportFaker.CreateDto.VisitedBy_FK);
        res.SummaryCaseNote.ShouldBe(DischargeSummaryReportFaker.CreateDto.SummaryCaseNote);
        res.CreatedBy_FK.ShouldBe(DischargeSummaryReportFaker.CreateDto.UserId);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, DischargeSummaryReportDto>(req);

        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetByPatientId_WithExistingPatientId()
    {
        await SetupAsync(DischargeSummaryReportFaker.CreateDto);

        var (resp, res) = await app.Client.GETAsync<GetByPatientId, GetByPatientIdDto, DischargeSummaryReportDto>(
            new()
            {
                PatientId = DischargeSummaryReportFaker.CreateDto.PatientID_FK
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.PatientID_FK.ShouldBe(DischargeSummaryReportFaker.CreateDto.PatientID_FK);
        res.DischargeDate.ShouldBe(DischargeSummaryReportFaker.CreateDto.DischargeDate);
        res.VisitDateStart.ShouldBe(DischargeSummaryReportFaker.CreateDto.VisitDateStart);
        res.VisitDateEnd.ShouldBe(DischargeSummaryReportFaker.CreateDto.VisitDateEnd);
        res.VisitedBy_FK.ShouldBe(DischargeSummaryReportFaker.CreateDto.VisitedBy_FK);
        res.SummaryCaseNote.ShouldBe(DischargeSummaryReportFaker.CreateDto.SummaryCaseNote);
        res.CreatedBy_FK.ShouldBe(DischargeSummaryReportFaker.CreateDto.UserId);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByPatientId_WithNonExistentPatientId()
    {
        var (resp, res) = await app.Client.GETAsync<GetByPatientId, GetByPatientIdDto, DischargeSummaryReportDto>(
            DischargeSummaryReportFaker.GetByPatientIdDummy);

        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(DischargeSummaryReportFaker.CreateDto);

        var req = DischargeSummaryReportFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateDischargeSummaryReportDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = DischargeSummaryReportFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateDischargeSummaryReportDto>(req);

        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
