using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Get;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(5)]
    public class GetListTests(SysConfigAppFixture app) : TestBase
    {
        [Fact, Priority(1)]
        public async Task WithoutSpecificRequest()
        {
            var (resp, result) = await app.Client.GETAsync<GetList, IEnumerable<SysConfigDto>>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(app.ExpectedCount());
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(2)]
        public async Task WithSpecificConfigName()
        {
            var expected = app.Control.ConfigName;
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    ConfigName = expected
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(1);
            result.All(x => x.ConfigName == expected).ShouldBeTrue();
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(3)]
        public async Task WithSpecificConfigValue()
        {
            var expected = app.Control.ConfigValue;
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    ConfigValue = expected
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(1);
            result.All(x => x.ConfigValue == expected).ShouldBeTrue();
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(4)]
        public async Task WithPageSizeMoreThanCreateCount()
        {
            var pageSize = 100;
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    PageSize = pageSize
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBeLessThanOrEqualTo(app.ExpectedCount(pageSize));
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(5)]
        public async Task WithPageSizeLessThanCreateCount()
        {
            var pageSize = 5;
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    PageSize = pageSize
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBeLessThanOrEqualTo(app.ExpectedCount(pageSize));
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(6)]
        public async Task WithSpecificOrderBy_Descending()
        {
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    OrderBy = "ConfigValue asc"
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(app.ExpectedCount());
            result.Select(x => x.ConfigValue).ShouldBeInOrder(SortDirection.Ascending);
        }
    }
}
