namespace C4WX1.Tests.Facility;
public class FacilityFaker
{
    public static string CId => new Faker().Random.Number().ToString();
    public static string FacilityName => new Faker().Company.CompanyName(0);
}
