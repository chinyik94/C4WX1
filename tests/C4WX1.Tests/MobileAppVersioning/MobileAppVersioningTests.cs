using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.MobileAppVersioning.Endpoints;
using C4WX1.API.Features.MobileAppVersioning.Enums;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.SysConfig.Constants;
using SortColumns = C4WX1.API.Features.MobileAppVersioning.Constants.SortColumns;

namespace C4WX1.Tests.MobileAppVersioning;

[Collection<C4WX1TestCollection>]
public class MobileAppVersioningTests(C4WX1App app, C4WX1State state) :TestBase
{
    private async Task<int> SetupAsync(CreateMobileAppVersioningDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateMobileAppVersioningDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Users.AddAsync(new Database.Models.Users
        {
            UserName = "control-UserName",
            Password = "control-Password",
            Email = "control-Email",
            Firstname = "control-Firstname",
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
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(MobileAppVersioningFaker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task SetupVersionStatus(int id, string status, bool enableSysConfig = true)
    {
        using var dbContext = app.CreateDbContext();
        var sysConfig = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.EnableMobileAppVersionChecking)
            .FirstAsync(TestContext.Current.CancellationToken);
        sysConfig.ConfigValue = enableSysConfig.ToString();
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);

        var resp = await app.Client.PUTAsync<UpdateStatus, UpdateMobileAppVersioningStatusDto>(
            MobileAppVersioningFaker.UpdateStatusDto(id, status));
        resp.IsSuccessStatusCode.ShouldBeTrue();
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "MobileAppVersioning" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateMobileAppVersioningDto, int>(
            MobileAppVersioningFaker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        var (resp2, res2) = await app.Client.POSTAsync<Create, CreateMobileAppVersioningDto, int>(
            MobileAppVersioningFaker.CreateDto);
        resp2.IsSuccessStatusCode.ShouldBeFalse();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        var resp = await app.Client.PUTAsync<Update, UpdateMobileAppVersioningDto>(
            MobileAppVersioningFaker.UpdateDto(id));
        resp.IsSuccessStatusCode.ShouldBeTrue();

        var resp2 = await app.Client.PUTAsync<Update, UpdateMobileAppVersioningDto>(
            MobileAppVersioningFaker.UpdateDto(id));
        resp2.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateMobileAppVersioningDto>(
            MobileAppVersioningFaker.UpdateDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            C4WX1Faker.DeleteDto(id));
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            C4WX1Faker.DeleteDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task UpdateStatus_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        var resp = await app.Client.PUTAsync<UpdateStatus, UpdateMobileAppVersioningStatusDto>(
            MobileAppVersioningFaker.UpdateStatusDto(id));
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateStatus_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<UpdateStatus, UpdateMobileAppVersioningStatusDto>(
            MobileAppVersioningFaker.UpdateStatusDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
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
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, MobileAppVersioningDto>(
            C4WX1Faker.GetByIdDto(id));
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.AppName.ShouldBe(MobileAppVersioningFaker.CreateDto.AppName);
        res.DeviceType.ShouldBe(MobileAppVersioningFaker.CreateDto.DeviceType);
        res.Version.ShouldBe(MobileAppVersioningFaker.CreateDto.Version);
        res.CreatedBy_FK.ShouldBe(MobileAppVersioningFaker.CreateDto.UserId);
        res.CreatedBy.ShouldNotBeNull();
        res.CreatedBy.UserId.ShouldBe(MobileAppVersioningFaker.CreateDto.UserId);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, MobileAppVersioningDto>(
            C4WX1Faker.GetByIdDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetIsAbleLogin_WithSysConfigDisabled()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        await SetupVersionStatus(id, Statuses.Active, false);
        var (resp, res) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = MobileAppVersioningFaker.CreateDto.AppName!,
                DeviceType = MobileAppVersioningFaker.CreateDto.DeviceType!,
                Version = MobileAppVersioningFaker.CreateDto.Version!
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe((int)IsAbleLogin.YesButSysConfigDisabled);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetIsAbleLogin_WithSysConfigEnabled_AndActiveVersion()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        await SetupVersionStatus(id, Statuses.Active);
        var (resp, res) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = MobileAppVersioningFaker.CreateDto.AppName!,
                DeviceType = MobileAppVersioningFaker.CreateDto.DeviceType!,
                Version = MobileAppVersioningFaker.CreateDto.Version!
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe((int)IsAbleLogin.YesVersionActive);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetIsAbleLogin_WithSysConfigEnabled_AndPendingVersion()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        await SetupVersionStatus(id, Statuses.Pending);
        var (resp, res) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = MobileAppVersioningFaker.CreateDto.AppName!,
                DeviceType = MobileAppVersioningFaker.CreateDto.DeviceType!,
                Version = MobileAppVersioningFaker.CreateDto.Version!
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe((int)IsAbleLogin.NoVersionPending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetIsAbleLogin_WithSysConfigEnabled_AndForcedUpdateVersion()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        await SetupVersionStatus(id, Statuses.ForcedUpdate);
        var (resp, res) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = MobileAppVersioningFaker.CreateDto.AppName!,
                DeviceType = MobileAppVersioningFaker.CreateDto.DeviceType!,
                Version = MobileAppVersioningFaker.CreateDto.Version!
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe((int)IsAbleLogin.NoVersionForcedUpdate);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetIsAbleLogin_WithSysConfigEnabled_AndVersionNotFound()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(MobileAppVersioningFaker.CreateDto);
        await SetupVersionStatus(id, C4WX1Faker.ShortString);

        var (resp, res) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = C4WX1Faker.ShortString,
                DeviceType = MobileAppVersioningFaker.CreateDto.DeviceType!,
                Version = MobileAppVersioningFaker.CreateDto.Version!
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe((int)IsAbleLogin.NoVersionNotFound);

        var (resp2, res2) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = MobileAppVersioningFaker.CreateDto.AppName!,
                DeviceType = C4WX1Faker.ShortString,
                Version = MobileAppVersioningFaker.CreateDto.Version!
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe((int)IsAbleLogin.NoVersionNotFound);

        var (resp3, res3) = await app.Client.GETAsync<GetIsAbleLogin, GetIsMobileAppVersioningAbleLoginDto, int>(
            new()
            {
                AppName = MobileAppVersioningFaker.CreateDto.AppName!,
                DeviceType = MobileAppVersioningFaker.CreateDto.DeviceType!,
                Version = C4WX1Faker.ShortString
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldBe((int)IsAbleLogin.NoVersionNotFound);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ModifiedBy_FK).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ModifiedBy_FK).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.ModifiedBy_FK).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ModifiedBy_FK).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ModifiedBy_FK).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Status} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.Status).ShouldBeInOrder();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Status} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.Status).ShouldBeInOrder(SortDirection.Descending);

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Version} {SortDirections.Asc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.Version).ShouldBeInOrder();

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Version} {SortDirections.Desc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.Version).ShouldBeInOrder(SortDirection.Descending);

        var (resp7, res7) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.CreatedDate} {SortDirections.Asc}"
            });
        resp7.IsSuccessStatusCode.ShouldBeTrue();
        res7.Count().ShouldBe(expectedCount);
        res7.Select(x => x.CreatedDate).ShouldBeInOrder();

        var (resp8, res8) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.CreatedDate} {SortDirections.Desc}"
            });
        resp8.IsSuccessStatusCode.ShouldBeTrue();
        res8.Count().ShouldBe(expectedCount);
        res8.Select(x => x.CreatedDate).ShouldBeInOrder(SortDirection.Descending);

        var (resp9, res9) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.UpdatedBy} {SortDirections.Asc}"
            });
        resp9.IsSuccessStatusCode.ShouldBeTrue();
        res9.Count().ShouldBe(expectedCount);
        res9.Select(x => x.ModifiedBy_FK).ShouldBeInOrder();

        var (resp10, res10) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<MobileAppVersioningDto>>(
            new()
            {
                OrderBy = $"{SortColumns.UpdatedBy} {SortDirections.Desc}"
            });
        resp10.IsSuccessStatusCode.ShouldBeTrue();
        res10.Count().ShouldBe(expectedCount);
        res10.Select(x => x.ModifiedBy_FK).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetStatusList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetStatusList, IEnumerable<MobileAppVersioningStatusDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);
        await CleanupAsync();
    }
}
