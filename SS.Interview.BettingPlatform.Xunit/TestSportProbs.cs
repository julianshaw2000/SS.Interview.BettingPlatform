using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.Models;
using SS.Interview.BettingPlatform.Requests; 
using System.Xml.Linq;

namespace SS.Interview.BettingPlatform.Xunit
{
    public class TestSportProbs
    {
        [Fact]
       void  ReadValuesForSportProbabilities()
        {


            var filePath = @"c:\temp\probList.xml";
            XElement doc = XElement.Load(filePath);

            var result = from ed in doc.Descendants("Booker")

                         where  ed.Element("Sport").Value == "Football"
                         //where ed.Element("BookId").Value == "KFC" && ed.Element("Sport").Value == "Football"

                         select new SportProbabilityRecord
                         {                              

                             Sport = ed.Element("Sport").Value,

                             Probability = ed.Element("Probability").Value

                         };

            var record =result.FirstOrDefault();

            Assert.Equal("10", record.Probability );



        }





        [Fact]
        void ReadValuesForSportProbabilitiesFromProgram()
        {

            PercentageModifierManager testProg = new PercentageModifierManager();
            var result = testProg.GetXMLSettings(SportType.Football);

            Assert.Equal("10", result.Probability);


        }



        [Fact]
        void ReadValuesForSportProbabilitiesFromProgramTennis()
        {

            PercentageModifierManager testProg = new PercentageModifierManager();
            var result = testProg.GetXMLSettings(SportType.Tennis);

            Assert.Equal("8", result.Probability);


        }




    }
}
