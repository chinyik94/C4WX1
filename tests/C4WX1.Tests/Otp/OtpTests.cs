using C4WX1.API.Features.Otp.Dtos;
using C4WX1.API.Features.Otp.Endpoints;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Otp;

[Collection<C4WX1TestCollection>]
public class OtpTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task<int> SetupAsync(CreateOtpDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateOtpDto, OtpDto>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.OtpId.ShouldBeGreaterThan(0);
        return res.OtpId;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(OtpFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Otp" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateOtpDto, OtpDto>(OtpFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.OtpId.ShouldBeGreaterThan(0);
        res.UserId.ShouldBe(OtpFaker.CreateDto.UserId);
        res.IsActive.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDummiesAsync(state.CreateCount);
        var id = await SetupAsync(OtpFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, OtpDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.OtpId.ShouldBe(id);
        res.UserId.ShouldBe(OtpFaker.CreateDto.UserId);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, OtpDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetByUserId_WithExistingUserId()
    {
        await SetupDummiesAsync(state.CreateCount);
        var id = await SetupAsync(OtpFaker.CreateDto);
        var (resp, res) = await app.Client.GETAsync<GetByUserId, GetOtpByUserIdDto, OtpDto>(
            new()
            {
                UserId = OtpFaker.CreateDto.UserId
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.OtpId.ShouldBe(id);
        res.UserId.ShouldBe(OtpFaker.CreateDto.UserId);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetByUserId_WithNonExistentUserId()
    {
        var (resp, res) = await app.Client.GETAsync<GetByUserId, GetOtpByUserIdDto, OtpDto>(
            new()
            {
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }
}
