using C4WX1.API.Features.SysConfig.Get;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(3)]
    public class GetCountTests(SysConfigAppFixture app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithValidRequest()
        {
            var (resp, result) = await app.Client.GETAsync<GetCount, int>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldBeGreaterThan(0);
            result.ShouldBe(app.CreateCount + 1);
        }
    }
}
