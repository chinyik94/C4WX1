using C4WX1.API.Features.CarePlanSubGoal.Endpoints;
using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.CarePlanSubGoal;

[Collection<C4WX1TestCollection>]
public class CarePlanSubGoalTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.CarePlanSub.AddAsync(new Database.Models.CarePlanSub
        {
            CarePlanID_FKNavigation = new Database.Models.CarePlan
            {
                CarePlanName = "control-CarePlanName",
                CarePlanType = "control-CarePlanType"
            },
            SubCarePlanName = 1,
            CarePlanGroupName = "control-CarePlanGroupName"
        });
        await dbContext.SaveChangesAsync();
    }

    private async Task<int> SetupAsync(CreateCarePlanSubGoalDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateCarePlanSubGoalDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => CarePlanSubGoalFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "CarePlanSubGoal", "CarePlanSub", "CarePlan" RESTART IDENTITY CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();

        var (resp, res) = await app.Client.POSTAsync<Create, CreateCarePlanSubGoalDto, int>(CarePlanSubGoalFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(CarePlanSubGoalFaker.CreateDto);
        var req = C4WX1Faker.DeleteDto(id);

        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        var req = C4WX1Faker.DeleteDto();
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(CarePlanSubGoalFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CarePlanSubGoalDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.CarePlanSubGoalID.ShouldBe(id);
        res.CarePlanSubGoalName.ShouldBe(CarePlanSubGoalFaker.CreateDto.CarePlanSubGoalName);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CarePlanSubGoalDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
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
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var pageSize = state.LowPageSize;
        var expectedCount = Math.Min(createCount, pageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CarePlanSubGoalDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.CarePlanSubGoalName).ShouldBeInOrder(SortDirection.Descending);

        var pageSize2 = state.HighPageSize;
        var expectedCount2 = Math.Min(createCount, pageSize2);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CarePlanSubGoalDto>>(
            new()
            {
                PageSize = pageSize2
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.CarePlanSubGoalName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CarePlanSubGoalDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.CarePlanSubGoalName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CarePlanSubGoalDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.CarePlanSubGoalName).ShouldBeInOrder();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WtihExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(CarePlanSubGoalFaker.CreateDto);
        var req = CarePlanSubGoalFaker.UpdateDto(id);

        var resp = await app.Client.PUTAsync<Update, UpdateCarePlanSubGoalDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = CarePlanSubGoalFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateCarePlanSubGoalDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
