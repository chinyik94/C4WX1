using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Get;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(2)]
    public class GetTests(SysConfigAppFixture app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithExistingConfigName()
        {
            var expected = app.Control;
            var (resp, result) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
                new()
                {
                    ConfigName = expected.ConfigName
                });

            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ConfigName.ShouldBe(expected.ConfigName);
            result.ConfigValue.ShouldBe(expected.ConfigValue);
            result.IsConfigurable.ShouldBe(expected.IsConfigurable);
            result.Description.ShouldBe(expected.Description);
        }

        [Fact, Priority(2)]
        public async Task WithNonExistentConfigName()
        {
            var (resp, result) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
                new()
                {
                    ConfigName = SysConfigFaker.ConfigName()
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            result.ShouldBeNull();
        }
    }
}
