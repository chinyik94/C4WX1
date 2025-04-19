using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.Tests.C4WImage;

[Collection<C4WX1TestCollection>]
public class C4WImageTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private CreateC4WImageDto NewControlData => new()
    {
        WoundImageName = "Control-WoundImageName",
        WoundImageData = "Control-WoundImageData",
        WoundBedImageName = "Control-WoundBedImageName",
        WoundBedImageData = "Control-WoundBedImageData",
        TissueImageName = "Control-TissueImageName",
        TissueImageData = "Control-TissueImageData",
        DepthImageName = "Control-DepthImageName",
        DepthImageData = "Control-DepthImageData",
        UserId = 1
    };

    private UpdateC4WImageDto UpdatedControlData => new()
    {
        WoundImageName = "Updated-Control-WoundImageName",
        WoundImageData = "Updated-Control-WoundImageData",
        WoundBedImageName = "Updated-Control-WoundBedImageName",
        WoundBedImageData = "Updated-Control-WoundBedImageData",
        TissueImageName = "Updated-Control-TissueImageName",
        TissueImageData = "Updated-Control-TissueImageData",
        DepthImageName = "Updated-Control-DepthImageName",
        DepthImageData = "Updated-Control-DepthImageData",
        UserId = 1
    };

    private async Task<int> SetupAsync(CreateC4WImageDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateC4WImageDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
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
            var req = C4WImageFaker.CreateDto();
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
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(C4WImageFaker.CreateDto());
        }
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
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(C4WImageFaker.CreateDto());
        }
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
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(C4WImageFaker.CreateDto());
        }
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
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(C4WImageFaker.CreateDto());
        }
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
        res.Select(x => x.C4WImageId).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        for (int i = 0; i < createCount; i++)
        {
            await SetupAsync(C4WImageFaker.CreateDto());
        }
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
        var id = await SetupAsync(NewControlData);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, C4WImageDto>(
            new()
            {
                Id = id
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.C4WImageId.ShouldBe(id);
        res.WoundImageName.ShouldBe(NewControlData.WoundImageName);
        res.WoundImageData.ShouldBe(NewControlData.WoundImageData);
        res.WoundBedImageName.ShouldBe(NewControlData.WoundBedImageName);
        res.WoundBedImageData.ShouldBe(NewControlData.WoundBedImageData);
        res.TissueImageName.ShouldBe(NewControlData.TissueImageName);
        res.TissueImageData.ShouldBe(NewControlData.TissueImageData);
        res.DepthImageName.ShouldBe(NewControlData.DepthImageName);
        res.DepthImageData.ShouldBe(NewControlData.DepthImageData);
        res.CreatedBy_FK.ShouldBe(NewControlData.UserId);
        
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = new GetByIdDto
        {
            Id = C4WX1Faker.Id
        };

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, C4WImageDto>(
            req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(NewControlData);
        var req = UpdatedControlData;
        req.C4WImageId = id;

        var resp = await app.Client.PUTAsync<Update, UpdateC4WImageDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = UpdatedControlData;
        req.C4WImageId = C4WX1Faker.Id;

        var resp = await app.Client.PUTAsync<Update, UpdateC4WImageDto>(req);

        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
