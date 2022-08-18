using SS.Interview.BettingPlatform.Interfaces;
using SS.Interview.BettingPlatform.Models;
using SS.Interview.BettingPlatform.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Interview.BettingPlatform.Managers
{
    public   class PercentageDictStorer 
    {
        
        public static Dictionary<SportType, double> ProbDict { get; set; } = new Dictionary<SportType, double>();
        public static Dictionary<SportType, double> GetProbabilities()
        {
             return ProbDict;
        }

        internal static double GetProbabilities(SportType sportType)
        {
            var  dictRecord =  ProbDict.FirstOrDefault(x => x.Key == sportType);
            return dictRecord.Value;
        }

        public static void ProbDict_Add(SportType sportType,  double Probability )
        {
            bool keyExists = ProbDict.ContainsKey(sportType);
            if(keyExists)
                ProbDict[sportType] = Probability;
            else
                ProbDict.Add(sportType, Probability);
        }
    }

    
}
 