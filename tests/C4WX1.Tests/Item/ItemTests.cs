using C4WX1.API.Features.Item.Constants;
using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Item;

[Collection<C4WX1TestCollection>]
public class ItemTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task<int> SetupAsync(CreateItemDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateItemDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(ItemFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        IEnumerable<Database.Models.Code> codes = [
            new()
            {
                CodeName = "control-ItemUnitCode",
                CodeTypeId_FKNavigation = new Database.Models.CodeType
                {
                    CodeTypeName = "control-ItemUnitCodeType"
                },
            },
            new()
            {
                CodeName = "control-CategoryCode",
                CodeTypeId_FKNavigation = new Database.Models.CodeType
                {
                    CodeTypeName = "control-CategoryCodeType"
                },
            }
            ];
        await dbContext.Code.AddRangeAsync(codes, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Code", "Item" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateItemDto, int>(ItemFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ItemFaker.CreateDto);
        var req = ItemFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateItemDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = ItemFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateItemDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ItemFaker.CreateDto);
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
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        await SetupAsync(ItemFaker.CreateDto);
        createCount++;

        var (resp, res) = await app.Client.GETAsync<GetCount, GetItemCountDto, int>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetItemCountDto, int>(
            new()
            {
                Keyword = ItemFaker.CreateDto.ItemName
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(1);

        var (resp3, res3) = await app.Client.GETAsync<GetCount, GetItemCountDto, int>(
            new()
            {
                GroupId = 1
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        await SetupAsync(ItemFaker.CreateDto);
        createCount++;
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                Keyword = ItemFaker.CreateDto.ItemName
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(1);
        res2.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                GroupId = 1
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
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
    public async Task GetList_WithOrder()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ItemName).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ItemName).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Group} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.CategoryName).ShouldBeInOrder();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Group} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.CategoryName).ShouldBeInOrder(SortDirection.Descending);

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Unit} {SortDirections.Asc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.ItemUnitName).ShouldBeInOrder();

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Unit} {SortDirections.Desc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.ItemUnitName).ShouldBeInOrder(SortDirection.Descending);

        var (resp7, res7) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.UnitPrice} {SortDirections.Asc}"
            });
        resp7.IsSuccessStatusCode.ShouldBeTrue();
        res7.Count().ShouldBe(expectedCount);
        res7.Select(x => x.UnitPrice).ShouldBeInOrder();

        var (resp8, res8) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.UnitPrice} {SortDirections.Desc}"
            });
        resp8.IsSuccessStatusCode.ShouldBeTrue();
        res8.Count().ShouldBe(expectedCount);
        res8.Select(x => x.UnitPrice).ShouldBeInOrder(SortDirection.Descending);

        var (resp9, res9) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Quantity} {SortDirections.Asc}"
            });
        resp9.IsSuccessStatusCode.ShouldBeTrue();
        res9.Count().ShouldBe(expectedCount);
        res9.Select(x => x.Quantity).ShouldBeInOrder();

        var (resp10, res10) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Quantity} {SortDirections.Desc}"
            });
        resp10.IsSuccessStatusCode.ShouldBeTrue();
        res10.Count().ShouldBe(expectedCount);
        res10.Select(x => x.Quantity).ShouldBeInOrder(SortDirection.Descending);

        var (resp11, res11) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Billing} {SortDirections.Asc}"
            });
        resp11.IsSuccessStatusCode.ShouldBeTrue();
        res11.Count().ShouldBe(expectedCount);
        res11.Select(x => x.AvailableInBilling).ShouldBeInOrder();

        var (resp12, res12) = await app.Client.GETAsync<GetList, GetItemListDto, IEnumerable<ItemDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Billing} {SortDirections.Desc}"
            });
        resp12.IsSuccessStatusCode.ShouldBeTrue();
        res12.Count().ShouldBe(expectedCount);
        res12.Select(x => x.AvailableInBilling).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetAllListByType()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetAllListByType, GetAllItemListByTypeDto, IEnumerable<ItemDto>>(
            new()
            {
                TypeId = 2
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetAllListByType, GetAllItemListByTypeDto, IEnumerable<ItemDto>>(
            new()
            {
                TypeId = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListByType()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetListByType, GetItemListByTypeDto, IEnumerable<ItemDto>>(
            new()
            {
                TypeId = 2
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetListByType, GetItemListByTypeDto, IEnumerable<ItemDto>>(
            new()
            {
                TypeId = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListByGroupName()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetListByGroupName, GetItemListByGroupNameDto, IEnumerable<ItemDto>>(
            new()
            {
                GroupName = "control-CategoryCode"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetListByGroupName, GetItemListByGroupNameDto, IEnumerable<ItemDto>>(
            new()
            {
                GroupName = C4WX1Faker.ShortString
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }
}
