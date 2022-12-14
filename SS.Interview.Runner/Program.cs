using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;


Console.WriteLine("Select Game (f=footbal, t=tennis) or x to exit");

var answer = "";
var marketManager = new MarketManagerSelector();
var markets = new List<Market>();

do
{

    answer = Console.ReadLine();
    if (answer.ToUpper() != "X")
    {
        var marketResults = DoGame(answer.ToUpper());
        WriteGame(marketResults);
    }
}
while (answer.ToUpper() != "X");



// =================  DoGame  ===============
List<Market> DoGame(string answer)
{
    Console.WriteLine(answer);

    SportType sport = SportType.Not_Defined;
    var fixture = "";

    switch (answer)
    {
        case "F":
            sport = SportType.Football;
            fixture = "Arsenal vs Manchester United";
            break;
        case "T":
            sport = SportType.Tennis;
            fixture = "Nadal vs Murray";
            break;
        case "R":
            sport = SportType.Rugby;
            fixture = "Hull  vs Croydon";
            break;
        default:
            sport = SportType.Not_Defined;
            break;
    }

    if (sport != SportType.Not_Defined)
    {
        var marketRequest = new MarketRequest() { Sport = sport, Fixture = fixture };
        markets = marketManager.Get(marketRequest).ToList();
    }

    return markets;
}

// ========== Write Game  ==============

void WriteGame(List<Market> marketRequest)
{
    foreach (Market market in marketRequest)
    {
        var lineNum = 1;
        Console.WriteLine("");
        Console.WriteLine(market.Id);
        foreach (var selection in market.Selections)
        {
            Console.Write($" - {lineNum++}: {selection.Id}");
            Console.WriteLine($" : {selection.Probability}");
        }
    }
}