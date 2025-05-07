using C4WX1.API.Features.Intervention.Constants;
using C4WX1.API.Features.Intervention.Dtos;
using C4WX1.API.Features.Intervention.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Extensions;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.Intervention;

[Collection<C4WX1TestCollection>]
public class InterventionTests(C4WX1App app, C4WX1State state) : TestBase
{
    private const string ControlDiseaseName = "control-DiseaseName";

    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Disease.AddAsync(new Database.Models.Disease
        {
            DiseaseName = ControlDiseaseName,
            SystemID_FKNavigation = new Database.Models.SystemForDisease
            {
                System = "control-System",
            }
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task<int> SetupAsync(CreateInterventionDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateInterventionDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => InterventionFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Disease", "Intervention" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateInterventionDto, int>(InterventionFaker.CreateControl);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(InterventionFaker.CreateDummy);
        var updateReq = InterventionFaker.UpdateDummy(id);
        var resp = await app.Client.PUTAsync<Update, UpdateInterventionDto>(updateReq);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var updateReq = InterventionFaker.UpdateDummy();
        var resp = await app.Client.PUTAsync<Update, UpdateInterventionDto>(updateReq);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(InterventionFaker.CreateDummy);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = id,
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var id = await SetupAsync(InterventionFaker.CreateControl);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, InterventionDto>(
            new()
            {
                Id = id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.InterventionID.ShouldBe(id);
        res.InterventionInfo.ShouldBe(InterventionFaker.CreateControl.InterventionInfo);
        res.DiseaseID_FK.ShouldBe(InterventionFaker.CreateControl.DiseaseID_FK);
        res.Disease.DiseaseID.ShouldBe(InterventionFaker.CreateControl.DiseaseID_FK);
        res.Disease.DiseaseName.ShouldBe(ControlDiseaseName);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, InterventionDto>(
            new()
            {
                Id = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new() { });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.IsDescendingOrder(x => x.InterventionInfo).ShouldBeTrue();

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(expectedCount2);
        res2.IsDescendingOrder(x => x.InterventionInfo).ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.IsAscendingOrder(x => x.InterventionInfo).ShouldBeTrue();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(expectedCount);
        res2.IsDescendingOrder(x => x.InterventionInfo).ShouldBeTrue();

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new()
            {
                OrderBy = $"{SortColumns.DiseaseName} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldNotBeNull();
        res3.Count().ShouldBe(expectedCount);
        res3.IsAscendingOrder(x => x.Disease.DiseaseName).ShouldBeTrue();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<InterventionDto>>(
            new()
            {
                OrderBy = $"{SortColumns.DiseaseName} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.ShouldNotBeNull();
        res4.Count().ShouldBe(expectedCount);
        res4.IsDescendingOrder(x => x.Disease.DiseaseName).ShouldBeTrue();

        await CleanupAsync();
    }
}
