using SS.Interview.BettingPlatform.MarketGeneration.Models;
using System.Collections.Generic;

namespace SS.Interview.BettingPlatform.Interfaces     
{
    public interface IGameMarketGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixture"></param>
        /// <param name="dynamicPercentage"></param>
        /// <returns></returns>
        IEnumerable<Market> GetMarkets(string fixture);

     //   IEnumerable<Market> AmendPercentage(double dynamicPercentage, Market[] results);

    }
}