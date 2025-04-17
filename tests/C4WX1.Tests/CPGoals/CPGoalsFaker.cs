namespace C4WX1.Tests.CPGoals;

public class CPGoalsFaker
{
    public static string CPGoalsInfo => new Faker().Random.AlphaNumeric(10);
}
