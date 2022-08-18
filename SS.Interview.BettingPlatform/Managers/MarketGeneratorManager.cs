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
        public FootballMarketGeneratorManager() : base()
        {

        }

        public IEnumerable<Market> GetMarkets(string fixture)
        { 

            var results = base.GetMarkets(fixture);
             

            return results;

        }

       


        // ========================  T E N N I S ====================
        public class TennisMarketGeneratorManager : TennisMarketGenerator, IGameMarketGenerator //, IPercentageModifierManage
        {
            public TennisMarketGeneratorManager() : base()
            {

            }

            public IEnumerable<Market> GetMarkets(string fixture)
            { 


                var results = base.GetMarkets(fixture).ToArray(); 

                return results;


            } 

        }


        // =======================  R U G B Y ============================
        public class RugbyMarketGeneratorManager : RugbyMarketGenerator, IGameMarketGenerator
        {
            public RugbyMarketGeneratorManager() : base()
            {

            }

            public IEnumerable<Market> GetMarkets(string fixture)
            {
                

                var results = base.GetMarkets(fixture);
                 

                return results;


            }
             

        }
    }
}