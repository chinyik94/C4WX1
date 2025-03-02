using C4WX1.API.Features.SysConfig.Get;
using C4WX1.Database.Models;
using FastEndpoints;
using FastEndpoints.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Net;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(3)]
    public class GetCountTests(C4WX1App app) : TestBase
    {
        private readonly THCC_C4WDEVContext dbContext = app.Services.GetRequiredService<THCC_C4WDEVContext>();

        [Fact, Priority(1)]
        public async Task WithValidRequest()
        {
            var (resp, result) = await app.Client.GETAsync<GetCount, int>();
            var expected = await dbContext.SysConfig
                .CountAsync(Cancellation);

            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldBeGreaterThan(0);
            result.ShouldBeEquivalentTo(expected);
        }
    }
}
