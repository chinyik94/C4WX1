using C4WX1.API.Features.CarePlanSubGoal.Endpoints;
using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.Tests.Shared;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.CarePlanSubGoal;

[Collection<C4WX1TestCollection>]
public class CarePlanSubGoalTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateCarePlanSubGoalDto Control => new()
    {
        CarePlanSubGoalName = "control-CarePlanSubGoalName",
        CarePlanSubID_FK = 1,
        UserId = 1
    };

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

        var (resp, res) = await app.Client.POSTAsync<Create, CreateCarePlanSubGoalDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

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
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CarePlanSubGoalDto>(
            new()
            {
                Id = id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.CarePlanSubGoalID.ShouldBe(id);
        res.CarePlanSubGoalName.ShouldBe(Control.CarePlanSubGoalName);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CarePlanSubGoalDto>(
            new()
            {
                Id = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCarePlanSubGoalDto
            {
                CarePlanSubID_FK = 1,
                CarePlanSubGoalName = CarePlanSubGoalFaker.CarePlanSubGoalName,
                UserId = 1
            });
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

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
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCarePlanSubGoalDto
            {
                CarePlanSubID_FK = 1,
                CarePlanSubGoalName = CarePlanSubGoalFaker.CarePlanSubGoalName,
                UserId = 1
            });
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

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
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCarePlanSubGoalDto
            {
                CarePlanSubID_FK = 1,
                CarePlanSubGoalName = CarePlanSubGoalFaker.CarePlanSubGoalName,
                UserId = 1
            });
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

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
        res2.Select(x => x.CarePlanSubGoalName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WtihExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var resp = await app.Client.PUTAsync<Update, UpdateCarePlanSubGoalDto>(
            new UpdateCarePlanSubGoalDto
            {
                CarePlanSubGoalID = id,
                CarePlanSubGoalName = "updated-CarePlanSubGoalName",
                CarePlanSubID_FK = Control.CarePlanSubID_FK,
                UserId = Control.UserId
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateCarePlanSubGoalDto>(
            new UpdateCarePlanSubGoalDto
            {
                CarePlanSubGoalID = C4WX1Faker.Id,
                CarePlanSubGoalName = "updated-CarePlanSubGoalName",
                CarePlanSubID_FK = Control.CarePlanSubID_FK,
                UserId = Control.UserId
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
