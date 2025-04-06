namespace C4WX1.Tests.C4WDeviceToken
{
    public class C4WDeviceTokenState : StateFixture
    {
        public Database.Models.C4WDeviceToken Control => new()
        {
            OldDeviceToken = "Control-OldDeviceToken",
            NewDeviceToken = "Control-NewDeviceToken",
            ClientEnvironment = "Control-ClientEnvironment",
            Device = "Control-Device"
        };

        public List<int> InsertedIds { get; set; } = [];
    }
}
