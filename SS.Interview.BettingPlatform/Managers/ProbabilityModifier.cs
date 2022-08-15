using SS.Interview.BettingPlatform.MarketGeneration.Models; 
using System.Collections.Generic; 

namespace SS.Interview.BettingPlatform.Managers
{
    public static class ProbabilityModifier
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="probabilityChange" description="value to increase or decrease calculated probabilityCalculated"></param>
        /// <param name="probabilityCalculated" description="calculated probabilyt"></param>
        /// <returns></returns>
        public static double CalculateProbability(double probabilityChange, double probabilityCalculated)
        {
            var _productivityValue = 1 + probabilityChange / 100;

            return probabilityCalculated * _productivityValue;
        }
    }
}
