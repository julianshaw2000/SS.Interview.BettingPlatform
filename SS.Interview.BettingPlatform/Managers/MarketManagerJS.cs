using SS.Interview.BettingPlatform.Interfaces;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Interview.BettingPlatform.Managers
{
    public class MarketManagerJS
    { 
        private readonly IGameMarketGenerator _gameMarketGenerator; 

        public MarketManagerJS(IGameMarketGenerator gameMarketGenerator )
        {      
            _gameMarketGenerator = gameMarketGenerator;             
        }

        public Market[] GetMarkets(string fix)
        {
            var result = _gameMarketGenerator.GetMarkets(fix).ToArray();
            return result; 
        }
         
         
    }
}
