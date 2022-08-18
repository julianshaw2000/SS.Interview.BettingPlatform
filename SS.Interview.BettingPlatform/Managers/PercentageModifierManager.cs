using SS.Interview.BettingPlatform.Interfaces; 
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Models;
using SS.Interview.BettingPlatform.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SS.Interview.BettingPlatform.Managers
{
    public class PercentageModifierManager : IPercentageModifierManager
    {
        public Market[] UpdateProbability(SportType sportType, Market[] marketResult)
        {
            var probabilityPercentChange = PercentageDictStorer.GetProbabilities(sportType);
            var probabilityAssigner = new ProbabilityAssigner(probabilityPercentChange, marketResult);
            return probabilityAssigner.ProcessResultList().ToArray();
        }


        public void ProbabilityDictionaryAdder( SportType sportType,  double ProbabiltyPercentage)
        {
            PercentageDictStorer.ProbDict_Add( sportType,  ProbabiltyPercentage);
        }

        public SportProbabilityRecord GetXMLSettings(SportType sport)
        {

            var filePath = @"c:\temp\probList.xml";

            XElement doc = XElement.Load(filePath);


            var result = from ed in doc.Descendants("Booker")

                         where   ed.Element("Sport").Value == sport.ToString()

                         select new SportProbabilityRecord
                         {                              

                             Sport = ed.Element("Sport").Value,

                             Probability = ed.Element("Probability").Value

                         };

            return result.FirstOrDefault();




        }
         
    }
}
