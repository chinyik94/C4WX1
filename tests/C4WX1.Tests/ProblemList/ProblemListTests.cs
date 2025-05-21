using C4WX1.API.Features.ProblemList.Constants;
using C4WX1.API.Features.ProblemList.Dtos;
using C4WX1.API.Features.ProblemList.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.ProblemList;

[Collection<C4WX1TestCollection>]
public class ProblemListTests(C4WX1App app, C4WX1State state) : TestBase 
{
    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.DiseaseSubInfo.AddAsync(new Database.Models.DiseaseSubInfo
        {
            DiseaseSubInfo1 = "control-DiseaseSubInfo1",
            DiseaseID_FKNavigation = new Database.Models.Disease
            {
                DiseaseName = "control-DiseaseName",
                SystemID_FKNavigation = new Database.Models.SystemForDisease
                {
                    System = "control-System",
                }
            }
        }, Cancellation);
        await dbContext.Code.AddAsync(new Database.Models.Code
        {
            CodeTypeId_FKNavigation = new Database.Models.CodeType
            {
                CodeTypeName = "control-CodeTypeName"
            },
            CodeName = "control-CodeName",
        }, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    private async Task<int> SetupAsync(CreateProblemListDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateProblemListDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(ProblemListFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "DiseaseSubInfo", "Code", "ProblemList" RESTART IDENTITY CASCADE; 
            """, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateProblemListDto, int>(
            ProblemListFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ProblemListFaker.CreateDto);
        var req = ProblemListFaker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateProblemListDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        await SetupDependenciesAsync();
        var req = ProblemListFaker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateProblemListDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ProblemListFaker.CreateDto);
        var req = C4WX1Faker.DeleteDto(id);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        await SetupDependenciesAsync();
        var req = C4WX1Faker.DeleteDto();
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(ProblemListFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ProblemListDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ProblemListID.ShouldBe(id);
        res.DiseaseID_FK.ShouldBe(ProblemListFaker.CreateDto.DiseaseID_FK);
        res.DiseaseSubInfoID_FK.ShouldBe(ProblemListFaker.CreateDto.DiseaseSubInfoID_FK);
        res.ProblemInfo.ShouldBe(ProblemListFaker.CreateDto.ProblemInfo);
        res.DiseaseName.ShouldBe("control-DiseaseName");
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        await SetupDependenciesAsync();
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ProblemListDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetAllList()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetAllList, IEnumerable<ProblemListDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ProblemInfo).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ProblemInfo).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.ProblemInfo).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ProblemInfo).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ProblemInfo).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {
                OrderBy = $"{SortColumns.DiseaseName} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.DiseaseName).ShouldBeInOrder();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<ProblemListDto>>(
            new()
            {
                OrderBy = $"{SortColumns.DiseaseName} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.DiseaseName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }
}
