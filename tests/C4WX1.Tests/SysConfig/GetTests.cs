using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Get;
using FastEndpoints;
using FastEndpoints.Testing;
using Shouldly;
using System.Net;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(2)]
    public class GetTests(C4WX1App app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithExistingConfigName()
        {
            var (resp, result) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
                new()
                {
                    ConfigName = SysConfigDataHelper.ConfigName
                });

            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ConfigName.ShouldBe(SysConfigDataHelper.ConfigName);
            result.ConfigValue.ShouldBe(SysConfigDataHelper.ConfigValue);
            result.IsConfigurable.ShouldBe(SysConfigDataHelper.IsConfigurable);
            result.Description.ShouldBe(SysConfigDataHelper.Description);
        }

        [Fact, Priority(2)]
        public async Task WithNonExistentConfigName()
        {
            var (resp, result) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
                new()
                {
                    ConfigName = "NonExistentConfigName"
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            result.ShouldBeNull();
        }
    }
}
