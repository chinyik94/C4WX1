using C4WX1.API.Features.ErrorLog.Dtos;
using C4WX1.API.Features.ErrorLog.Endpoints;

namespace C4WX1.Tests.ErrorLog;

[Collection<C4WX1TestCollection>]
public class ErrorLogTests(C4WX1App app) : TestBase
{
    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateErrorLogDto, int>(
            new()
            {
                ErrorDetails = "ErrorDetails"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "ErrorLog" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }
}
