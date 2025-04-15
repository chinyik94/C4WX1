using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Endpoints;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.APIAccessKey;

[Collection<C4WX1TestCollection>]
public class APIAccessKeyTests(C4WX1App app) : TestBase
{
    [Fact]
    public async Task GetByCode_WithExistingCode()
    {
        var (resp, res) = await app.Client.GETAsync<GetByCode, GetAPIAccessKeyByCodeDto, APIAccessKeyDto>(
            new()
            {
                Code = "APIToken",
                UserId = C4WX1Faker.UserId()
            });

        resp.StatusCode.ShouldBe(HttpStatusCode.OK);
        res.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetByCode_WithNonExistentCode()
    {
        var (resp, res) = await app.Client.GETAsync<GetByCode, GetAPIAccessKeyByCodeDto, APIAccessKeyDto>(
            APIAccessKeyFaker.GetByCodeDto());
        resp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GeyByAccessKey_WithInvalidAccessKey()
    {
        var (resp, res) = await app.Client.GETAsync<GetByAccessKey, GetAPIAccessKeyByAccessKeyDto, APIAccessKeyDto>(
            APIAccessKeyFaker.GetByAccessKeyDto());
        resp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        res.ShouldBeNull();
    }
}
