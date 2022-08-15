using SS.Interview.BettingPlatform.Interfaces;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using System.Collections.Generic;
using System.Linq;

namespace SS.Interview.BettingPlatform.Managers
{


    public class FootballMarketGeneratorManager : FootballMarketGenerator, IGameMarketGenerator
    {

        // ============  F O O T B A L L ============
        public FootballMarketGeneratorManager(): base()
        {

        }

        public IEnumerable<Market> GetMarkets(string fixture, double dynamicPercentage)
        {
            var probabilityChange = dynamicPercentage;


            var results =  base.GetMarkets(fixture);

            var amendedResults = AmendPercentage(probabilityChange, results);

            return amendedResults;
             

        }

        public IEnumerable<Market> AmendPercentage( double dynamicPercentage, Market[] results)
        {
            var probabilityChange = dynamicPercentage;
             
            var probabilityAmendnender = new ProbabilityAssigner(probabilityChange, results);

            return probabilityAmendnender.ProcessResultList();

        }

    }


    // ========================  T E N N I S ====================
    public class TennisMarketGeneratorManager : TennisMarketGenerator, IGameMarketGenerator
    {
        public TennisMarketGeneratorManager() : base()
        {

        }

        public IEnumerable<Market> GetMarkets(string fixture, double dynamicPercentage)
        {
            var probabilityChange = dynamicPercentage;


            var results = base.GetMarkets(fixture).ToArray();

            var amendedResults = AmendPercentage(probabilityChange, results);

            return amendedResults;


        }

        public IEnumerable<Market> AmendPercentage(double dynamicPercentage, Market[] results)
        {
            var probabilityChange = dynamicPercentage;

            var probabilityAmendnender = new ProbabilityAssigner(probabilityChange, results);

            return probabilityAmendnender.ProcessResultList();

        }

    }


    // =======================  R U G B Y ============================
    public class RugbyMarketGeneratorManager : RugbyMarketGenerator, IGameMarketGenerator
    {
        public RugbyMarketGeneratorManager() : base()
        {

        }

        public IEnumerable<Market> GetMarkets(string fixture, double dynamicPercentage)
        {
            var probabilityChange = dynamicPercentage;


            var results = base.GetMarkets(fixture);

            var amendedResults = AmendPercentage(probabilityChange, results);

            return amendedResults;


        }

        public IEnumerable<Market> AmendPercentage(double dynamicPercentage, Market[] results)
        {
            var probabilityChange = dynamicPercentage;

            var probabilityAmendnender = new ProbabilityAssigner(probabilityChange, results);

            return probabilityAmendnender.ProcessResultList();

        }

    }
}
