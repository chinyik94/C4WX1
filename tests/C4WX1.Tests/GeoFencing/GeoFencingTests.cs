using C4WX1.API.Features.GeoFencing.Constants;
using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.GeoFencing;

[Collection<C4WX1TestCollection>]
public class GeoFencingTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateGeoFencingDto Control => new()
    {
        IP = "control-IP",
        Description = "control-Description",
        UserId = 1
    };

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
        var (resp, res) = await app.Client.POSTAsync<Create, CreateGeoFencingDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(Control);
        var resp = await app.Client.PUTAsync<Update, UpdateGeoFencingDto>(
            new()
            {
                Id = id,
                IP = "updated-IP",
                Description = "updated-Description",
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateGeoFencingDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                IP = "updated-IP",
                Description = "updated-Description",
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
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
        var id = await SetupAsync(Control);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, GeoFencingDto>(
            new()
            {
                Id = id,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.IP.ShouldBe(Control.IP);
        res.Description.ShouldBe(Control.Description);
        res.CreatedBy_FK.ShouldBe(Control.UserId);
        res.IsDeleted.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, GeoFencingDto>(
            new()
            {
                Id = C4WX1Faker.Id,
            });
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
        res.Select(x => x.IP).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {

            });
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
        res.Select(x => x.IP)
            .SequenceEqual(res.Select(x => x.IP).OrderBy(x => x))
            .ShouldBeTrue();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.IP)
            .SequenceEqual(res2.Select(x => x.IP).OrderByDescending(x => x))
            .ShouldBeTrue();

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Ip} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.IP)
            .SequenceEqual(res3.Select(x => x.IP).OrderBy(x => x))
            .ShouldBeTrue();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Ip} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.IP)
            .SequenceEqual(res4.Select(x => x.IP).OrderByDescending(x => x))
            .ShouldBeTrue();

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Description} {SortDirections.Asc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.Description)
            .SequenceEqual(res5.Select(x => x.Description).OrderBy(x => x))
            .ShouldBeTrue();

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<GeoFencingDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Description} {SortDirections.Desc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.Description)
            .SequenceEqual(res6.Select(x => x.Description).OrderByDescending(x => x))
            .ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetIsWhitelisted()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetIsWhitelisted, GetGeoFencingIsWhiteListedDto, bool>(
            new()
            {
                IP = Control.IP
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeFalse();

        await CleanupAsync();
    }
}
