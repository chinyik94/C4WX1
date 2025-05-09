using C4WX1.API.Features.Branch.Constants;
using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Branch;

[Collection<C4WX1TestCollection>]
public class BranchTests(C4WX1App app, C4WX1State state) : TestBase
{
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

    private async Task<int> SetupAsync(CreateBranchDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateBranchDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task<(int codeId, string codeName)> SetupCurrencyAsync()
    {
        using var dbContext = app.CreateDbContext();
        var dummyCode = BranchFaker.DummyCode;
        dummyCode.CodeTypeId_FKNavigation = BranchFaker.DummyCodeType;
        await dbContext.Code.AddAsync(dummyCode);
        await dbContext.SaveChangesAsync();

        return (dummyCode.CodeId, dummyCode.CodeName);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Users", "Branch", "CodeType", "Code" RESTART IDENTITY CASCADE;
            """);
    }

    private async Task UpdateForCanDeleteAsync(
        int id,
        bool isDeleted,
        bool isSystemUsed,
        string status)
    {
        using var dbContext = app.CreateDbContext();
        var entity = await dbContext.Branch
            .Where(x => x.BranchID == id)
            .FirstOrDefaultAsync();
        entity.ShouldNotBeNull();
        entity.IsDeleted = isDeleted;
        entity.IsSystemUsed = isSystemUsed;
        entity.Status = status;
        await dbContext.SaveChangesAsync();
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => BranchFaker.CreateDummy)
            .Select(SetupAsync);
        await Task.WhenAll(createTasks);
    }

    [Fact]
    public async Task Create()
    {
        await SetupUserAsync();

        var (resp, res) = await app.Client.POSTAsync<Create, CreateBranchDto, int>(
            BranchFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Create_WithSameBranchName()
    {
        await SetupUserAsync();

        var control = BranchFaker.CreateDto;
        var (resp, res) = await app.Client.POSTAsync<Create, CreateBranchDto, int>(
            control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        var (resp2, res2) = await app.Client.POSTAsync<Create, CreateBranchDto, int>(
            control);
        resp2.IsSuccessStatusCode.ShouldBeFalse();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WhenBranchIsAbleToDelete()
    {
        await SetupUserAsync();
        var id = await SetupAsync(BranchFaker.CreateDto);

        await UpdateForCanDeleteAsync(id, isDeleted: false, isSystemUsed: false, BranchFaker.DummyStatus);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WhenBranchIsNotAbleToDelete()
    {
        await SetupUserAsync();
        var id = await SetupAsync(BranchFaker.CreateDto);

        await UpdateForCanDeleteAsync(id, isDeleted: false, isSystemUsed: true, Statuses.Active);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await UpdateForCanDeleteAsync(id, isDeleted: false, isSystemUsed: true, Statuses.Locked);
        var resp2 = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp2.IsSuccessStatusCode.ShouldBeFalse();

        await UpdateForCanDeleteAsync(id, isDeleted: false, isSystemUsed: false, Statuses.Active);
        var resp3 = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp3.IsSuccessStatusCode.ShouldBeFalse();

        await UpdateForCanDeleteAsync(id, isDeleted: true, isSystemUsed: false, Statuses.Locked);
        var resp4 = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp4.IsSuccessStatusCode.ShouldBeFalse();

        await UpdateForCanDeleteAsync(id, isDeleted: true, isSystemUsed: true, Statuses.Active);
        var resp5 = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp5.IsSuccessStatusCode.ShouldBeFalse();

        await UpdateForCanDeleteAsync(id, isDeleted: true, isSystemUsed: true, Statuses.Locked);
        var resp6 = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = id,
                UserId = 1
            });
        resp6.IsSuccessStatusCode.ShouldBeFalse();

        var resp7 = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new DeleteByIdDto
            {
                Id = C4WX1Faker.Id,
                UserId = 1
            });
        resp7.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        var req = C4WX1Faker.DeleteDto();
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId_WithoutCurrencyID()
    {
        await SetupUserAsync();
        var id = await SetupAsync(BranchFaker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, BranchDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.BranchID.ShouldBe(id);
        res.BranchName.ShouldBe(BranchFaker.CreateDto.BranchName);
        res.Address1.ShouldBe(BranchFaker.CreateDto.Address1);
        res.Address2.ShouldBe(BranchFaker.CreateDto.Address2);
        res.Address3.ShouldBe(BranchFaker.CreateDto.Address3);
        res.Contact.ShouldBe(BranchFaker.CreateDto.Contact);
        res.Email.ShouldBe(BranchFaker.CreateDto.Email);
        res.Status.ShouldBe(BranchFaker.CreateDto.Status);
        res.CurrencyID_FK.ShouldBe(BranchFaker.CreateDto.CurrencyID_FK);
        res.CurrencyName.ShouldBeEmpty();
        res.UserDataList.Count.ShouldBe(BranchFaker.CreateDto.UserDataList.Count);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId_WithCurrencyID()
    {
        await SetupUserAsync();
        var (currencyId, currencyName) = await SetupCurrencyAsync();
        var control = BranchFaker.CreateDto;
        control.CurrencyID_FK = currencyId;
        var id = await SetupAsync(control);
        var req = C4WX1Faker.GetByIdDto(id);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, BranchDto>(req);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.BranchID.ShouldBe(id);
        res.BranchName.ShouldBe(control.BranchName);
        res.Address1.ShouldBe(control.Address1);
        res.Address2.ShouldBe(control.Address2);
        res.Address3.ShouldBe(control.Address3);
        res.Contact.ShouldBe(control.Contact);
        res.Email.ShouldBe(control.Email);
        res.Status.ShouldBe(control.Status);
        res.CurrencyID_FK.ShouldBe(control.CurrencyID_FK);
        res.CurrencyName.ShouldBe(currencyName);
        res.UserDataList.Count.ShouldBe(control.UserDataList.Count);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, BranchDto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetCount()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithDefaultSorting()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.BranchName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.BranchName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithAddressSorting()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Address} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Address1).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Address} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Address1).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithContactSorting()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Contact} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Contact).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Contact} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Contact).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithEmailSorting()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Email} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Email).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Email} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Email).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithStatusSorting()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Status} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Status).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Status} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Status).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithCurrencySorting()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Currency} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.CurrencyName).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<BranchDto>>(
            new()
            {
                OrderBy = $"{BranchSortColumns.Currency} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.CurrencyName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListForControl()
    {
        var expectedCount = state.CreateCount;
        await SetupDummiesAsync(expectedCount);

        var (resp, res) = await app.Client.GETAsync<GetListForControl, IEnumerable<BranchDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.IsSystemUsed).ShouldBeInOrder(SortDirection.Ascending);
        res.Select(x => x.BranchName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithoutUser()
    {
        var control = BranchFaker.CreateDto;
        control.UserDataList = [];
        var id = await SetupAsync(control);

        var resp = await app.Client.PUTAsync<Update, UpdateBranchDto>(
            new()
            {
                Id = id,
                BranchName = BranchFaker.DummyAlphaNumeric,
                Address1 = BranchFaker.DummyAddress,
                Address2 = BranchFaker.DummyAddress,
                Address3 = BranchFaker.DummyAddress,
                Contact = BranchFaker.DummyContact,
                Email = BranchFaker.DummyEmail,
                Status = Statuses.Active,
                UserId = C4WX1Faker.Id,
                UserDataList = []
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithUsers()
    {
        await SetupUserAsync();
        var id = await SetupAsync(BranchFaker.CreateDto);

        var resp = await app.Client.PUTAsync<Update, UpdateBranchDto>(
            new()
            {
                Id = id,
                BranchName = BranchFaker.DummyAlphaNumeric,
                Address1 = BranchFaker.DummyAddress,
                Address2 = BranchFaker.DummyAddress,
                Address3 = BranchFaker.DummyAddress,
                Contact = BranchFaker.DummyContact,
                Email = BranchFaker.DummyEmail,
                Status = Statuses.Active,
                UserId = C4WX1Faker.Id,
                UserDataList = [4, 5, 6]
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }
}
