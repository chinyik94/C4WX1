using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.CPGoals;

[Collection<C4WX1TestCollection>]
public class CPGoalsTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Disease.AddAsync(new Database.Models.Disease
        {
            DiseaseName = "control-DiseaseName",
            SystemID_FKNavigation = new Database.Models.SystemForDisease
            {
                System = "control-System",
            }
        });
        await dbContext.SaveChangesAsync();
    }

    private async Task<int> SetupAsync(CreateCPGoalsDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateCPGoalsDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => CPGoalsFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "CPGoals", "Disease" RESTART IDENTITY CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();

        var (resp, res) = await app.Client.POSTAsync<Create, CreateCPGoalsDto, int>(CPGoalsFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(CPGoalsFaker.CreateDto);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = id,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        var resp = await app.Client.DELETEAsync<Delete, int>(C4WX1Faker.Id);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(CPGoalsFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CPGoalsDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.CPGoalsInfo.ShouldBe(CPGoalsFaker.CreateDto.CPGoalsInfo);
        res.DiseaseID_FK.ShouldBe(CPGoalsFaker.CreateDto.DiseaseID_FK);
        res.CPGoalsID.ShouldBe(id);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CPGoalsDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithDefaultSort()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.CPGoalsInfo).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.CPGoalsInfo).ShouldBeInOrder();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithDiseaseNameSort()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = $"DiseaseName {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Disease.DiseaseName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = $"DiseaseName {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Disease.DiseaseName).ShouldBeInOrder();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var pageSize = state.LowPageSize;
        var expectedCount = Math.Min(createCount, pageSize);
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);

        pageSize = state.HighPageSize;
        expectedCount = Math.Min(createCount, pageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(CPGoalsFaker.CreateDto);
        var req = CPGoalsFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateCPGoalsDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = CPGoalsFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateCPGoalsDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
