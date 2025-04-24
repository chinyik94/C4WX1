using C4WX1.API.Features.Facility.Constants;
using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.Facility;

[Collection<C4WX1TestCollection>]
public class FacilityTests(C4WX1App app, C4WX1State state) : TestBase
{
    private readonly string ControlOrganizationName = "control-OrganizationName";

    private CreateFacilityDto Control => new()
    {
        FacilityName = "control-FacilityName",
        OrganizationID_FK = 1,
        UserId = 1,
    };

    private CreateFacilityByIntegrationSourceDto ControlIntegrationSource => new()
    {
        FacilityName = "control-FacilityName",
        OrganizationID_FK = 1,
        UserId = 1,
        IntegrationSource = "control-IntegrationSource",
        C_Id = "1",
        Remarks = "control-Remarks",
    };

    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Code.AddAsync(new Database.Models.Code
        {
            CodeTypeId_FKNavigation = new Database.Models.CodeType
            {
                CodeTypeName = "control-CodeTypeName"
            },
            CodeName = ControlOrganizationName,
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task SetupUserDependenciesAsync(int facilityId)
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Users.AddAsync(new Database.Models.Users
        {
            Email = "control-Email",
            Firstname = "control-Firstname",
            Lastname = "control-Lastname",
            UserName = "control-UserName",
            Password = "control-Password",
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
                            UserCategoryFacility = [
                                new Database.Models.UserCategoryFacility
                                {
                                    FacilityID_FK = facilityId
                                }
                                ]
                        }
                    }
                }
                ]
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "Facility", "Code" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task<int> SetupAsync(CreateFacilityDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateFacilityDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task<int> SetupWithIntegrationSourceAsync(CreateFacilityByIntegrationSourceDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<CreateByIntegrationSource, CreateFacilityByIntegrationSourceDto, int>(
            testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    [Fact]
    public async Task Create()
    {
        await SetupDependenciesAsync();

        var (resp, res) = await app.Client.POSTAsync<Create, CreateFacilityDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task CreateByIntegrationSource()
    {
        await SetupDependenciesAsync();

        var (resp, res) = await app.Client.POSTAsync<CreateByIntegrationSource, CreateFacilityByIntegrationSourceDto, int>(
            ControlIntegrationSource);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task DeleteAsync_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = id,
                UserId = 1,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task DeleteAsync_WithNonExistentId()
    {
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                UserId = 1,
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByCId_WithExistingCId()
    {
        await SetupDependenciesAsync();
        var id = await SetupWithIntegrationSourceAsync(ControlIntegrationSource);
        await SetupUserDependenciesAsync(id);

        var (resp, res) = await app.Client.GETAsync<GetByCId, GetFacilityByCIdDto, FacilityDto>(
            new()
            {
                CId = ControlIntegrationSource.C_Id!,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.FacilityID.ShouldBe(id);
        res.FacilityName.ShouldBe(ControlIntegrationSource.FacilityName);
        res.OrganizationID_FK.ShouldBe(ControlIntegrationSource.OrganizationID_FK);
        res.OrganizationName.ShouldBe(ControlOrganizationName);
        res.C_id.ShouldBe(ControlIntegrationSource.C_Id);
        res.Remarks.ShouldBe(ControlIntegrationSource.Remarks);
        res.IntegrationSource.ShouldBe(ControlIntegrationSource.IntegrationSource);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetByCId_WithNonExistentCId()
    {
        var (resp, res) = await app.Client.GETAsync<GetByCId, GetFacilityByCIdDto, FacilityDto>(
            new()
            {
                CId = FacilityFaker.CId,
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);

        var (resp, res) = await app.Client.GETAsync<GetCount, GetFacilityCountDto, int>(
            new());
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithKeyword()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetCount, GetFacilityCountDto, int>(
            new()
            {
                Keyword = Control.FacilityName,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(1);

        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetFacilityCountDto, int>(
            new()
            {
                Keyword = FacilityFaker.FacilityName,
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithOrganizationId()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);

        var (resp, res) = await app.Client.GETAsync<GetCount, GetFacilityCountDto, int>(
            new()
            {
                OrganizationId = Control.OrganizationID_FK,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetFacilityCountDto, int>(
            new()
            {
                OrganizationId = C4WX1Faker.Id,
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new());
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.FacilityName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                PageSize = state.LowPageSize,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.FacilityName).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                PageSize = state.HighPageSize,
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.FacilityName).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                OrderBy = $"{state.DefaultAscOrderby}",
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.FacilityName).ShouldBeInOrder(SortDirection.Ascending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                OrderBy = $"{state.DefaultDescOrderby}",
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.FacilityName).ShouldBeInOrder(SortDirection.Descending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Group}, {SortDirections.Desc}",
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.OrganizationName).ShouldBeInOrder(SortDirection.Descending);

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Group}, {SortDirections.Asc}",
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.OrganizationName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithKeyword()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                Keyword = Control.FacilityName,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                Keyword = FacilityFaker.FacilityName,
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithOrganizationId()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                OrganizationId = Control.OrganizationID_FK,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(expectedCount);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetFacilityListDto, IEnumerable<FacilityDto>>(
            new()
            {
                OrganizationId = C4WX1Faker.Id,
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListByIntegrationSource()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        var id = await SetupWithIntegrationSourceAsync(ControlIntegrationSource);

        var (resp, res) = await app.Client.GETAsync<GetListByIntegrationSource, GetFacilityListByIntegrationSourceDto, IEnumerable<FacilityDto>>(
            new()
            {
                IntegrationSource = ControlIntegrationSource.IntegrationSource!,
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListByIntegrationSource_WithFacilityId()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);
        var id = await SetupWithIntegrationSourceAsync(ControlIntegrationSource);

        var (resp, res) = await app.Client.GETAsync<GetListByIntegrationSource, GetFacilityListByIntegrationSourceDto, IEnumerable<FacilityDto>>(
            new()
            {
                IntegrationSource = ControlIntegrationSource.IntegrationSource!,
                FacilityId = id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListByType()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(x => SetupAsync(x));
        await Task.WhenAll(createTasks);

        var (resp, res) = await app.Client.GETAsync<GetListByType, GetFacilityListByTypeDto, IEnumerable<FacilityDto>>(
            new()
            {
                TypeId = Control.OrganizationID_FK
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetListByUser()
    {
        var createCount = state.CreateCount;
        await SetupDependenciesAsync();
        var createTasks = Enumerable.Range(0, createCount)
            .Select(x => new CreateFacilityDto
            {
                FacilityName = FacilityFaker.FacilityName,
                OrganizationID_FK = 1,
                UserId = C4WX1Faker.Id,
            })
            .Select(async x =>
            {
                var id = await SetupAsync(x);
                await SetupUserDependenciesAsync(id);
            });
        await Task.WhenAll(createTasks);

        var (resp, res) = await app.Client.GETAsync<GetListByUser, GetFacilityListByUserDto, IEnumerable<FacilityDto>>(
            new()
            {
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBe(1);

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var resp = await app.Client.PUTAsync<Update, UpdateFacilityDto>(
            new()
            {
                Id = id,
                FacilityName = "control-FacilityName-Updated",
                OrganizationID_FK = 1,
                UserId = 1,
            });

        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateFacilityDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                FacilityName = "control-FacilityName-Updated",
                OrganizationID_FK = 1,
                UserId = 1,
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateByIntegrationSource_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupWithIntegrationSourceAsync(ControlIntegrationSource);

        var resp = await app.Client.PUTAsync<UpdateByIntegrationSource, UpdateFacilityByIntegrationSourceDto>(
            new()
            {
                Id = id,
                FacilityName = "control-FacilityName-Updated",
                OrganizationID_FK = 1,
                UserId = 1,
                IntegrationSource = ControlIntegrationSource.IntegrationSource,
                C_Id = ControlIntegrationSource.C_Id,
                Remarks = "control-Remarks-Updated",
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateByIntegrationSource_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<UpdateByIntegrationSource, UpdateFacilityByIntegrationSourceDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                FacilityName = "control-FacilityName-Updated",
                OrganizationID_FK = 1,
                UserId = 1,
                IntegrationSource = ControlIntegrationSource.IntegrationSource,
                C_Id = ControlIntegrationSource.C_Id,
                Remarks = "control-Remarks-Updated",
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }
}