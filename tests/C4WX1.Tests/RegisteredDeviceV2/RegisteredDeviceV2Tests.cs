using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.RegisteredDeviceV2.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.SysConfig.Constants;
using SortColumns = C4WX1.API.Features.RegisteredDeviceV2.Constants.SortColumns;

namespace C4WX1.Tests.RegisteredDeviceV2;

[Collection<C4WX1TestCollection>]
public class RegisteredDeviceV2Tests(C4WX1App app, C4WX1State state) : TestBase
{
    private async Task<int> SetupAsync(CreateRegisteredDeviceV2Dto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateRegisteredDeviceV2Dto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task SetupEnableQuotaAsync(bool value)
    {
        using var dbContext = app.CreateDbContext();
        var sysConfig = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.EnableRegisteredDeviceV2_Quota)
            .FirstAsync(Cancellation);
        sysConfig.ConfigValue = value.ToString();
        await dbContext.SaveChangesAsync(Cancellation);
    }

    private async Task SetupDummiesAsync(int createCount)
    {
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => SetupAsync(RegisteredDeviceV2Faker.CreateDummy));
        await Task.WhenAll(createTasks);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "RegisteredDeviceV2" RESTART IDENTITY CASCADE;
            """, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateRegisteredDeviceV2Dto, int>(
            RegisteredDeviceV2Faker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Create_WhenDeviceIdExists()
    {
        await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var (resp, res) = await app.Client.POSTAsync<Create, CreateRegisteredDeviceV2Dto, int>(
            RegisteredDeviceV2Faker.CreateDto);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBe(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        var id = await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var req = RegisteredDeviceV2Faker.UpdateDto(id);
        var resp = await app.Client.PUTAsync<Update, UpdateRegisteredDeviceV2Dto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var req = RegisteredDeviceV2Faker.UpdateDto();
        var resp = await app.Client.PUTAsync<Update, UpdateRegisteredDeviceV2Dto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        var id = await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var req = C4WX1Faker.DeleteDto(id);
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
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
    public async Task Approve_WithExistingId()
    {
        var id = await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var resp = await app.Client.POSTAsync<Approve, ApproveRegisteredDeviceV2Dto>(
            new()
            {
                Id = id,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Approve_WithNonExistentId()
    {
        var resp = await app.Client.POSTAsync<Approve, ApproveRegisteredDeviceV2Dto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateAppNameAndVersion_WithExistingDeviceId()
    {
        await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var resp = await app.Client.PUTAsync<UpdateAppNameAndVersion, UpdateRegisteredDeviceV2AppNameAndVersionDto>(
            new()
            {
                AppName = "updated-control-appName",
                DeviceId = RegisteredDeviceV2Faker.CreateDto.DeviceId!,
                UserId = 1,
                Version = "updated-control-version"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateAppNameAndVersion_WithNonExistentDeviceId()
    {
        await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var resp = await app.Client.PUTAsync<UpdateAppNameAndVersion, UpdateRegisteredDeviceV2AppNameAndVersionDto>(
            new()
            {
                AppName = "updated-control-appName",
                DeviceId = C4WX1Faker.ShortString,
                UserId = 1,
                Version = "updated-control-version"
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var id = await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, RegisteredDeviceV2Dto>(req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.RegisteredDeviceID.ShouldBe(id);
        res.DeviceId.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceId);
        res.DeviceName.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceName);
        res.DeviceType.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceType);
        res.DeviceToken.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceToken);
        res.AppName.ShouldBe(RegisteredDeviceV2Faker.CreateDto.AppName);
        res.Version.ShouldBe(RegisteredDeviceV2Faker.CreateDto.Version);
        res.Remarks.ShouldBe(RegisteredDeviceV2Faker.CreateDto.Remarks);
        res.CreatedBy_FK.ShouldBe(RegisteredDeviceV2Faker.CreateDto.UserId);
        res.FirstRegisterIpAddress.ShouldBe(RegisteredDeviceV2Faker.CreateDto.FirstRegisterIpAddress);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, RegisteredDeviceV2Dto>(req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetByDeviceId_WithExistingDeviceId()
    {
        var id = await SetupAsync(RegisteredDeviceV2Faker.CreateDto);
        var (resp, res) = await app.Client.GETAsync<GetByDeviceId, GetRegisteredDeviceV2ByDeviceIdDto, RegisteredDeviceV2Dto>(
            new()
            {
                DeviceId = RegisteredDeviceV2Faker.CreateDto.DeviceId!
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.RegisteredDeviceID.ShouldBe(id);
        res.DeviceId.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceId);
        res.DeviceName.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceName);
        res.DeviceType.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceType);
        res.DeviceToken.ShouldBe(RegisteredDeviceV2Faker.CreateDto.DeviceToken);
        res.AppName.ShouldBe(RegisteredDeviceV2Faker.CreateDto.AppName);
        res.Version.ShouldBe(RegisteredDeviceV2Faker.CreateDto.Version);
        res.Remarks.ShouldBe(RegisteredDeviceV2Faker.CreateDto.Remarks);
        res.CreatedBy_FK.ShouldBe(RegisteredDeviceV2Faker.CreateDto.UserId);
        res.FirstRegisterIpAddress.ShouldBe(RegisteredDeviceV2Faker.CreateDto.FirstRegisterIpAddress);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetByDeviceId_WithNonExistentDeviceId()
    {
        var (resp, res) = await app.Client.GETAsync<GetByDeviceId, GetRegisteredDeviceV2ByDeviceIdDto, RegisteredDeviceV2Dto>(
            new()
            {
                DeviceId = C4WX1Faker.ShortString
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetDeviceQuota_WhenSysConfigDisabled()
    {
        await SetupEnableQuotaAsync(false);
        var resp = await app.Client.GETAsync<GetDeviceQuota, DeviceCountDto>();
        resp.Response.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task GetDeviceQuota_WhenSysConfigEnabled()
    {
        await SetupEnableQuotaAsync(true);
        var (resp, _) = await app.Client.GETAsync<GetDeviceQuota, DeviceCountDto>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetCount, int>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {

            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ModifiedDate).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ModifiedDate).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.ModifiedDate).ShouldBeInOrder(SortDirection.Descending);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = state.DefaultAscOrderby
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ModifiedDate).ShouldBeInOrder();

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = state.DefaultDescOrderby
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.ModifiedDate).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.Status} {SortDirections.Asc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.Status).ShouldBeInOrder();

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.Status} {SortDirections.Desc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.Status).ShouldBeInOrder(SortDirection.Descending);

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.DeviceName} {SortDirections.Asc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.DeviceName).ShouldBeInOrder();

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.DeviceName} {SortDirections.Desc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.DeviceName).ShouldBeInOrder(SortDirection.Descending);

        var (resp7, res7) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.CreatedDate} {SortDirections.Asc}"
            });
        resp7.IsSuccessStatusCode.ShouldBeTrue();
        res7.Count().ShouldBe(expectedCount);
        res7.Select(x => x.CreatedDate).ShouldBeInOrder();

        var (resp8, res8) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.CreatedDate} {SortDirections.Desc}"
            });
        resp8.IsSuccessStatusCode.ShouldBeTrue();
        res8.Count().ShouldBe(expectedCount);
        res8.Select(x => x.CreatedDate).ShouldBeInOrder(SortDirection.Descending);

        var (resp9, res9) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
            new()
            {
                OrderBy = $"{SortColumns.UpdatedBy} {SortDirections.Asc}"
            });
        resp9.IsSuccessStatusCode.ShouldBeTrue();
        res9.Count().ShouldBe(expectedCount);
        res9.Select(x => x.ModifiedBy_FK).ShouldBeInOrder();

        var (resp10, res10) = await app.Client.GETAsync<GetList, GetListDto, IEnumerable<RegisteredDeviceV2Dto>>(
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
    public async Task GetCountByStatus()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);

        var (resp, res) = await app.Client.GETAsync<GetCountByStatus, GetRegisteredDeviceV2CountByStatusDto, int>(
            new()
            {
                Status = Statuses.Pending
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetCountByStatus, GetRegisteredDeviceV2CountByStatusDto, int>(
            new()
            {
                Status = C4WX1Faker.ShortString
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListOfDevices()
    {
        var createCount = state.CreateCount;
        await SetupDummiesAsync(createCount);
        var (resp, res) = await app.Client.GETAsync<GetListOfDevices, IEnumerable<DeviceCountDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);
        res.First().Count.ShouldBe(createCount);
        await CleanupAsync();
    }
}
