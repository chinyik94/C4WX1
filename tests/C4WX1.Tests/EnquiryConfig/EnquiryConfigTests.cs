using C4WX1.API.Features.EnquiryConfig.Dtos;
using C4WX1.API.Features.EnquiryConfig.Endpoints;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.EnquiryConfig;

[Collection<C4WX1TestCollection>]
public class EnquiryConfigTests(C4WX1App app) : TestBase
{
    private CreateEnquiryConfigDto Control => new()
    {
        SCMID_FK = 1,
        EmailContent = "control-EmailContent",
        EscalatingPersonID_FK = 1,
        EscalationPeriod = 1,
        EscalationEmail = "control-EscalationEmail",
        EmailtoCMContent = "control-EmailtoCMContent",
        SCMList = [1, 2, 3],
        EscPersonList = [1, 2, 3]
    };

    private UpdateEnquiryConfigDto UpdateControl => new()
    {
        SCMID_FK = 2,
        EmailContent = "updated-control-EmailContent",
        EscalatingPersonID_FK = 2,
        EscalationPeriod = 2,
        EscalationEmail = "updated-control-EscalationEmail",
        EmailtoCMContent = "updated-control-EmailtoCMContent",
        SCMList = [4, 5, 6],
        EscPersonList = [4, 5, 6]
    };

    private async Task<int> SetupAsync(CreateEnquiryConfigDto testData)
    {
        var (resp, res) = await app.Client
            .POSTAsync<Create, CreateEnquiryConfigDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupUserAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Users.AddRangeAsync([
            EnquiryConfigFaker.DummyUser,
            EnquiryConfigFaker.DummyUser,
            EnquiryConfigFaker.DummyUser,
            EnquiryConfigFaker.DummyUser,
            EnquiryConfigFaker.DummyUser,
            EnquiryConfigFaker.DummyUser
            ]);
        await dbContext.SaveChangesAsync();
    }

    private async Task CleanupAsync()
    {
        await using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Users", "EnquiryConfig", "EnquirySCM", "EnquiryEscPerson" RESTART IDENTITY CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        await SetupUserAsync();

        var (resp, res) = await app.Client
            .POSTAsync<Create, CreateEnquiryConfigDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client
            .GETAsync<GetById, GetByIdDto, EnquiryConfigDto>(
            new()
            {
                Id = C4WX1Faker.Id(),
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var expected = Control;
        await SetupUserAsync();
        var id = await SetupAsync(expected);

        var (resp, res) = await app.Client
            .GETAsync<GetById, GetByIdDto, EnquiryConfigDto>(
            new()
            {
                Id = id,
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.EnquiryConfigID.ShouldBe(id);
        res.SCMID_FK.ShouldBe(expected.SCMID_FK);
        res.EmailContent.ShouldBe(expected.EmailContent);
        res.EscalatingPersonID_FK.ShouldBe(expected.EscalatingPersonID_FK);
        res.EscalationPeriod.ShouldBe(expected.EscalationPeriod);
        res.EscalationEmail.ShouldBe(expected.EscalationEmail);
        res.EmailtoCMContent.ShouldBe(expected.EmailtoCMContent);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var dummy = UpdateControl;
        dummy.Id = C4WX1Faker.Id();
        var resp = await app.Client
            .PUTAsync<Update, UpdateEnquiryConfigDto>(dummy);

        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupUserAsync();
        var id = await SetupAsync(Control);
        var expected = UpdateControl;
        expected.Id = id;

        var resp = await app.Client
            .PUTAsync<Update, UpdateEnquiryConfigDto>(expected);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }
}
