using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SS.Interview.BettingPlatform.Requests;

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

    [Theory(Skip="Rubish")]
    [InlineData(10, 110)]
    [InlineData(0, 100)]
    [InlineData(-10, 90)]
    public void AllowingPercentagesDynamicallyChangeRubish(double ammendPercentage,   double resultPercentage)
    {
        PercentageDictStorer.ProbDict_Add(SportType.Tennis, 10);
        PercentageDictStorer.ProbDict_Add(SportType.Football, 20);


        var percentageModifierManager = new PercentageModifierManager(); 

        var marketManager = new MarketManagerJS(new FootballMarketGeneratorManager());
        var testResults = marketManager.GetMarkets("audi");

        Assert.Equal(resultPercentage,(int) testResults[0].Selections[0].Probability); 

    }

    [Theory]
    [InlineData(SportType.Football, 10, 10)]
    [InlineData( SportType.Tennis, 0, 0)] 
    public void AllowingPercentagesDynamicallyChange(SportType sportType, double ammendPercentage, double resultPercentage)
    {
        PercentageDictStorer.ProbDict_Add( sportType, ammendPercentage);

        var percentDictValue = PercentageDictStorer.ProbDict[sportType];

        Assert.Equal(percentDictValue, resultPercentage);

    }





}

