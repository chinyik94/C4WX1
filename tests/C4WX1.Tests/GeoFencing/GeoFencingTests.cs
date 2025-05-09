using C4WX1.API.Features.GeoFencing.Constants;
using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.GeoFencing;

[Collection<C4WX1TestCollection>]
public class GeoFencingTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task<int> SetupAsync(CreateGeoFencingDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateGeoFencingDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => GeoFencingFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "GeoFencing" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateGeoFencingDto, int>(GeoFencingFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(GeoFencingFaker.CreateDto);
        var req = GeoFencingFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateGeoFencingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = GeoFencingFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateGeoFencingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        var id = await SetupAsync(GeoFencingFaker.CreateDto);
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
        var id = await SetupAsync(GeoFencingFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, GeoFencingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.IP.ShouldBe(GeoFencingFaker.CreateDto.IP);
        res.Description.ShouldBe(GeoFencingFaker.CreateDto.Description);
        res.CreatedBy_FK.ShouldBe(GeoFencingFaker.CreateDto.UserId);
        res.IsDeleted.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, GeoFencingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetAllList()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetAllList, IEnumerable<GeoFencingDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);
        res.Select(x => x.IP).ShouldBeInOrder();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new() { });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.IP).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.IP).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.IP).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.IP).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.IP).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Ip} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.IP).ShouldBeInOrder();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Ip} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.IP).ShouldBeInOrder(SortDirection.Descending);

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Description} {SortDirections.Asc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.Description).ShouldBeInOrder();

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Description} {SortDirections.Desc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.Description).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetIsWhitelisted()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetIsWhitelisted, GetGeoFencingIsWhiteListedDto, bool>(
            new()
            {
                IP = GeoFencingFaker.CreateDto.IP
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeFalse();

        await CleanupAsync();
    }
}
