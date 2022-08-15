using SS.Interview.BettingPlatform.Managers; 

namespace SS.Interview.BettingPlatform.Xunit;

public class TestUserStory3
{
       


    [Theory]
    [InlineData(0, 20, 20)]
    [InlineData(10, 20, 22)]
    [InlineData(-10, 20, 18)]
    public void AmmendProbabilityTest(double probabilityChange, double probabilityInputValue, double targetValue)
    {
        var value1 = ProbabilityModifier.CalculateProbability(probabilityChange, probabilityInputValue);
        Assert.Equal( targetValue, value1);

        var value2 = ProbabilityModifier.CalculateProbability(probabilityChange, probabilityInputValue);
        Assert.Equal(targetValue, value2);

        var value3 = ProbabilityModifier.CalculateProbability(probabilityChange, probabilityInputValue);
        Assert.Equal( targetValue, value3);

    }

}

