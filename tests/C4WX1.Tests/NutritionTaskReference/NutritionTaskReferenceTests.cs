using C4WX1.API.Features.NutritionTaskReference.Constants;
using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.NutritionTaskReference;

[Collection<C4WX1TestCollection>]
public class NutritionTaskReferenceTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task SetupDendenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.CodeType.AddAsync(new Database.Models.CodeType
        {
            CodeTypeName = "control-CodeTypeName"
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task<int> SetupAsync(CreateNutritionTaskReferenceDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateNutritionTaskReferenceDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(NutritionTaskReferenceFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "CodeType", "Code", "NutritionTaskReference" RESTART IDENTITY CASCADE;
            """);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDendenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateNutritionTaskReferenceDto, int>(
            NutritionTaskReferenceFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDendenciesAsync();
        var id = await SetupAsync(NutritionTaskReferenceFaker.CreateDto);
        var req = NutritionTaskReferenceFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateNutritionTaskReferenceDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        await SetupDendenciesAsync();
        var req = NutritionTaskReferenceFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateNutritionTaskReferenceDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDendenciesAsync();
        var id = await SetupAsync(NutritionTaskReferenceFaker.CreateDto);
        var req = C4WX1Faker.DeleteDto(id);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        await SetupDendenciesAsync();
        var req = C4WX1Faker.DeleteDto();
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDendenciesAsync();
        var id = await SetupAsync(NutritionTaskReferenceFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, NutritionTaskReferenceDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ReferenceID.ShouldBe(id);
        res.ReferenceDetail.ShouldBe(NutritionTaskReferenceFaker.CreateDto.ReferenceDetail);
        res.Value.ShouldBe(NutritionTaskReferenceFaker.CreateDto.Value);
        res.ReferenceImage.ShouldBe(NutritionTaskReferenceFaker.CreateDto.ReferenceImage);
        res.GroupID_FK.ShouldBe(NutritionTaskReferenceFaker.CreateDto.GroupID_FK);
        res.CreatedBy_FK.ShouldBe(NutritionTaskReferenceFaker.CreateDto.UserId);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        await SetupDendenciesAsync();
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, NutritionTaskReferenceDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDendenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        await SetupDendenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ReferenceID).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDendenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ReferenceID).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.ReferenceID).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        await SetupDendenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ReferenceID).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ReferenceID).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                OrderBy = $"{SortColumns.GroupID} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.GroupID_FK).ShouldBeInOrder();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                OrderBy = $"{SortColumns.GroupID} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.GroupID_FK).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetByGroupId_WithExistingGroupId()
    {
        await SetupDendenciesAsync();
        var id = await SetupAsync(NutritionTaskReferenceFaker.CreateDto);
        var (resp, res) = await app.Client.GETAsync<GetByGroupId, GetNutritionTaskReferenceByGroupIdDto, NutritionTaskReferenceGroupDto>(
            new()
            {
                GroupId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.GroupID.ShouldBe(1);
        res.GroupName.ShouldBe("control-CodeTypeName");
        await CleanupAsync();
    }

    [Fact]
    public async Task GetByGroupId_WithNonExistentGroupId()
    {
        await SetupDendenciesAsync();
        var id = await SetupAsync(NutritionTaskReferenceFaker.CreateDto);
        var (resp, res) = await app.Client.GETAsync<GetByGroupId, GetNutritionTaskReferenceByGroupIdDto, NutritionTaskReferenceDto>(
            new()
            {
                GroupId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    // Skipping GetAllGroup Integration Tests since it's very specific to the few CodeTypeID defined

    [Fact]
    public async Task GetListForControl()
    {
        await SetupDendenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetListForControl, GetNutritionTaskReferenceListByTypeDto, IEnumerable<NutritionTaskReferenceDto>>(
            new()
            {
                Type = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);
        await CleanupAsync();
    }
}
