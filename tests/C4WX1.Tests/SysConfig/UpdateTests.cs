using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Update;
using FastEndpoints;
using FastEndpoints.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(6)]
    public class UpdateTests(C4WX1App app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithNonExistentConfigNames()
        {
            var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>> (
                [
                    new() {
                        ConfigName = "non existent config 1",
                        ConfigValue = "Value1",
                        UserID = SysConfigDataHelper.UserID
                    },
                    new() {
                        ConfigName = "non existent config 2",
                        ConfigValue = "Value2",
                        UserID = SysConfigDataHelper.UserID
                    },
                ]);

            resp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact, Priority(2)]
        public async Task WithExitingConfigNames()
        {
            var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
                [
                    new() {
                        ConfigName = SysConfigDataHelper.ConfigName,
                        ConfigValue = "New Test Value",
                        UserID = SysConfigDataHelper.UserID
                    },
                    new() {
                        ConfigName = "SiteName",
                        ConfigValue = "new value",
                        UserID = SysConfigDataHelper.UserID
                    },
                ]);

            resp.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}
