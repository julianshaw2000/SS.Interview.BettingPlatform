using System;
using System.Collections.Generic;
using System.Linq;
using SS.Interview.BettingPlatform.Interfaces;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;
using static SS.Interview.BettingPlatform.Managers.FootballMarketGeneratorManager;

namespace SS.Interview.BettingPlatform.Managers
{
    public class MarketManagerSelector
    {
         
        public Market[] Get(MarketRequest request)
        { 
            var percentageModifierManager = new PercentageModifierManager();
            Market[] marketResults = new Market[] { }; 

            switch (request.Sport)
            {
                case SportType.Football:                     

                    marketResults = CalculateResults(request, percentageModifierManager, new FootballMarketGeneratorManager(), 2);
                    break;

                case SportType.Tennis:

                    marketResults = CalculateResults(request, percentageModifierManager, new TennisMarketGeneratorManager(), -3);
                    break;

                case SportType.Rugby:

                    marketResults = CalculateResults(request, percentageModifierManager, new RugbyMarketGeneratorManager(), 0);

                    break;
                     
                case SportType.Not_Defined:
                    break;
                default:
                    break;

            }

            return marketResults;
        }

        private static Market[] CalculateResults(MarketRequest request, 
            PercentageModifierManager percentageModifierManager, 
            IGameMarketGenerator gameGenerator, 
            int gameProbabilityChange)
        {
            Market[] marketResults;
            var marketManager = new MarketManagerJS(gameGenerator);
           // var gameType = gameGenerator.GetType().ToString();

            percentageModifierManager.ProbabilityDictionaryAdder( request.Sport,  gameProbabilityChange);
            marketResults = marketManager.GetMarkets(request.Fixture);
            marketResults = percentageModifierManager.UpdateProbability(request.Sport, marketResults);

            return marketResults;
        }
    }
}