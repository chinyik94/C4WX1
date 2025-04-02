using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Update;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(6)]
    public class UpdateTests(SysConfigAppFixture app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithNonExistentConfigNames()
        {
            var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>> (
                [
                    SysConfigFaker.UpdateDto(),
                    SysConfigFaker.UpdateDto(),
                ]);

            resp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact, Priority(2)]
        public async Task WithExitingConfigNames()
        {
            var controlData = app.Control.ConfigName;
            var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
                [
                    new() {
                        ConfigName = controlData,
                        ConfigValue = SysConfigFaker.ConfigValue(),
                        UserID = SysConfigFaker.UserId()
                    },
                    new() {
                        ConfigName = controlData,
                        ConfigValue = SysConfigFaker.ConfigValue(),
                        UserID = SysConfigFaker.UserId()
                    },
                ]);

            resp.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}
