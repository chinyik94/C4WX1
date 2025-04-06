using C4WX1.API.Features.C4WDeviceToken.Create;
using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Get;
using C4WX1.API.Features.C4WDeviceToken.Update;

namespace C4WX1.Tests.C4WDeviceToken
{
    public class C4WDeviceTokenTests(
        C4WDeviceTokenApp app,
        C4WDeviceTokenState state)
        : TestBase<C4WDeviceTokenApp, C4WDeviceTokenState>
    {
        [Fact, Priority(1)]
        public async Task Create_C4WDeviceToken()
        {
            var req = new CreateC4WDeviceTokenDto
            {
                OldDeviceToken = state.Control.OldDeviceToken,
                NewDeviceToken = state.Control.NewDeviceToken,
                ClientEnvironment = state.Control.ClientEnvironment,
                Device = state.Control.Device,
                UserId = C4WDeviceTokenFaker.UserId()
            };

            var resp = await app.Client.POSTAsync<Create, CreateC4WDeviceTokenDto>(req);
            resp.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact, Priority(2)]
        public async Task Get_C4WDeviceToken_ByOldDeviceToken()
        {
            var expected = state.Control;
            expected.OldDeviceToken.ShouldNotBeNullOrWhiteSpace();
            var (resp1, res1) = await app.Client.GETAsync<GetByOldDeviceToken, GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto>(
                new()
                {
                    OldDeviceToken = expected.OldDeviceToken
                });
            resp1.StatusCode.ShouldBe(HttpStatusCode.OK);
            res1.ShouldNotBeNull();
            res1.C4WDeviceTokenId.ShouldBeGreaterThan(0);
            res1.OldDeviceToken.ShouldBe(expected.OldDeviceToken);
            res1.NewDeviceToken.ShouldBe(expected.NewDeviceToken);
            res1.ClientEnvironment.ShouldBe(expected.ClientEnvironment);
            res1.Device.ShouldBe(expected.Device);
            state.InsertedIds.Add(res1.C4WDeviceTokenId);

            var (resp2, res2) = await app.Client.GETAsync<GetByOldDeviceToken, GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto>(
                new()
                {
                    OldDeviceToken = C4WDeviceTokenFaker.OldDeviceToken()
                });
            resp2.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            res2.ShouldBeNull();
        }

        [Fact, Priority(3)]
        public async Task Update_C4WDeviceToken()
        {
            var req = new UpdateC4WDeviceTokenDto
            {
                C4WDeviceTokenId = state.InsertedIds.First(),
                OldDeviceToken = state.Control.OldDeviceToken,
                NewDeviceToken = state.Control.NewDeviceToken,
                ClientEnvironment = state.Control.ClientEnvironment,
                Device = state.Control.Device,
                UserId = C4WDeviceTokenFaker.UserId()
            };
            var resp1 = await app.Client.PUTAsync<Update, UpdateC4WDeviceTokenDto>(req);
            resp1.StatusCode.ShouldBe(HttpStatusCode.NoContent);

            var req2 = new UpdateC4WDeviceTokenDto
            {
                C4WDeviceTokenId = C4WDeviceTokenFaker.Id(),
                OldDeviceToken = state.Control.OldDeviceToken,
                NewDeviceToken = state.Control.NewDeviceToken,
                ClientEnvironment = state.Control.ClientEnvironment,
                Device = state.Control.Device,
                UserId = C4WDeviceTokenFaker.UserId()
            };
            var resp2 = await app.Client.PUTAsync<Update, UpdateC4WDeviceTokenDto>(req2);
            resp2.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}
