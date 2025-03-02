using C4WX1.API.Features.SysConfig.Create;
using C4WX1.API.Features.SysConfig.Dtos;
using FastEndpoints;
using FastEndpoints.Testing;
using Shouldly;
using System.Net;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(1)]
    public class CreateTests(C4WX1App app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithValidRequest()
        {
            var resp = await app.Client.POSTAsync<Create, CreateSysConfigDto>(
                new()
                {
                    ConfigName = SysConfigDataHelper.ConfigName,
                    ConfigValue = SysConfigDataHelper.ConfigValue,
                    IsConfigurable = SysConfigDataHelper.IsConfigurable,
                    Description = SysConfigDataHelper.Description
                });

            resp.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}
