namespace C4WX1.Tests.C4WDeviceToken
{
    public class C4WDeviceTokenFaker
    {
        public static string OldDeviceToken() => new Faker().Random.AlphaNumeric(10);

        public static int UserId() => new Faker().Random.Int();

        public static int Id() => new Faker().Random.Int();
    }
}
