using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SS.Interview.BettingPlatform.Xunit;

public class TestUserStory4
{
    private Market[] _marketResults;

    public TestUserStory4()
    {
        _marketResults = new[]
        {
            new Market
            {
                Id = string.Concat("Arsenal - Man U", " - Match Winner"),
                Selections = new []
                {
                    new Selection{ Id = "Manchester United", Probability = 100 },
                    new Selection{ Id = "Draw", Probability = 10.0 },
                    new Selection{ Id = "Arsenal", Probability = 2.0 },
                }
            }
        };

    }

    [Theory]
    [InlineData(10, 110)]
    [InlineData(0, 100)]
    [InlineData(-10, 90)]
    public void AllowingPercentagesDynamicallyChange(double ammendPercentage,   double resultPercentage)
    {

        var marketManager = new MarketManagerJS(new FootballMarketGeneratorManager()); 
         
        var testResults = marketManager.AmendPercentage(ammendPercentage, _marketResults);

        Assert.Equal(resultPercentage,(int) testResults[0].Selections[0].Probability); 

    }




}

