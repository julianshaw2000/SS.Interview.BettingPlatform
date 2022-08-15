using System;
using System.Collections.Generic;
using System.Linq;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;


namespace SS.Interview.BettingPlatform.Managers
{
    public class MarketManagerSelector
    {

        MarketManagerJS MarketManagerJS;
        public Market[] Get(MarketRequest request)
        {

            Market[] marketResults = new Market[] { };

            switch (request.Sport)
            {
                case SportType.Football:

                    var marketManagerFootball = new MarketManagerJS(new FootballMarketGeneratorManager());
                    marketResults  = marketManagerFootball.AmendPercentage(2, marketManagerFootball.GetMarkets(request.Fixture));
                    break;

                case SportType.Tennis:

                    var marketManagerTennis = new MarketManagerJS(new TennisMarketGeneratorManager());
                    marketResults = marketManagerTennis.AmendPercentage(2, marketManagerTennis.GetMarkets(request.Fixture));
                    break;

                case SportType.Rugby:

                    var marketManagerRugby = new MarketManagerJS(new RugbyMarketGeneratorManager());
                    marketResults = marketManagerRugby.AmendPercentage(2, marketManagerRugby.GetMarkets(request.Fixture));
                    break;
                     
                case SportType.Not_Defined:
                    break;
                default:
                    break;

            }

            return marketResults;
        }
    }
}