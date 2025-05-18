using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;
using C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.MultiDisciplinaryMeeting;

[Collection<C4WX1TestCollection>]
public class MultiDisciplinaryMeetingTests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Patient.AddAsync(new Database.Models.Patient
        {
            Firstname = "control-Firstname",
            Lastname = "control-Lastname",
            NRIC = "control-NRIC"
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task<int> SetupAsync(CreateMultiDisciplinaryMeetingDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateMultiDisciplinaryMeetingDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(MultiDisciplinaryMeetingFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Patient", "MultiDisciplinaryMeeting" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken); 
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateMultiDisciplinaryMeetingDto, int>(
            MultiDisciplinaryMeetingFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MultiDisciplinaryMeetingFaker.CreateDto);
        var req = MultiDisciplinaryMeetingFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateMultiDisciplinaryMeetingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = MultiDisciplinaryMeetingFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateMultiDisciplinaryMeetingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MultiDisciplinaryMeetingFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, MultiDisciplinaryMeetingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.MultiDisciplinaryMeetingID.ShouldBe(id);
        res.IssuesOverall.ShouldBe(MultiDisciplinaryMeetingFaker.CreateDto.IssuesOverall);
        res.AssignedToFollowUp.ShouldBe(MultiDisciplinaryMeetingFaker.CreateDto.AssignedToFollowUp);
        res.Remarks.ShouldBe(MultiDisciplinaryMeetingFaker.CreateDto.Remarks);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, MultiDisciplinaryMeetingDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetCount, GetMultiDisciplinaryMeetingCountDto, int>(
            new()
            {
                PatientID = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetMultiDisciplinaryMeetingCountDto, int>(
            new()
            {
                PatientID = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetAllList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetAllList, GetAllMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>>(
            new()
            {
                PatientID = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetAllList, GetAllMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>>(
            new()
            {
                PatientID = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>>(
            new()
            {
                PatientID = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>>(
            new()
            {
                PatientID = C4WX1Faker.Id
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>>(
            new()
            {
                PatientID = 1,
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>>(
            new()
            {
                PatientID = 1,
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);

        await CleanupAsync();
    }
}
