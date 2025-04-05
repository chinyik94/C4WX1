using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Get;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Language
{
    public class LanguageTests(LanguageApp app) 
        : TestBase<LanguageApp>
    {
        [Fact, Priority(1)]
        public async Task Get_Language_List()
        {
            var (resp, res) = await app.Client.GETAsync<GetList, IEnumerable<LanguageDto>>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            res.ShouldNotBeNull();
            res.ShouldNotBeEmpty();
            res.Count().ShouldBe(2);
            res.Select(x => x.Name).ShouldBeInOrder(SortDirection.Ascending);
        }

        [Fact, Priority(2)]
        public async Task Get_Language_ById()
        {
            var (resp1, res1) = await app.Client.GETAsync<GetById, GetByIdDto, LanguageDto>(
                new()
                {
                    Id = 1
                });
            resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
            res1.ShouldNotBeNull();
            res1.LanguageId.ShouldBe(1);
            res1.Name.ShouldBe("en-US");
            res1.FullName.ShouldBe("English");

            var (resp2, res2) = await app.Client.GETAsync<GetById, GetByIdDto, LanguageDto>(
                new()
                {
                    Id = 2
                });
            resp2.StatusCode.ShouldBe(HttpStatusCode.OK);
            res2.ShouldNotBeNull();
            res2.LanguageId.ShouldBe(2);
            res2.Name.ShouldBe("pt-BR");
            res2.FullName.ShouldBe("Portuguese (Brazil)");

            var (resp3, res3) = await app.Client.GETAsync<GetById, GetByIdDto, LanguageDto>(
                new()
                {
                    Id = 1000
                });
            resp3.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res3.ShouldBeNull();
        }

        [Fact, Priority(3)]
        public async Task Get_Language_ByName()
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
            resp2.StatusCode.ShouldBe(HttpStatusCode.OK);
            res2.ShouldNotBeNull();
            res2.LanguageId.ShouldBe(2);
            res2.Name.ShouldBe("pt-BR");
            res2.FullName.ShouldBe("Portuguese (Brazil)");

            var (resp3, res3) = await app.Client
                .GETAsync<GetByName, GetLanguageByNameDto, LanguageDto>(
                new()
                {
                    Name = "test"
                });
            resp3.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res3.ShouldBeNull();
        }

        [Fact, Priority(4)]
        public async Task Get_Language_ByFullName()
        {
            var (resp1, res1) = await app.Client
                .GETAsync<GetByFullName, GetLanguageByFullNameDto, LanguageDto>(
                new()
                {
                    FullName = "English"
                });
            resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
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
            resp2.StatusCode.ShouldBe(HttpStatusCode.OK);
            res2.ShouldNotBeNull();
            res2.LanguageId.ShouldBe(2);
            res2.Name.ShouldBe("pt-BR");
            res2.FullName.ShouldBe("Portuguese (Brazil)");

            var (resp3, res3) = await app.Client
                .GETAsync<GetByFullName, GetLanguageByFullNameDto, LanguageDto>(
                new()
                {
                    FullName = "Test Language"
                });
            resp3.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res3.ShouldBeNull();
        }
    }
}
