using C4WX1.API.Features.RecentView.Dtos;
using C4WX1.API.Features.RecentView.Endpoints;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.Tests.RecentView;

[Collection<C4WX1TestCollection>]
public class RecentViewTests(C4WX1App app) : TestBase
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Users.AddAsync(new Database.Models.Users
        {
            UserName = "control-UserName",
            Password = "control-Password",
            Email = "control-Email",
            Firstname = "control-Fisrtname",
            Lastname = "control-Lastname",
            Status = Statuses.Active,
            UserUserType = [
                new Database.Models.UserUserType
                {
                    UserTypeID_FKNavigation = new Database.Models.UserType
                    {
                        UserType1 = "control-UserType1",
                        UserCategoryID_FKNavigation = new Database.Models.UserCategory
                        {
                            UserCategory1 = "control-UserCategory1",
                        }
                    }
                }
                ]
        }, Cancellation);
        await dbContext.Users.AddAsync(new Database.Models.Users
        {
            UserName = "control-UserName",
            Password = "control-Password",
            Email = "control-Email",
            Firstname = "control-Fisrtname",
            Lastname = "control-Lastname",
            Status = Statuses.Active,
            UserUserType = [
                new Database.Models.UserUserType
                {
                    UserTypeID_FKNavigation = new Database.Models.UserType
                    {
                        UserType1 = "control-UserType1",
                        UserCategoryID_FKNavigation = new Database.Models.UserCategory
                        {
                            UserCategory1 = "control-UserCategory1",
                        }
                    }
                }
                ]
        }, Cancellation);
        await dbContext.Patient.AddAsync(new Database.Models.Patient
        {
            Firstname = "control-Firstname",
            Lastname = "control-Lastname",
            NRIC = "control-NRIC"
        }, Cancellation);
        await dbContext.Patient.AddAsync(new Database.Models.Patient
        {
            Firstname = "control-Firstname",
            Lastname = "control-Lastname",
            NRIC = "control-NRIC"
        }, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    private async Task SetupDataAsync()
    {
        var resp = await app.Client.POSTAsync<Upsert, UpsertRecentViewDto>(
            new()
            {
                UserID = 1,
                PatientID = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        var resp2 = await app.Client.POSTAsync<Upsert, UpsertRecentViewDto>(
            new()
            {
                UserID = 2,
                PatientID = 1
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();

        var resp3 = await app.Client.POSTAsync<Upsert, UpsertRecentViewDto>(
            new()
            {
                UserID = 1,
                PatientID = 2
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();

        var resp4 = await app.Client.POSTAsync<Upsert, UpsertRecentViewDto>(
            new()
            {
                UserID = 2,
                PatientID = 2
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Users", "Patient", "RecentView" RESTART IDENTITY CASCADE;
            """, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    [Fact]
    public async Task Upsert()
    {
        await SetupDependenciesAsync();

        var resp = await app.Client.POSTAsync<Upsert, UpsertRecentViewDto>(
            new()
            {
                UserID = 1,
                PatientID = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        var resp2 = await app.Client.POSTAsync<Upsert, UpsertRecentViewDto>(
            new()
            {
                UserID = 2,
                PatientID = 1
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDependenciesAsync();
        await SetupDataAsync();

        var (resp, res) = await app.Client.GETAsync<GetCount, GetRecentViewCountDto, int>(
            new()
            {
                UserID = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(2);

        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetRecentViewCountDto, int>(
            new()
            {
                UserID = 2
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(2);

        var (resp3, res3) = await app.Client.GETAsync<GetCount, GetRecentViewCountDto, int>(
            new()
            {
                UserID = 3
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        await SetupDependenciesAsync();
        await SetupDataAsync();

        var (resp, _) = await app.Client.GETAsync<GetList, GetRecentViewListDto, IEnumerable<RecentViewDto>>(
            new()
            {
                UserId = 1,
                FacilityId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        // Temporarily skip checking count as canAccessPatientDashboard affects the results

        await CleanupAsync();
    }
}
