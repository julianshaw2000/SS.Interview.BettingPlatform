using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Models;
using SS.Interview.BettingPlatform.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Interview.BettingPlatform.Interfaces
{
    public interface IPercentageModifierManager
    {
        Market[] UpdateProbability(SportType sportType, Market[] marketResult);

        SportProbabilityRecord GetXMLSettings(SportType sport);
    }
}
