using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;
using C4WX1.API.Features.IntegrationApiRequestLog.Endpoints;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.IntegrationApiRequestLog;

[Collection<C4WX1TestCollection>]
public class IntegrationApiRequestLogTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateIntegrationApiRequestLogDto Control => new()
    {
        IntegrationSource = "control-IntegrationSource",
        FacilityId = "1",
        ResidentId = "1",
        Url = "control-Url",
        Content = "control-Content",
        Status = "control-Status",
        UserId = 1
    };

    private async Task<int> SetupAsync(CreateIntegrationApiRequestLogDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateIntegrationApiRequestLogDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => IntegrationApiRequestLogFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "IntegrationApiRequestLog" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateIntegrationApiRequestLogDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        await SetupAsync(Control);
        createCount++;

        var (resp, res) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithStatus()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var id = await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                Status = Control.Status
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);
        res.First().IntegrationApiRequestLogID.ShouldBe(id);
        res.First().IntegrationSource.ShouldBe(Control.IntegrationSource);
        res.First().FacilityId.ShouldBe(Control.FacilityId);
        res.First().ResidentId.ShouldBe(Control.ResidentId);
        res.First().Url.ShouldBe(Control.Url);
        res.First().Content.ShouldBe(Control.Content);
        res.First().Status.ShouldBe(Control.Status);
        res.First().CreatedByID_FK.ShouldBe(Control.UserId);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithStartDateOnly()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        await SetupAsync(Control);
        createCount++;

        var (resp, res) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                StartDate = DateTime.Now.AddDays(-1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                StartDate = DateTime.Now.AddDays(1)
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithEndDateOnly()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        await SetupAsync(Control);
        createCount++;

        var (resp, res) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                EndDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                EndDate = DateTime.Now.AddDays(-1)
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithStartDate_AndEndDate()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        await SetupAsync(Control);
        createCount++;

        var (resp, res) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>>(
            new()
            {
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(5)
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(Control);

        var resp = await app.Client.PUTAsync<Update, UpdateIntegrationApiRequestLogDto>(
            new()
            {
                Id = id,
                UserId = 1,
                Status = "updated-Status"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateIntegrationApiRequestLogDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = 1,
                Status = "updated-Status"
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }
}
