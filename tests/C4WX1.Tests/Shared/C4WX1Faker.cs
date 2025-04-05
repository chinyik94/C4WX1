using Bogus;

namespace C4WX1.Tests.Shared
{
    public class C4WX1Faker
    {
        public static int CreateCount() => new Faker().Random.Int(1, 10);
    }
}
