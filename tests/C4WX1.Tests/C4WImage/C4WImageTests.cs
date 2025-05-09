using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.C4WImage;

[Collection<C4WX1TestCollection>]
public class C4WImageTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private async Task<int> SetupAsync(CreateC4WImageDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateC4WImageDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => C4WImageFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        await using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "C4WImage" CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        for (int i = 0; i < state.CreateCount; i++)
        {
            var req = C4WImageFaker.CreateDummy;
            var (resp, res) = await app.Client.POSTAsync<Create, CreateC4WImageDto, int>(req);
            resp.IsSuccessStatusCode.ShouldBeTrue();
            res.ShouldBeGreaterThan(0);
        }

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithInRangeDates()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        var req = new GetC4WImageListDto
        {
            FromDate = DateTime.Now.AddDays(-1),
            ToDate = DateTime.Now.AddDays(1)
        };

        var (resp, res) = await app.Client.GETAsync<GetList, GetC4WImageListDto, IEnumerable<C4WImageDto>>(
            req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBeLessThanOrEqualTo(expectedCount);
        res.Select(x => x.C4WImageId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOutOfRangeDates()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var req = new GetC4WImageListDto
        {
            FromDate = DateTime.Now.AddDays(2),
            ToDate = DateTime.Now.AddDays(3)
        };

        var (resp, res) = await app.Client.GETAsync<GetList, GetC4WImageListDto, IEnumerable<C4WImageDto>>(
            req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldBeEmpty();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var pageSize = state.HighPageSize;
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, pageSize);
        var req = new GetC4WImageListDto
        {
            FromDate = DateTime.Now.AddDays(-1),
            ToDate = DateTime.Now.AddDays(1),
            PageSize = pageSize
        };

        var (resp, res) = await app.Client.GETAsync<GetList, GetC4WImageListDto, IEnumerable<C4WImageDto>>(
            req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBeLessThanOrEqualTo(expectedCount);
        res.Select(x => x.C4WImageId).ShouldBeInOrder(SortDirection.Descending);

        var pageSize2 = state.LowPageSize;
        var expectedCount2 = Math.Min(createCount, pageSize2);
        var req2 = new GetC4WImageListDto
        {
            FromDate = DateTime.Now.AddDays(-1),
            ToDate = DateTime.Now.AddDays(1),
            PageSize = pageSize2
        };
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetC4WImageListDto, IEnumerable<C4WImageDto>>(
            req2);
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.ShouldNotBeEmpty();
        res2.Count().ShouldBeLessThanOrEqualTo(expectedCount2);
        res.Select(x => x.C4WImageId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithSpecificOrder()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        var req = new GetC4WImageListDto
        {
            FromDate = DateTime.Now.AddDays(-1),
            ToDate = DateTime.Now.AddDays(1),
            OrderBy = $"C4WImageId {SortDirections.Asc}"
        };

        var (resp, res) = await app.Client.GETAsync<GetList, GetC4WImageListDto, IEnumerable<C4WImageDto>>(
            req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBeLessThanOrEqualTo(expectedCount);
        res.Select(x => x.C4WImageId).ShouldBeInOrder();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var req = new GetC4WImageCountByDateDto
        {
            FromDate = DateTime.Now.AddDays(-1),
            ToDate = DateTime.Now.AddDays(1)
        };
        var (resp, res) = await app.Client.GETAsync<GetCount, GetC4WImageCountByDateDto, int>(
            req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var id = await SetupAsync(C4WImageFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, C4WImageDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.C4WImageId.ShouldBe(id);
        res.WoundImageName.ShouldBe(C4WImageFaker.CreateDto.WoundImageName);
        res.WoundImageData.ShouldBe(C4WImageFaker.CreateDto.WoundImageData);
        res.WoundBedImageName.ShouldBe(C4WImageFaker.CreateDto.WoundBedImageName);
        res.WoundBedImageData.ShouldBe(C4WImageFaker.CreateDto.WoundBedImageData);
        res.TissueImageName.ShouldBe(C4WImageFaker.CreateDto.TissueImageName);
        res.TissueImageData.ShouldBe(C4WImageFaker.CreateDto.TissueImageData);
        res.DepthImageName.ShouldBe(C4WImageFaker.CreateDto.DepthImageName);
        res.DepthImageData.ShouldBe(C4WImageFaker.CreateDto.DepthImageData);
        res.CreatedBy_FK.ShouldBe(C4WImageFaker.CreateDto.UserId);
        
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, C4WImageDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(C4WImageFaker.CreateDto);
        var req = C4WImageFaker.UpdateDto(id);

        var resp = await app.Client.PUTAsync<Update, UpdateC4WImageDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = C4WImageFaker.UpdateDto();

        var resp = await app.Client.PUTAsync<Update, UpdateC4WImageDto>(req);

        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
