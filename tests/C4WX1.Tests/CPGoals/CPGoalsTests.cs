using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Endpoints;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.CPGoals;

[Collection<C4WX1TestCollection>]
public class CPGoalsTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateCPGoalsDto Control => new()
    {
        DiseaseID_FK = 1,
        CPGoalsInfo = "control-CPGoalsInfo",
        UserId = 1
    };

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

        var (resp, res) = await app.Client.POSTAsync<Create, CreateCPGoalsDto, int>(Control);
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
        var resp = await app.Client.DELETEAsync<Delete, int>(C4WX1Faker.Id);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CPGoalsDto>(
            new()
            {
                Id = id,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.CPGoalsInfo.ShouldBe(Control.CPGoalsInfo);
        res.DiseaseID_FK.ShouldBe(Control.DiseaseID_FK);
        res.CPGoalsID.ShouldBe(id);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, CPGoalsDto>(
            new()
            {
                Id = C4WX1Faker.Id,
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCPGoalsDto
            {
                DiseaseID_FK = 1,
                CPGoalsInfo = CPGoalsFaker.CPGoalsInfo,
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
    public async Task GetList_WithDefaultSort()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCPGoalsDto
            {
                DiseaseID_FK = 1,
                CPGoalsInfo = CPGoalsFaker.CPGoalsInfo,
                UserId = 1
            });
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = "default desc"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.CPGoalsInfo).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = "default asc"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.CPGoalsInfo).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithDiseaseNameSort()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCPGoalsDto
            {
                DiseaseID_FK = 1,
                CPGoalsInfo = CPGoalsFaker.CPGoalsInfo,
                UserId = 1
            });
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = "DiseaseName desc"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Disease.DiseaseName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                OrderBy = "DiseaseName asc"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Disease.DiseaseName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var pageSize = 5;
        var expectedCount = Math.Min(createCount, pageSize);
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => new CreateCPGoalsDto
            {
                DiseaseID_FK = 1,
                CPGoalsInfo = CPGoalsFaker.CPGoalsInfo,
                UserId = 1
            });
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<CPGoalsDto>>(
            new()
            {
                PageSize = pageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);

        pageSize = 100;
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
        var id = await SetupAsync(Control);
        var resp = await app.Client.PUTAsync<Update, UpdateCPGoalsDto>(
            new()
            {
                Id = id,
                CPGoalsInfo = "updated-control-CPGoalsInfo",
                DiseaseID_FK = Control.DiseaseID_FK,
                UserId = Control.UserId
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateCPGoalsDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                CPGoalsInfo = "updated-control-CPGoalsInfo",
                DiseaseID_FK = Control.DiseaseID_FK,
                UserId = Control.UserId
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
