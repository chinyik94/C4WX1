using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Get;
using FastEndpoints;
using FastEndpoints.Testing;
using Shouldly;
using System.Net;

namespace C4WX1.Tests.SysConfig
{
    [Collection<SysConfigTestsCollection>]
    [Priority(5)]
    public class GetListTests(C4WX1App app) : TestBase
    {

        [Fact, Priority(1)]
        public async Task WithoutSpecificRequest()
        {
            var (resp, result) = await app.Client.GETAsync<GetList, IEnumerable<SysConfigDto>>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(10);
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(2)]
        public async Task WithSpecificConfigName()
        {
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    ConfigName = SysConfigDataHelper.ConfigName
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(1);
            result.All(x => x.ConfigName == SysConfigDataHelper.ConfigName).ShouldBeTrue();
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(3)]
        public async Task WithSpecificConfigValue()
        {
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    ConfigValue = SysConfigDataHelper.ConfigValue
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(1);
            result.All(x => x.ConfigValue == SysConfigDataHelper.ConfigValue).ShouldBeTrue();
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(4)]
        public async Task WithSpecificPageSize()
        {
            var (resp, result) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    PageSize = 100
                });
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(100);
            result.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact, Priority(5)]
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
            result.Count().ShouldBe(10);
            result.Select(x => x.ConfigValue).ShouldBeInOrder(SortDirection.Ascending);
        }
    }
}
