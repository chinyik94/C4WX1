using C4WX1.API.Features.SysConfig.Create;
using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Get;
using C4WX1.API.Features.SysConfig.Update;

namespace C4WX1.Tests.SysConfig
{
    public class SysConfigTests(SysConfigApp app, SysConfigState state) 
        : TestBase<SysConfigApp, SysConfigState>
    {
        [Fact, Priority(1)]
        public async Task Create_SysConfigs()
        {
            var controlData = state.Control;
            var controlRequest = new CreateSysConfigDto
            {
                ConfigName = controlData.ConfigName,
                ConfigValue = controlData.ConfigValue,
                IsConfigurable = controlData.IsConfigurable,
                Description = controlData.Description
            };
            var controlResponse = await app.Client.POSTAsync<Create, CreateSysConfigDto>(controlRequest);
            controlResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);

            var randomRequests = Enumerable.Range(0, app.CreateCount)
                .Select(x => SysConfigFaker.CreateDto());
            foreach (var request in randomRequests)
            {
                var response = await app.Client.POSTAsync<Create, CreateSysConfigDto>(request);
                response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            }
        }

        [Fact, Priority(2)]
        public async Task Get_SysConfig()
        {
            var expected = state.Control;
            var (resp1, res1) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
                new()
                {
                    ConfigName = expected.ConfigName
                });

            resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
            res1.ShouldNotBeNull();
            res1.ConfigName.ShouldBe(expected.ConfigName);
            res1.ConfigValue.ShouldBe(expected.ConfigValue);
            res1.IsConfigurable.ShouldBe(expected.IsConfigurable);
            res1.Description.ShouldBe(expected.Description);

            var (resp2, res2) = await app.Client.GETAsync<Get, GetSysConfigDto, SysConfigDto>(
                new()
                {
                    ConfigName = SysConfigFaker.ConfigName()
                });
            resp2.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res2.ShouldBeNull();
        }

        [Fact, Priority(3)]
        public async Task Get_SysConfig_Count()
        {
            var (resp, res) = await app.Client.GETAsync<GetCount, int>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            res.ShouldBeGreaterThan(0);
            res.ShouldBe(app.CreateCount + 1);
        }

        [Fact, Priority(4)]
        public async Task Get_SysConfig_AllList()
        {
            var (resp, res) = await app.Client.GETAsync<GetAllList, IEnumerable<SysConfigDto>>();
            resp.StatusCode.ShouldBe(HttpStatusCode.OK);
            res.ShouldNotBeNull();
            res.ShouldNotBeEmpty();
            res.Count().ShouldBe(app.CreateCount + 1);
        }

        [Fact, Priority(5)]
        public async Task Get_SysConfig_List()
        {
            var (resp1, res1) = await app.Client.GETAsync<GetList, IEnumerable<SysConfigDto>>();
            resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
            res1.ShouldNotBeNull();
            res1.ShouldNotBeEmpty();
            res1.Count().ShouldBe(app.ExpectedCount());
            res1.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);

            var expectedConfigName = state.Control.ConfigName;
            var (resp2, res2) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    ConfigName = expectedConfigName
                });
            resp2.StatusCode.ShouldBe(HttpStatusCode.OK);
            res2.ShouldNotBeNull();
            res2.ShouldNotBeEmpty();
            res2.Count().ShouldBe(1);
            res2.All(x => x.ConfigName == expectedConfigName).ShouldBeTrue();
            res2.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);

            var expectedConfigValue = state.Control.ConfigValue;
            var (resp3, res3) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    ConfigValue = expectedConfigValue
                });
            resp3.StatusCode.ShouldBe(HttpStatusCode.OK);
            res3.ShouldNotBeNull();
            res3.ShouldNotBeEmpty();
            res3.Count().ShouldBe(1);
            res3.All(x => x.ConfigValue == expectedConfigValue).ShouldBeTrue();
            res3.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);

            var pageSize = 100;
            var (resp4, res4) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    PageSize = pageSize
                });
            resp4.StatusCode.ShouldBe(HttpStatusCode.OK);
            res4.ShouldNotBeNull();
            res4.ShouldNotBeEmpty();
            res4.Count().ShouldBeLessThanOrEqualTo(app.ExpectedCount(pageSize));
            res4.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);

            pageSize = 5;
            var (resp5, res5) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    PageSize = pageSize
                });
            resp5.StatusCode.ShouldBe(HttpStatusCode.OK);
            res5.ShouldNotBeNull();
            res5.ShouldNotBeEmpty();
            res5.Count().ShouldBeLessThanOrEqualTo(app.ExpectedCount(pageSize));
            res5.Select(x => x.ConfigName).ShouldBeInOrder(SortDirection.Descending);

            var (resp6, res6) = await app.Client
                .GETAsync<GetList, GetSysConfigListDto, IEnumerable<SysConfigDto>>(
                new()
                {
                    OrderBy = "ConfigValue asc"
                });
            resp6.StatusCode.ShouldBe(HttpStatusCode.OK);
            res6.ShouldNotBeNull();
            res6.ShouldNotBeEmpty();
            res6.Count().ShouldBe(app.ExpectedCount());
            res6.Select(x => x.ConfigValue).ShouldBeInOrder(SortDirection.Ascending);
        }

        [Fact, Priority(5)]
        public async Task Update_SysConfig()
        {
            var resp1 = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
                [
                    SysConfigFaker.UpdateDto(),
                    SysConfigFaker.UpdateDto(),
                ]);

            resp1.StatusCode.ShouldBe(HttpStatusCode.NotFound);

            var controlData = state.Control.ConfigName;
            var resp2 = await app.Client.PUTAsync<Update, IEnumerable<UpdateSysConfigDto>>(
                [
                    new() {
                        ConfigName = controlData,
                        ConfigValue = SysConfigFaker.ConfigValue(),
                        UserID = SysConfigFaker.UserId()
                    },
                    new() {
                        ConfigName = controlData,
                        ConfigValue = SysConfigFaker.ConfigValue(),
                        UserID = SysConfigFaker.UserId()
                    },
                ]);

            resp2.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}
