using C4WX1.API.Features.Package.Dtos;
using C4WX1.API.Features.Package.Endpoints;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Package;

[Collection<C4WX1TestCollection>]
public class PackageTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task<int> SetupAsync(CreatePackageDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreatePackageDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(PackageFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Package" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreatePackageDto, int>(
            PackageFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(PackageFaker.CreateDto);
        var req = PackageFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdatePackageDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = PackageFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdatePackageDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        var id = await SetupAsync(PackageFaker.CreateDto);
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
    public async Task GetById_WithExistingId()
    {
        var id = await SetupAsync(PackageFaker.CreateDto);
        await SetupDummiesAsync(state.CreateCount);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, PackageDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.PackageID.ShouldBe(id);
        res.PackageName.ShouldBe(PackageFaker.CreateDto.PackageName);
        res.PackageDetails.ShouldBe(PackageFaker.CreateDto.PackageDetails);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        await SetupDummiesAsync(state.CreateCount);
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, PackageDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<PackageDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.PackageName).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<PackageDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.PackageName).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<PackageDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.PackageName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<PackageDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.PackageName).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<PackageDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.PackageName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListForControl()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetListForControl, IEnumerable<PackageDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);
        res.Select(x => x.PackageName).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }
}
