using System;

using SS.Interview.BettingPlatform.MarketGeneration.Models;
 

namespace SS.Interview.BettingPlatform.MarketGeneration.Generators
{
    public class RugbyMarketGenerator 
    {
        /// <summary>
        /// Initializes a new instance to generate markets for Rugby fixtures
        /// </summary>
        public RugbyMarketGenerator()
        {

        }

        /// <summary>
        /// Get markets for a specified Rugby fixture
        /// </summary>
        /// <param name="fixture">
        /// The fixture identifier
        /// </param>
        /// <returns>
        /// An array containing the resulting markets
        /// </returns>
        public Market[] GetMarkets(string fixture)
        {
            var market1Probs = ProbabilityGenerator.Generate(3);
            var market2Probs = ProbabilityGenerator.Generate(5);

            return new[]
            {
                new Market
                {
                    Id = string.Concat(fixture, " - Match Winner"),
                    Selections = new []
                    {
                        new Selection{ Id = "Hull F.C.", Probability = market1Probs[0] },
                        new Selection{ Id = "Draw", Probability = market1Probs[1] },
                        new Selection{ Id = "Leeds.", Probability = market1Probs[2] },
                    }
                },
                new Market
                {
                    Id = string.Concat(fixture, " - Final Score"),
                    Selections = new []
                    {
                        new Selection{ Id = "1-0", Probability = market2Probs[0] },
                        new Selection{ Id = "1-1", Probability = market2Probs[1] },
                        new Selection{ Id = "2-1", Probability = market2Probs[2] },
                        new Selection{ Id = "2-2", Probability = market2Probs[3] },
                        new Selection{ Id = "3-2", Probability = market2Probs[4] },
                    }
                }
            };
        }
    }
}
