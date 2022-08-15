using System;
using System.Linq;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;

namespace SS.Interview.BettingPlatform.Managers
{
    public class MarketManager
    {
        public Market[] Get(MarketRequest request)
        {
            Market[] markets;

            if (request.Sport == SportType.Football)
            {
                var footballGen = new FootballMarketGenerator();
                return footballGen.GetMarkets(request.Fixture);
            }
            else if (request.Sport == SportType.Tennis)
            {
                var tennisGen = new TennisMarketGenerator();
                return tennisGen.GetMarkets(request.Fixture).ToArray(); 
            }
            else
            {
                throw new ArgumentNullException($" The sport: { (SportType) request.Sport}, has not been implemented ");
            }

            return markets;
        }
    }
}