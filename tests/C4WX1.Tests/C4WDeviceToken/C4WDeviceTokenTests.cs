using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Endpoints;

namespace C4WX1.Tests.C4WDeviceToken;

[Collection<C4WX1TestCollection>]
public class C4WDeviceTokenTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private async Task<int> SetupAsync(CreateC4WDeviceTokenDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateC4WDeviceTokenDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task CleanupAsync()
    {
        await using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "C4WDeviceToken";
            """);
    }

    [Fact]
    public async Task Create()
    {
        for (int i = 0; i < state.CreateCount; i++)
        {
            var (resp2, res2) = await app.Client.POSTAsync<Create, CreateC4WDeviceTokenDto, int>(
                C4WDeviceTokenFaker.CreateDummy);
            resp2.IsSuccessStatusCode.ShouldBeTrue();
            res2.ShouldBeGreaterThan(0);
        }

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByOldDeviceToken_WithExistingOldDeviceToken()
    {
        var expected = C4WDeviceTokenFaker.CreateDto;
        var id = await SetupAsync(expected);

        expected.OldDeviceToken.ShouldNotBeNullOrWhiteSpace();
        var (resp, res) = await app.Client.GETAsync<GetByOldDeviceToken, GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto>(
            new()
            {
                OldDeviceToken = expected.OldDeviceToken
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.C4WDeviceTokenId.ShouldBeGreaterThan(0);
        res.C4WDeviceTokenId.ShouldBe(id);
        res.OldDeviceToken.ShouldBe(expected.OldDeviceToken);
        res.NewDeviceToken.ShouldBe(expected.NewDeviceToken);
        res.ClientEnvironment.ShouldBe(expected.ClientEnvironment);
        res.Device.ShouldBe(expected.Device);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByOldDeviceToken_WithNonExistentOldDeviceToken()
    {
        var (resp, res) = await app.Client.GETAsync<GetByOldDeviceToken, GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto>(
            new()
            {
                OldDeviceToken = C4WDeviceTokenFaker.OldDeviceToken
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(C4WDeviceTokenFaker.CreateDto);
        var req = C4WDeviceTokenFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateC4WDeviceTokenDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = C4WDeviceTokenFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateC4WDeviceTokenDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
