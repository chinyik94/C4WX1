namespace C4WX1.Tests.CarePlanSubGoal;
public class CarePlanSubGoalFaker
{
    public static string CarePlanSubGoalName => new Faker().Random.AlphaNumeric(10);
}
