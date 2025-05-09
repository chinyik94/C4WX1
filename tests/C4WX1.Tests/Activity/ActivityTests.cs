using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Activity;

[Collection<C4WX1TestCollection>]
public class ActivityTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.DiseaseSubInfo.AddAsync(new Database.Models.DiseaseSubInfo
        {
            DiseaseSubInfo1 = "control-DiseaseSubInfo1",
            DiseaseID_FKNavigation = new Database.Models.Disease
            {
                DiseaseName = "control-DiseaseName",
                SystemID_FKNavigation = new Database.Models.SystemForDisease
                {
                    System = "control-System",
                }
            }
        });
        await dbContext.ProblemList.AddAsync(new Database.Models.ProblemList
        {
            DiseaseID_FKNavigation = new Database.Models.Disease
            {
                DiseaseName = "control-DiseaseName",
                SystemID_FKNavigation = new Database.Models.SystemForDisease
                {
                    System = "control-System",
                }
            },
            ProblemInfo = "control-ProblemInfo"
        });
        await dbContext.SystemForDisease.AddAsync(new Database.Models.SystemForDisease
        {
            System = "control-System"
        });
        await dbContext.SaveChangesAsync();
    }

    private async Task<int> SetupAsync(CreateActivityDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateActivityDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Activity", "DiseaseSubInfo", "SystemForDisease", "ProblemList" RESTART IDENTITY CASCADE;
            """);
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => ActivityFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    [Fact]
    public async Task Create_WithoutDiseaseSubInfo()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateActivityDto, int>(ActivityFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Create_WithDiseaseSubInfo()
    {
        await SetupDependenciesAsync();
        var control = ActivityFaker.CreateDto;
        control.DiseaseSubInfoID_FK = 1;
        var (resp, res) = await app.Client.POSTAsync<Create, CreateActivityDto, int>(control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ActivityFaker.CreateDto);
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
        var id = await SetupAsync(ActivityFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ActivityDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ActivityID.ShouldBe(id);
        res.ActivityDetail.ShouldBe(ActivityFaker.CreateDto.ActivityDetail);
        res.DiseaseID_FK.ShouldBe(ActivityFaker.CreateDto.DiseaseID_FK);
        res.DiseaseSubInfoID_FK.ShouldBe(ActivityFaker.CreateDto.DiseaseSubInfoID_FK);
        res.ProblemListID_FK.ShouldBe(ActivityFaker.CreateDto.ProblemListID_FK);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ActivityDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDependenciesAsync();
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithDefaultSort()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ActivityDetail).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ActivityDetail).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithProblemListSort()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                OrderBy = $"ProblemInfo desc"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        // Unable to verify ProblemInfo Sort since the Original API doesn't return it

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var pageSize = state.LowPageSize;
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, pageSize);
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);

        pageSize = state.HighPageSize;
        expectedCount = Math.Min(createCount, pageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ActivityFaker.CreateDto);
        var req = ActivityFaker.UpdateDto(id);

        var resp = await app.Client.PUTAsync<Update, UpdateActivityDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = ActivityFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateActivityDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}