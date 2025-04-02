using C4WX1.API.Features.SysConfig.Create;
using C4WX1.API.Features.SysConfig.Dtos;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(1)]
    public class CreateTests(SysConfigAppFixture app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithValidRequest()
        {
            var controlData = app.Control;
            var controlRequest = new CreateSysConfigDto
            {
                ConfigName = controlData.ConfigName,
                ConfigValue = controlData.ConfigValue,
                IsConfigurable = controlData.IsConfigurable,
                Description = controlData.Description
            };
            var controlResponse = await app.Client.POSTAsync<Create, CreateSysConfigDto>(controlRequest);
            controlResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);

            var randomRequests = Enumerable.Range(0, app.CreateCount)
                .Select(x => SysConfigFaker.CreateDto());
            foreach (var request in randomRequests)
            {
                var response = await app.Client.POSTAsync<Create, CreateSysConfigDto>(request);
                response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            }
        }
    }
}
