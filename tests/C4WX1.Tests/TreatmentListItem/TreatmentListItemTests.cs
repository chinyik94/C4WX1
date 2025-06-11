using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.TreatmentListItem.Constants;
using C4WX1.API.Features.TreatmentListItem.Dtos;
using C4WX1.API.Features.TreatmentListItem.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.TreatmentListItem;

[Collection<C4WX1TestCollection>]
public class TreatmentListItemTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Code.AddAsync(new Database.Models.Code
        {
            CodeName = "test-treatment-list-item-code",
            CodeTypeId_FKNavigation = new Database.Models.CodeType
            {
                CodeTypeName = "test-treatment-list-item-code-type"
            }
        }, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    private async Task<int> SetupAsync(CreateTreatmentListItemDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateTreatmentListItemDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(TreatmentListItemFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Code", "TreatmentListItem" RESTART IDENTITY CASCADE;
            """, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateTreatmentListItemDto, int>(
            TreatmentListItemFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        var (resp2, res2) = await app.Client.POSTAsync<Create, CreateTreatmentListItemDto, int>(
            TreatmentListItemFaker.CreateDto);
        resp2.IsSuccessStatusCode.ShouldBeFalse();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(TreatmentListItemFaker.CreateDto);
        var req = TreatmentListItemFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateTreatmentListItemDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = TreatmentListItemFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateTreatmentListItemDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(TreatmentListItemFaker.CreateDto);
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
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById()
    {
        await SetupDependenciesAsync();
        var createDto = TreatmentListItemFaker.CreateDto;
        var id = await SetupAsync(createDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, TreatmentListItemDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.TListItemID.ShouldBe(id);
        res.TListTypeID_FK.ShouldBe(createDto.TListTypeID_FK);
        res.ItemBrand.ShouldBe(createDto.ItemBrand);
        res.ItemName.ShouldBe(createDto.ItemName);
        res.Cost.ShouldBe(createDto.Cost);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, TreatmentListItemDto>(req);
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
        var (resp, res) = await app.Client.GETAsync<GetCount, GetTreatmentListItemCountDto, int>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        var createDto = TreatmentListItemFaker.CreateDto;
        await SetupAsync(createDto);
        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetTreatmentListItemCountDto, int>(
            new()
            {
                ProductName = createDto.ItemName
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(1);

        var (resp3, res3) = await app.Client.GETAsync<GetCount, GetTreatmentListItemCountDto, int>(
            new()
            {
                ProductType = createDto.TListTypeID_FK
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldBe(createCount + 1);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var createDto = TreatmentListItemFaker.CreateDto;
        await SetupAsync(createDto);
        var (resp1, res1) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                ProductName = createDto.ItemName
            });
        resp1.IsSuccessStatusCode.ShouldBeTrue();
        res1.Count().ShouldBe(1);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                ProductType = createDto.TListTypeID_FK
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount1 = Math.Min(createCount, state.LowPageSize);
        var (resp1, res1) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp1.IsSuccessStatusCode.ShouldBeTrue();
        res1.Count().ShouldBe(expectedCount1);
        res1.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ItemName).ShouldBeInOrder();

        var (resp1, res1) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp1.IsSuccessStatusCode.ShouldBeTrue();
        res1.Count().ShouldBe(expectedCount);
        res1.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.ProductType} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.TListTypeID_FK).ShouldBeInOrder();

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.ProductType} {SortDirections.Desc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.TListTypeID_FK).ShouldBeInOrder(SortDirection.Descending);

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.ItemBrand} {SortDirections.Asc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.ItemBrand).ShouldBeInOrder();

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.ItemBrand} {SortDirections.Desc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.ItemBrand).ShouldBeInOrder(SortDirection.Descending);

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.IsActive} {SortDirections.Asc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.IsActive).ShouldBeInOrder();

        var (resp7, res7) = await app.Client.GETAsync<GetList, GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.IsActive} {SortDirections.Desc}"
            });
        resp7.IsSuccessStatusCode.ShouldBeTrue();
        res7.Count().ShouldBe(expectedCount);
        res7.Select(x => x.IsActive).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task Activate()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(TreatmentListItemFaker.CreateDto);
        var resp = await app.Client.POSTAsync<Activate, ActivateTreatmentListItemDto>(
            new()
            {
                Id = id,
                UserId = C4WX1Faker.Id
            });
        // Currently always return 400 because IsSystemUsed is not updatable
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Activate_WithNonExistentId()
    {
        var resp = await app.Client.POSTAsync<Activate, ActivateTreatmentListItemDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Deactivate()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(TreatmentListItemFaker.CreateDto);
        var resp = await app.Client.POSTAsync<Deactivate, DeactivateTreatmentListItemDto>(
            new()
            {
                Id = id,
                UserId = C4WX1Faker.Id
            });
        // Currently always return 400 because IsSystemUsed is not updatable
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Deactivate_WithNonExistentId()
    {
        var resp = await app.Client.POSTAsync<Deactivate, DeactivateTreatmentListItemDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }
}
