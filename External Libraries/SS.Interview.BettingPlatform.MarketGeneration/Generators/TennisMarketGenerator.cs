using System.Collections.Generic;
using SS.Interview.BettingPlatform.MarketGeneration.Models;

namespace SS.Interview.BettingPlatform.MarketGeneration.Generators
{
    /// <summary>
    /// Generates markets for tennis fixtures
    /// </summary>
    public class TennisMarketGenerator
    {
        /// <summary>
        /// Initializes a new instance to generate markets for tennis fixtures
        /// </summary>
        public TennisMarketGenerator()
        {

        }
        /// <summary>
        /// Get markets for a specified tennis fixture
        /// </summary>
        /// <param name="fixture">
        /// The fixture identifier
        /// </param>
        /// <returns>
        /// A set containing the resulting markets
        /// </returns>
        public ISet<Market> GetMarkets(string fixture)
        {
            var market1Probs = ProbabilityGenerator.Generate(2);
            var market2Probs = ProbabilityGenerator.Generate(2);
            var market3Probs = ProbabilityGenerator.Generate(2);
            var market4Probs = ProbabilityGenerator.Generate(3);

            return new HashSet<Market>
            {
                new Market
                { 
                    Id = string.Concat(fixture, " - 1st Set Winner"),
                    Selections = new [] 
                    { 
                        new Selection{ Id = "Rafael Nadal", Probability = market1Probs[0] },
                        new Selection{ Id = "Andy Murray", Probability = market1Probs[1] },
                    }
                },
                new Market
                { 
                    Id = string.Concat(fixture, " - 2nd Set Winner"),
                    Selections = new [] 
                    { 
                        new Selection{ Id = "Rafael Nadal", Probability = market2Probs[0] },
                        new Selection{ Id = "Andy Murray", Probability = market2Probs[1] },
                    }
                },
                new Market
                { 
                    Id = string.Concat(fixture, " - 3rd Set Winner"),
                    Selections = new [] 
                    { 
                        new Selection{ Id = "Rafael Nadal", Probability = market3Probs[0] },
                        new Selection{ Id = "Andy Murray", Probability = market3Probs[1] },
                    }
                },
                new Market
                { 
                    Id =  string.Concat(fixture, " - Total Sets"),
                    Selections = new [] 
                    { 
                        new Selection{ Id = "3", Probability = market4Probs[0] },
                        new Selection{ Id = "4", Probability = market4Probs[1] },
                        new Selection{ Id = "5", Probability = market4Probs[2] },
                    }
                }
            };
        }
    }
}
