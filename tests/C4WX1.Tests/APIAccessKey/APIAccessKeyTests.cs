using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Get;

namespace C4WX1.Tests.APIAccessKey
{
    public class APIAccessKeyTests(APIAccessKeyApp app) 
        : TestBase<APIAccessKeyApp>
    {
        [Fact, Priority(1)]
        public async Task Get_APIAccessKey_ByCode()
        {
            var (resp1, res1) = await app.Client.GETAsync<GetByCode, GetAPIAccessKeyByCodeDto, APIAccessKeyDto>(
                new()
                {
                    Code = "APIToken",
                    UserId = APIAccessKeyFaker.UserId()
                });

            resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
            res1.ShouldNotBeNull();

            var (resp2, res2) = await app.Client.GETAsync<GetByCode, GetAPIAccessKeyByCodeDto, APIAccessKeyDto>(
                APIAccessKeyFaker.GetByCodeDto());
            resp2.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res2.ShouldBeNull();
        }

        [Fact, Priority(2)]
        public async Task Get_APIAccessKey_ByAccessKey()
        {
            var (resp1, res1) = await app.Client.GETAsync<GetByAccessKey, GetAPIAccessKeyByAccessKeyDto, APIAccessKeyDto>(
                APIAccessKeyFaker.GetByAccessKeyDto());
            resp1.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res1.ShouldBeNull();
        }
    }
}
