using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Endpoints;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Language;

[Collection<C4WX1TestCollection>]
public class LanguageTests(C4WX1App app) : TestBase
{
    [Fact]
    public async Task GetList()
    {
        var (resp, res) = await app.Client.GETAsync<GetList, IEnumerable<LanguageDto>>();
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.ShouldNotBeEmpty();
        res.Count().ShouldBe(2);
        res.Select(x => x.Name).ShouldBeInOrder(SortDirection.Ascending);
    }

    [Fact]
    public async Task GetById_WithExistingId()
    {
        var (resp1, res1) = await app.Client.GETAsync<GetById, GetByIdDto, LanguageDto>(
            new()
            {
                Id = 1
            });
        resp1.IsSuccessStatusCode.ShouldBeTrue();
        res1.ShouldNotBeNull();
        res1.LanguageId.ShouldBe(1);
        res1.Name.ShouldBe("en-US");
        res1.FullName.ShouldBe("English");

        var (resp2, res2) = await app.Client.GETAsync<GetById, GetByIdDto, LanguageDto>(
            new()
            {
                Id = 2
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.LanguageId.ShouldBe(2);
        res2.Name.ShouldBe("pt-BR");
        res2.FullName.ShouldBe("Portuguese (Brazil)");
    }

    [Fact]
    public async Task GetById_WithNonExistentId()
    {
        var (resp, res) = await app.Client.GETAsync<GetById, GetByIdDto, LanguageDto>(
            new()
            {
                Id = new Faker().Random.Int(100)
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GeyByName_WithExistingName()
    {
        var (resp1, res1) = await app.Client
            .GETAsync<GetByName, GetLanguageByNameDto, LanguageDto>(
            new()
            {
                Name = "en-US"
            });
        resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
        res1.ShouldNotBeNull();
        res1.LanguageId.ShouldBe(1);
        res1.Name.ShouldBe("en-US");
        res1.FullName.ShouldBe("English");

        var (resp2, res2) = await app.Client
            .GETAsync<GetByName, GetLanguageByNameDto, LanguageDto>(
            new()
            {
                Name = "pt-BR"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.LanguageId.ShouldBe(2);
        res2.Name.ShouldBe("pt-BR");
        res2.FullName.ShouldBe("Portuguese (Brazil)");
    }

    [Fact]
    public async Task GetByName_WithNonExistentName()
    {
        var (resp, res) = await app.Client
            .GETAsync<GetByName, GetLanguageByNameDto, LanguageDto>(
            new()
            {
                Name = "test"
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }

    [Fact]
    public async Task GetByFullName_WithExistingFullName()
    {
        var (resp1, res1) = await app.Client
            .GETAsync<GetByFullName, GetLanguageByFullNameDto, LanguageDto>(
            new()
            {
                FullName = "English"
            });
        resp1.IsSuccessStatusCode.ShouldBeTrue();
        res1.ShouldNotBeNull();
        res1.LanguageId.ShouldBe(1);
        res1.Name.ShouldBe("en-US");
        res1.FullName.ShouldBe("English");

        var (resp2, res2) = await app.Client
            .GETAsync<GetByFullName, GetLanguageByFullNameDto, LanguageDto>(
            new()
            {
                FullName = "Portuguese (Brazil)"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.ShouldNotBeNull();
        res2.LanguageId.ShouldBe(2);
        res2.Name.ShouldBe("pt-BR");
        res2.FullName.ShouldBe("Portuguese (Brazil)");
    }

    [Fact]
    public async Task GetByFullName_WithNonExistentFullName()
    {
        var (resp, res) = await app.Client
            .GETAsync<GetByFullName, GetLanguageByFullNameDto, LanguageDto>(
            new()
            {
                FullName = "Test Language"
            });
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
    }
}
