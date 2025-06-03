using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.WoundConsolidatedEmail.Dtos;
using C4WX1.API.WoundConsolidatedEmail.Endpoints;

namespace C4WX1.Tests.WoundConsolidatedEmail;

[Collection<C4WX1TestCollection>]
public class WoundConsolidatedEmailTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private const string SkipReason = "MailSettings PK ID is not auto incremental";

    private async Task SetupDependenciesAsync(int mailSettingsId)
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.PatientWoundVisit.AddAsync(new Database.Models.PatientWoundVisit
        {
            PatientWoundID_FKNavigation = new Database.Models.PatientWound
            {
                Site = "test-Site"
            },
            WoundType = "test-WoundType"
        }, Cancellation);
        await dbContext.MailSettings.AddAsync(new Database.Models.MailSettings
        {
            id = mailSettingsId,
            description = "test-description"
        }, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    private async Task<int> SetupAsync(CreateWoundConsolidatedEmailDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateWoundConsolidatedEmailDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(WoundConsolidatedEmailFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "MailSettings", "PatientWoundVisit", "WoundConsolidatedEmail" RESTART IDENTITY CASCADE;
            """);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    [Fact(Skip = SkipReason)]
    public async Task Create()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var (resp, res) = await app.Client.POSTAsync<Create, CreateWoundConsolidatedEmailDto, int>(
            WoundConsolidatedEmailFaker.CreateDto(mailSettingsId));
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact(Skip = SkipReason)]
    public async Task Update_WithExistingId()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var id = await SetupAsync(WoundConsolidatedEmailFaker.CreateDto(mailSettingsId));
        var req = WoundConsolidatedEmailFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateWoundConsolidatedEmailDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact(Skip = SkipReason)]
    public async Task Update_WithNonExistentId()
    {
        int mailSettingsId = C4WX1Faker.Id;
        var req = WoundConsolidatedEmailFaker.UpdateDto(mailSettingsId);
        var resp = await app.Client.PUTAsync<Update, UpdateWoundConsolidatedEmailDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact(Skip = SkipReason)]
    public async Task Delete_WithExistingId()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var id = await SetupAsync(WoundConsolidatedEmailFaker.CreateDto(mailSettingsId));
        var resp = await app.Client.PUTAsync<Delete, DeleteWoundConsolidatedEmailDto>(
            new()
            {
                Id = id,
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact(Skip = SkipReason)]
    public async Task Delete_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Delete, DeleteWoundConsolidatedEmailDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact(Skip = SkipReason)]
    public async Task GetById_WithExistingId()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var createDto = WoundConsolidatedEmailFaker.CreateDto(mailSettingsId);
        var id = await SetupAsync(createDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.PUTAsync<GetById, GetByIdDto, WoundConsolidatedEmailDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.WoundConsolidatedEmailID.ShouldBe(id);
        res.PatientWoundVisitID_FK.ShouldBe(createDto.PatientWoundVisitID_FK);
        res.MailSettingsID_FK.ShouldBe(mailSettingsId);
        res.PDFContent.ShouldBe(createDto.PDFContent);
        res.CreatedBy_FK.ShouldBe(createDto.UserId);
        await CleanupAsync();
    }

    [Fact(Skip = SkipReason)]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.PUTAsync<GetById, GetByIdDto, WoundConsolidatedEmailDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact(Skip = SkipReason)]
    public async Task GetAllList()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetAllList, IEnumerable<WoundConsolidatedEmailDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);
        await CleanupAsync();
    }

    [Fact(Skip = SkipReason)]
    public async Task GetAllListByEmailType()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetAllList, GetAllWoundConsolidatedEmailByEmailTypeDto, IEnumerable<WoundConsolidatedEmailDto>>(
            new()
            {
                Id = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetAllList, GetAllWoundConsolidatedEmailByEmailTypeDto, IEnumerable<WoundConsolidatedEmailDto>>(
            new()
            {
                Id = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact(Skip = SkipReason)]
    public async Task GetExistingList()
    {
        int mailSettingsId = C4WX1Faker.Id;
        await SetupDependenciesAsync(mailSettingsId);
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetExistingList, GetExistingWoundConsolidatedEmailListDto, IEnumerable<WoundConsolidatedEmailDto>>(
            new()
            {
                WoundVisitId = 1,
                MailSettingsId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetExistingList, GetExistingWoundConsolidatedEmailListDto, IEnumerable<WoundConsolidatedEmailDto>>(
            new()
            {
                WoundVisitId = C4WX1Faker.Id,
                MailSettingsId = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        var (resp3, res3) = await app.Client.GETAsync<GetExistingList, GetExistingWoundConsolidatedEmailListDto, IEnumerable<WoundConsolidatedEmailDto>>(
            new()
            {
                WoundVisitId = 1,
                MailSettingsId = C4WX1Faker.Id
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(0);

        var (resp4, res4) = await app.Client.GETAsync<GetExistingList, GetExistingWoundConsolidatedEmailListDto, IEnumerable<WoundConsolidatedEmailDto>>(
            new()
            {
                WoundVisitId = C4WX1Faker.Id,
                MailSettingsId = 1
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(0);

        await CleanupAsync();
    }
}
