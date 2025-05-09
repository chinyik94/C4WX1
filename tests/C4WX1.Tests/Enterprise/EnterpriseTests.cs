using C4WX1.API.Features.Enterprise.Dtos;
using C4WX1.API.Features.Enterprise.Endpoints;

namespace C4WX1.Tests.Enterprise;

[Collection<C4WX1TestCollection>]
public class EnterpriseTests(C4WX1App app) : TestBase
{
    //Temprorily remove test as SysConfig data is encrypted differently
    //[Fact]
    public async Task Get()
    {
        var (resp, res) = await app.Client.GETAsync<Get, EnterpriseDto>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
    }
}
