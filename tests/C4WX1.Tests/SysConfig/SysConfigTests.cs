using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Endpoints;
using C4WX1.Tests.Shared;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.SysConfig;

[Collection<C4WX1TestCollection>]
public class SysConfigTests(C4WX1App app, C4WX1State state)
    : TestBase
{
    private Database.Models.SysConfig NewControlData => new()
    {
        ConfigName = "Control-ConfigName",
        ConfigValue = "Control-ConfigValue",
        IsConfigurable = true,
        Description = "Control-Description",
        ModifiedDate = DateTime.Now,
        ModifiedBy_FK = 1
    };

    private async Task AddTestDataAsync(IEnumerable<Database.Models.SysConfig> testData)
    {
        await using var dbContext = app.CreateDbContext();
        dbContext.SysConfig.AddRange(testData);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task RemoveTestDataAsync(IEnumerable<Database.Models.SysConfig> testData)
    {
        await using var dbContext = app.CreateDbContext();
        var configNames = testData.Select(x => x.ConfigName);
        var entitiesToRemove = dbContext.SysConfig
            .Where(x => configNames.Contains(x.ConfigName));
        dbContext.SysConfig.RemoveRange(entitiesToRemove);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Get_WithExistingConfigName()
    {
        var expected = NewControlData;
        await AddTestDataAsync([expected]);

        var (resp, res) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
            new()
            {
                ConfigName = expected.ConfigName
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ConfigName.ShouldBe(expected.ConfigName);
        res.ConfigValue.ShouldBe(expected.ConfigValue);
        res.IsConfigurable.ShouldBe(expected.IsConfigurable);
        res.Description.ShouldBe(expected.Description);

        await RemoveTestDataAsync([expected]);
    }

    [Fact]
    public async Task Get_WithNonExistentConfigName()
    {
        var (resp, res) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
            new()
            {
                ConfigName = SysConfigFaker.ConfigName()
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Get_WithControlConfigName_ButControlDataNotInsertYet()
    {
        var (resp, res) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
            new()
            {
                ConfigName = NewControlData.ConfigName
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetCount_BeforeAddingDummies()
    {
        var (resp, res) = await app.Client.GETAsync<GetCount, int>();

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(app.SysConfigCount);
    }

    [Fact]
    public async Task GetCount_AfterAddingDummies()
    {
        var createCount = state.CreateCount;
        var dummies = new List<Database.Models.SysConfig>();
        for (var i = 0; i < createCount; i++)
        {
            dummies.Add(SysConfigFaker.Dummy());
        }
        await AddTestDataAsync(dummies);

        var (resp, res) = await app.Client.GETAsync<GetCount, int>();

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(app.SysConfigCount + createCount);
        
        await RemoveTestDataAsync(dummies);
    }

    [Fact]
    public async Task GetAllList_BeforeAddingDummyData()
    {
        var (resp, res) = await app.Client.GETAsync<GetAllList, IEnumerable<SysConfigDto>>();

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(app.SysConfigCount);
    }

    [Fact]
    public async Task GetAllList_AfterAddingDummyData()
    {
        var createCount = state.CreateCount;
        var dummies = new List<Database.Models.SysConfig>();
        for (var i = 0; i < createCount; i++)
        {
            dummies.Add(SysConfigFaker.Dummy());
        }
        await AddTestDataAsync(dummies);

        var (resp, res) = await app.Client.GETAsync<GetAllList, IEnumerable<SysConfigDto>>();

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(app.SysConfigCount + createCount);

        await RemoveTestDataAsync(dummies);
    }

    [Fact]
    public async Task GetList_WithDefaultPaginationSize_AndDefaultOrderBy()
    {
        var expectedCount = Math.Min(app.SysConfigCount, PaginationDefaults.Size);

        var (resp, res) = await app.Client.GETAsync<GetList, IEnumerable<SysConfigDto>>();

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
    }

    [Fact]
    public async Task GetList_WithControlConfigName()
    {
        var expected = NewControlData;
        await AddTestDataAsync([expected]);

        var (resp, res) = await app.Client
            .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
            new()
            {
                ConfigName = expected.ConfigName
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(1);
        res.All(x => x.ConfigName == expected.ConfigName).ShouldBeTrue();
        res.All(x => x.ConfigValue == expected.ConfigValue).ShouldBeTrue();
        res.All(x => x.IsConfigurable == expected.IsConfigurable).ShouldBeTrue();
        res.All(x => x.Description == expected.Description).ShouldBeTrue();

        await RemoveTestDataAsync([expected]);
    }

    [Fact]
    public async Task GetList_WithControlConfigValue()
    {
        var expected = NewControlData;
        await AddTestDataAsync([expected]);

        var (resp, res) = await app.Client
            .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
            new()
            {
                ConfigValue = expected.ConfigValue
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(1);
        res.All(x => x.ConfigName == expected.ConfigName).ShouldBeTrue();
        res.All(x => x.ConfigValue == expected.ConfigValue).ShouldBeTrue();
        res.All(x => x.IsConfigurable == expected.IsConfigurable).ShouldBeTrue();
        res.All(x => x.Description == expected.Description).ShouldBeTrue();

        await RemoveTestDataAsync([expected]);
    }

    [Fact]
    public async Task GetList_WithPageSizeMoreThanDataCount()
    {
        var pageSize = 100;
        while (pageSize <= app.SysConfigCount)
        {
            pageSize += 100;
        }
        var expectedCount = Math.Min(app.SysConfigCount, pageSize);

        var (resp, res) = await app.Client
            .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
            new()
            {
                PageSize = pageSize
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBeLessThanOrEqualTo(expectedCount);
        res.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
    }

    [Fact]
    public async Task GetList_WithPageSizeLessThanDataCount()
    {
        var pageSize = 5;
        while (pageSize >= app.SysConfigCount)
        {
            pageSize -= 1;
        }
        var expectedCount = Math.Min(app.SysConfigCount, pageSize);

        var (resp, res) = await app.Client
            .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
            new()
            {
                PageSize = pageSize
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBeLessThanOrEqualTo(expectedCount);
        res.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var expectedCount = Math.Min(app.SysConfigCount, PaginationDefaults.Size);

        var (resp, res) = await app.Client
            .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
            new()
            {
                OrderBy = "ConfigValue asc"
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.ConfigValue).ShouldBeInOrder(SortDirection.Ascending);
    }

    [Fact]
    public async Task Update_Single_WithControlConfigName()
    {
        await AddTestDataAsync([NewControlData]);

        var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
            [
                new UpdateSysConfigDto
                {
                    ConfigName = NewControlData.ConfigName,
                    ConfigValue = SysConfigFaker.ConfigValue(),
                    UserID = C4WX1Faker.UserId
                }
            ]);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await RemoveTestDataAsync([NewControlData]);
    }

    [Fact]
    public async Task Update_Batch()
    {
        var dummies = new List<Database.Models.SysConfig>();
        var req = new List<UpdateSysConfigDto>();
        for (var i = 0; i < state.CreateCount; i++)
        {
            var dummy = SysConfigFaker.Dummy();
            dummies.Add(dummy);
            req.Add(new UpdateSysConfigDto
            {
                ConfigName = dummy.ConfigName,
                ConfigValue = SysConfigFaker.ConfigValue(),
                UserID = C4WX1Faker.UserId
            });
        }
        await AddTestDataAsync(dummies);

        var updatedDummies = dummies
            .Select(x => new UpdateSysConfigDto
            {
                ConfigName = x.ConfigName,
                ConfigValue = SysConfigFaker.ConfigValue(),
                UserID = C4WX1Faker.UserId
            });

        var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
            req);

        resp.IsSuccessStatusCode.ShouldBeTrue();

        await RemoveTestDataAsync(dummies);
    }

    [Fact]
    public async Task Update_WithDummyConfigName()
    {
        var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
            [
                new UpdateSysConfigDto
                {
                    ConfigName = SysConfigFaker.ConfigName(),
                    ConfigValue = SysConfigFaker.ConfigValue(),
                    UserID = C4WX1Faker.UserId
                }
            ]);

        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task Update_WithControlConfigName_ButControlDataNotYetAdded()
    {
        var resp = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
            [
                new UpdateSysConfigDto
                {
                    ConfigName = NewControlData.ConfigName,
                    ConfigValue = SysConfigFaker.ConfigValue(),
                    UserID = C4WX1Faker.UserId
                }
            ]);
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}
