using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Endpoints;
using C4WX1.Tests.Shared;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.Tests.C4WDeviceToken;

[Collection<C4WX1TestCollection>]
public class C4WDeviceTokenTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private CreateC4WDeviceTokenDto NewControlData => new()
    {
        OldDeviceToken = "Control-OldDeviceToken",
        NewDeviceToken = "Control-NewDeviceToken",
        ClientEnvironment = "Control-ClientEnvironment",
        Device = "Control-Device",
        UserId = 1
    };

    private UpdateC4WDeviceTokenDto UpdatedControlData => new()
    {
        OldDeviceToken = "Updated-Control-OldDeviceToken",
        NewDeviceToken = "Updated-Control-NewDeviceToken",
        ClientEnvironment = "Updated-Control-ClientEnvironment",
        Device = "Updated-Control-Device",
        UserId = 1
    };

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
                C4WDeviceTokenFaker.CreateDto());
            resp2.IsSuccessStatusCode.ShouldBeTrue();
            res2.ShouldBeGreaterThan(0);
        }

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByOldDeviceToken_WithExistingOldDeviceToken()
    {
        var expected = NewControlData;
        var id = await SetupAsync(expected);

        expected.OldDeviceToken.ShouldNotBeNullOrWhiteSpace();
        var (resp2, res2) = await app.Client.GETAsync<GetByOldDeviceToken, GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto>(
            new()
            {
                OldDeviceToken = expected.OldDeviceToken
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.C4WDeviceTokenId.ShouldBeGreaterThan(0);
        res2.C4WDeviceTokenId.ShouldBe(id);
        res2.OldDeviceToken.ShouldBe(expected.OldDeviceToken);
        res2.NewDeviceToken.ShouldBe(expected.NewDeviceToken);
        res2.ClientEnvironment.ShouldBe(expected.ClientEnvironment);
        res2.Device.ShouldBe(expected.Device);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByOldDeviceToken_WithNonExistentOldDeviceToken()
    {
        var (resp, res) = await app.Client.GETAsync<GetByOldDeviceToken, GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto>(
            new()
            {
                OldDeviceToken = C4WDeviceTokenFaker.OldDeviceToken()
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(NewControlData);

        var req = UpdatedControlData;
        req.C4WDeviceTokenId = id;
        var resp2 = await app.Client.PUTAsync<Update, UpdateC4WDeviceTokenDto>(req);
        resp2.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = UpdatedControlData;
        req.C4WDeviceTokenId = C4WX1Faker.Id;
        var resp = await app.Client.PUTAsync<Update, UpdateC4WDeviceTokenDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
