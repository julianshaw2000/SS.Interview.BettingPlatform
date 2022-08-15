using SS.Interview.BettingPlatform.MarketGeneration.Models;
using System.Collections.Generic;

namespace SS.Interview.BettingPlatform.Interfaces     
{
    public interface IGameMarketGenerator
    {
        IEnumerable<Market> GetMarkets(string fixture, double dynamicPercentage=0);

        IEnumerable<Market> AmendPercentage(double dynamicPercentage, Market[] results);

    }
}