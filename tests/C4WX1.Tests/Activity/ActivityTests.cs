using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.Tests.Activity;

[Collection<C4WX1TestCollection>]
public class ActivityTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateActivityDto Control => new()
    {
        ProblemListID_FK = 1,
        DiseaseID_FK = 1,
        ActivityDetail = "control-ActivityDetail",
        UserId = 1
    };

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

    [Fact]
    public async Task Create_WithoutDiseaseSubInfo()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateActivityDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Create_WithDiseaseSubInfo()
    {
        await SetupDependenciesAsync();
        var control = Control;
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
        var id = await SetupAsync(Control);

        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(new()
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
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(new()
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
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ActivityDto>(new()
        {
            Id = id
        });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ActivityID.ShouldBe(id);
        res.ActivityDetail.ShouldBe(Control.ActivityDetail);
        res.DiseaseID_FK.ShouldBe(Control.DiseaseID_FK);
        res.DiseaseSubInfoID_FK.ShouldBe(Control.DiseaseSubInfoID_FK);
        res.ProblemListID_FK.ShouldBe(Control.ProblemListID_FK);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ActivityDto>(new()
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
        var expectedCount = state.CreateCount;
        for (int i = 0; i < expectedCount; i++)
        {
            var dummy = Control;
            dummy.ActivityDetail = ActivityFaker.DummyActivityDetail;
            await SetupAsync(dummy);
        }

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
        for (int i = 0; i < createCount; i++)
        {
            var dummy = Control;
            dummy.ActivityDetail = ActivityFaker.DummyActivityDetail;
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                OrderBy = $"default desc"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ActivityDetail).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                OrderBy = $"default asc"
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
        for (int i = 0; i < createCount; i++)
        {
            var dummy = Control;
            dummy.ActivityDetail = ActivityFaker.DummyActivityDetail;
            await SetupAsync(dummy);
        }

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
        var pageSize = 5;
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, pageSize);
        for (int i = 0; i < createCount; i++)
        {
            var dummy = Control;
            dummy.ActivityDetail = ActivityFaker.DummyActivityDetail;
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ActivityDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);

        pageSize = 100;
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
        var id = await SetupAsync(Control);

        var resp = await app.Client.PUTAsync<Update, UpdateActivityDto>(new()
        {
            ActivityID = id,
            ActivityDetail = "updated-control-ActivityDetail",
            ProblemListID_FK = 1,
            DiseaseID_FK = 1,
            UserId = 1
        });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateActivityDto>(new()
        {
            ActivityID = C4WX1Faker.Id,
            ActivityDetail = "updated-control-ActivityDetail",
            ProblemListID_FK = 1,
            DiseaseID_FK = 1,
            UserId = 1
        });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}