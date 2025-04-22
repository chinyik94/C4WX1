using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.ExternalDoctor.Constants;
using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.API.Features.ExternalDoctor.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Tests.Shared;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.ExternalDoctor;

[Collection<C4WX1TestCollection>]
public class ExternalDoctorTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateExternalDoctorDto Control => new()
    {
        Name = "control Name",
        Email = "control-Email",
        Contact = "control-Contact",
        ClinicianTypeID_FK = 1,
        UserId = 1
    };
    private readonly string UserFirstName = "Test";
    private readonly string UserLastName = "User";

    private async Task SetupDependenciesAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.UserType.AddAsync(new Database.Models.UserType
        {
            UserType1 = "control-UserType1",
            UserCategoryID_FKNavigation = new Database.Models.UserCategory
            {
                UserCategory1 = "control-UserCategory1",
            }
        }, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task SetupUserAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Users.AddAsync(new Database.Models.Users
        {
            UserName = "control-UserName",
            Password = "control-Password",
            Email = "control-Email",
            Firstname = UserFirstName,
            Lastname = UserLastName,
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
                },
                new Database.Models.UserUserType
                {
                    UserTypeID_FKNavigation = new Database.Models.UserType
                    {
                        UserType1 = "control-UserType2",
                        UserCategoryID_FKNavigation = new Database.Models.UserCategory
                        {
                            UserCategory1 = "control-UserCategory2",
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
            TRUNCATE TABLE "ExternalDoctor", "Users", "UserType" RESTART IDENTITY CASCADE;
            """, TestContext.Current.CancellationToken);
        await dbContext.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    private async Task<int> SetupAsync(CreateExternalDoctorDto testData)
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateExternalDoctorDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    [Fact]
    public async Task Create_WithoutExistingDoctorAndDoctorUser()
    {
        await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<Create, CreateExternalDoctorDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Create_WithExistingDoctor()
    {
        await SetupDependenciesAsync();
        await SetupAsync(Control);
        var (resp, res) = await app.Client.POSTAsync<Create, CreateExternalDoctorDto, int>(Control);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBe(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Create_WithExistingDoctorUser()
    {
        await SetupDependenciesAsync();
        await SetupUserAsync();
        var control = Control;
        control.Name = $"{UserFirstName} {UserLastName}";
        var (resp, res) = await app.Client.POSTAsync<Create, CreateExternalDoctorDto, int>(control);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBe(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId_WithoutExistingDoctorAndDoctorUser()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var resp = await app.Client.PUTAsync<Update, UpdateExternalDoctorDto>(
            new()
            {
                Id = id,
                Name = "updated Name",
                Email = "updated-control-Email",
                Contact = "updated-control-Contact",
                ClinicianTypeID_FK = 1,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId_WithExistingDoctor()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var resp = await app.Client.PUTAsync<Update, UpdateExternalDoctorDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                Name = Control.Name,
                Email = "updated-control-Email",
                Contact = "updated-control-Contact",
                ClinicianTypeID_FK = 1,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithExistingId_WithExistingDoctorUser()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);
        await SetupUserAsync();

        var resp = await app.Client.PUTAsync<Update, UpdateExternalDoctorDto>(
            new()
            {
                Id = id,
                Name = $"{UserFirstName} {UserLastName}",
                Email = "updated-control-Email",
                Contact = "updated-control-Contact",
                ClinicianTypeID_FK = 1,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();

        await CleanupAsync();
    }

    [Fact]
    public async Task Update_WithNonExistentId()
    {
        var resp = await app.Client.PUTAsync<Update, UpdateExternalDoctorDto>(
            new()
            {
                Id = C4WX1Faker.Id,
                Name = "updated Name",
                Email = "updated-control-Email",
                Contact = "updated-control-Contact",
                ClinicianTypeID_FK = 1,
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ExternalDoctorDto>(
            new()
            {
                Id = id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res!.Name.ShouldBe(Control.Name);
        res.Email.ShouldBe(Control.Email);
        res.Contact.ShouldBe(Control.Contact);
        res.ClinicianTypeID_FK.ShouldBe(Control.ClinicianTypeID_FK);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, ExternalDoctorDto>(
            new()
            {
                Id = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task Delete_WithExistingId()
    {
        await SetupDependenciesAsync();
        var id = await SetupAsync(Control);

        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = id
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task Delete_WithNonExistentId()
    {
        var resp = await app.Client.DELETEAsync<Delete, DeleteByIdDto>(
            new()
            {
                Id = C4WX1Faker.Id
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }

    [Fact]
    public async Task GetCount_WithoutSearch()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => ExternalDoctorFaker.DummyCreate);
        var tasks = dummies.Select(x => SetupAsync(x));
        await Task.WhenAll(tasks);

        var (resp, res) = await app.Client.GETAsync<GetCount, GetExternalDoctorCountDto, int>(new());
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(createCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithSearch()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => ExternalDoctorFaker.DummyCreate);
        var tasks = dummies.Select(x => SetupAsync(x));
        await Task.WhenAll(tasks);
        await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetCount, GetExternalDoctorCountDto, int>(
            new()
            {
                Search = Control.Name
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(1);

        var (resp2, res2) = await app.Client.GETAsync<GetCount, GetExternalDoctorCountDto, int>(
            new()
            {
                Search = Control.Email
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldBe(1);

        var (resp3, res3) = await app.Client.GETAsync<GetCount, GetExternalDoctorCountDto, int>(
            new()
            {
                Search = Control.Contact
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldBe(1);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => ExternalDoctorFaker.DummyCreate);
        var tasks = dummies.Select(x => SetupAsync(x));
        await Task.WhenAll(tasks);

        var expectedCount = Math.Min(createCount, state.DefaultPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new());
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Name).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithSearch()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => ExternalDoctorFaker.DummyCreate);
        var tasks = dummies.Select(x => SetupAsync(x));
        await Task.WhenAll(tasks);
        await SetupAsync(Control);

        var (resp, res) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                Search = Control.Name
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(1);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                Search = Control.Email
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(1);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                Search = Control.Contact
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldNotBeNull();
        res3.Count().ShouldBe(1);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => ExternalDoctorFaker.DummyCreate);
        var tasks = dummies.Select(x => SetupAsync(x));
        await Task.WhenAll(tasks);

        var expectedCount = Math.Min(createCount, state.LowPageSize);
        var (resp, res) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                PageSize = state.LowPageSize
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Name).ShouldBeInOrder(SortDirection.Descending);

        var expectedCount2 = Math.Min(createCount, state.HighPageSize);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                PageSize = state.HighPageSize
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.Name).ShouldBeInOrder(SortDirection.Descending);
    }

    [Fact]
    public async Task GetList_WithOrderBy()
    {
        await SetupDependenciesAsync();
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => ExternalDoctorFaker.DummyCreate);
        var tasks = dummies.Select(x => SetupAsync(x));
        await Task.WhenAll(tasks);
        var expectedCount = Math.Min(createCount, state.DefaultPageSize);

        var (resp, res) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Name} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.Name).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Name} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.Name).ShouldBeInOrder(SortDirection.Ascending);

        var (resp3, res3) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Email} {SortDirections.Desc}"
            });
        resp3.IsSuccessStatusCode.ShouldBeTrue();
        res3.ShouldNotBeNull();
        res3.Count().ShouldBe(expectedCount);
        res3.Select(x => x.Email).ShouldBeInOrder(SortDirection.Descending);

        var (resp4, res4) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Email} {SortDirections.Asc}"
            });
        resp4.IsSuccessStatusCode.ShouldBeTrue();
        res4.ShouldNotBeNull();
        res4.Count().ShouldBe(expectedCount);
        res4.Select(x => x.Email).ShouldBeInOrder(SortDirection.Ascending);

        var (resp5, res5) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Contact} {SortDirections.Desc}"
            });
        resp5.IsSuccessStatusCode.ShouldBeTrue();
        res5.ShouldNotBeNull();
        res5.Count().ShouldBe(expectedCount);
        res5.Select(x => x.Contact).ShouldBeInOrder(SortDirection.Descending);

        var (resp6, res6) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Contact} {SortDirections.Asc}"
            });
        resp6.IsSuccessStatusCode.ShouldBeTrue();
        res6.ShouldNotBeNull();
        res6.Count().ShouldBe(expectedCount);
        res6.Select(x => x.Contact).ShouldBeInOrder(SortDirection.Ascending);

        var (resp7, res7) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Type} {SortDirections.Desc}"
            });
        resp7.IsSuccessStatusCode.ShouldBeTrue();
        res7.ShouldNotBeNull();
        res7.Count().ShouldBe(expectedCount);
        res7.Select(x => x.ClinicianTypeName).ShouldBeInOrder(SortDirection.Descending);

        var (resp8, res8) = await app.Client.GETAsync<GetList, GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>>(
            new()
            {
                OrderBy = $"{SortColumns.Type} {SortDirections.Asc}"
            });
        resp8.IsSuccessStatusCode.ShouldBeTrue();
        res8.ShouldNotBeNull();
        res8.Count().ShouldBe(expectedCount);
        res8.Select(x => x.ClinicianTypeName).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task ChangeToUser()
    {
        await SetupDependenciesAsync();
        await SetupAsync(Control);
        await SetupUserAsync();

        var resp = await app.Client.POSTAsync<ChangeToUser, ChangeExternalDoctorToUserDto>(
            new()
            {
                ExternalName = Control.Name,
                UserName = $"{UserFirstName} {UserLastName}",
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();

        await CleanupAsync();
    }

    [Fact]
    public async Task ChangeToUser_WithoutExistingUser()
    {
        await SetupDependenciesAsync();
        await SetupAsync(Control);
        var resp = await app.Client.POSTAsync<ChangeToUser, ChangeExternalDoctorToUserDto>(
            new()
            {
                ExternalName = Control.Name,
                UserName = $"{UserFirstName} {UserLastName}",
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task ChangeToUser_WithoutExistingExternalDoctor()
    {
        var resp = await app.Client.POSTAsync<ChangeToUser, ChangeExternalDoctorToUserDto>(
            new()
            {
                ExternalName = Control.Name,
                UserName = $"{UserFirstName} {UserLastName}",
                UserId = 1
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
    }
}