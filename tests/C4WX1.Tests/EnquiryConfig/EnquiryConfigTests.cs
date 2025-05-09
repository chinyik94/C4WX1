using C4WX1.API.Features.EnquiryConfig.Dtos;
using C4WX1.API.Features.EnquiryConfig.Endpoints;
using C4WX1.API.Features.Shared.Dtos;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.EnquiryConfig;

[Collection<C4WX1TestCollection>]
public class EnquiryConfigTests(C4WX1App app) : TestBase
{
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
            C4WX1Faker.DummyUser,
            C4WX1Faker.DummyUser,
            C4WX1Faker.DummyUser,
            C4WX1Faker.DummyUser,
            C4WX1Faker.DummyUser,
            C4WX1Faker.DummyUser
            ]);
        await dbContext.SaveChangesAsync();
    }

    private async Task CleanupAsync()
    {
        await using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Users", "EnquiryConfig" RESTART IDENTITY CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        await SetupUserAsync();

        var (resp, res) = await app.Client
            .POSTAsync<Create, CreateEnquiryConfigDto, int>(EnquiryConfigFaker.CreateDto);
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
                Id = C4WX1Faker.Id,
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var expected = EnquiryConfigFaker.CreateDto;
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
        var dummy = EnquiryConfigFaker.UpdateDto();
        var resp = await app.Client
            .PUTAsync<Update, UpdateEnquiryConfigDto>(dummy);

        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupUserAsync();
        var id = await SetupAsync(EnquiryConfigFaker.CreateDto);
        var expected = EnquiryConfigFaker.UpdateDto(id);

        var resp = await app.Client
            .PUTAsync<Update, UpdateEnquiryConfigDto>(expected);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }
}
