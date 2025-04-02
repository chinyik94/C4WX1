using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Get;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(4)]
    public class GetAllListTests(SysConfigAppFixture app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithValidRequest()
        {
            var (resp, result) = await app.Client.GETAsync<GetAllList, IEnumerable<SysConfigDto>>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(app.CreateCount + 1);
        }
    }
}
