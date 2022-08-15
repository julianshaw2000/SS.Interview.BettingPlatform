using SS.Interview.BettingPlatform.MarketGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Interview.BettingPlatform.Managers
{
    public class ProbabilityAssigner
    {
        private double probabilityChange;
        private IEnumerable<Market> results;

        public ProbabilityAssigner(double probabilityChange, IEnumerable<Market> results)
        {
            this.probabilityChange = probabilityChange;
            this.results = results;
        }

        //public IEnumerable<Market> Process(double probabilityChange, Market[] result)
        public IEnumerable<Market> ProcessResultList()
        {

            foreach (var market in results)
            {
                foreach (var item in market.Selections)
                {
                    item.Probability = ProbabilityModifier.CalculateProbability(probabilityChange, item.Probability);
                }
            }

            return results;
        }
    }
}
