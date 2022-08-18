using Moq;
using SS.Interview.BettingPlatform.Interfaces;
using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SS.Interview.BettingPlatform.Managers.FootballMarketGeneratorManager;

namespace SS.Interview.BettingPlatform.Xunit
{
    public class TestUserStory2
    {

        private  Mock<IGameMarketGenerator> _gameMarketGeneratorMoq;
        private  Market[] _marketResults;

        public TestUserStory2()
        {
            _marketResults = new[]
            {
                new Market
                {
                    Id = string.Concat("Arsenal - Man U", " - Match Winner"),
                    Selections = new []
                    {
                        new Selection{ Id = "Manchester United", Probability = 2.2 },
                        new Selection{ Id = "Draw", Probability = 1.1 },
                        new Selection{ Id = "Arsenal", Probability = 3.3 },
                    }
                }
            };


        }

        [Fact]
        public void ValidateSportRepositoryGetMarkets()
        {             

            _gameMarketGeneratorMoq = new Mock<IGameMarketGenerator>();

            _gameMarketGeneratorMoq
                .Setup(x => x.GetMarkets(It.IsAny<string>()))
                .Returns(_marketResults);

            var marketManager = new MarketManagerJS(_gameMarketGeneratorMoq.Object);
            var fixture = "Game fixture Id";

            Market[] testResults = marketManager.GetMarkets(fixture);

            Assert.Equal(testResults[0].Id, _marketResults[0].Id);

        }

        [Fact]
        public void AddSportRepositoryFootball()
        { 

            var marketManager = new MarketManagerJS(new FootballMarketGeneratorManager());


            var fixture = "Arsenal - Man U - Match Winner";

            Market[] testResults = marketManager.GetMarkets(fixture);

            Assert.Contains("Man U", testResults[0].Id );
            Assert.Contains("Manchester United", testResults[0].Selections[0].Id);
            Assert.Contains("Draw", testResults[0].Selections[1].Id);

        }

        [Fact]
        public void AddSportRepositoryRugby()
        { 

            var marketManager = new MarketManagerJS(new RugbyMarketGeneratorManager());
            var fixture = "Hull vs Leeds";

            Market[] testResults = marketManager.GetMarkets(fixture);

            Assert.Contains("Hull", testResults[0].Id);

        }

        [Fact]
        public void AddSportRepositoryTennis()
        {
             
            var marketManager = new MarketManagerJS(new TennisMarketGeneratorManager());
            var fixture = "Nadal vs Murray";

            var testResults = marketManager.GetMarkets(fixture).ToList();

            Assert.Contains("Rafael Nadal", testResults[0].Selections[0].Id);
            Assert.Contains("Andy Murray", testResults[0].Selections[1].Id);

        }
    }
}
