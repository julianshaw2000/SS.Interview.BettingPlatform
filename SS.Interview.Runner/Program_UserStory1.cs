// See https://aka.ms/new-console-template for more information
using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;


Console.WriteLine("Select Game (f=footbal, t=tenis) or x to exit");

var answer = "";
var marketManager = new MarketManager();
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
        case "H":
            sport = SportType.Hockey;
            fixture = "Denmark vs India";
            break;
        default:
            break;
    }

    var marketRequest = new MarketRequest() { Sport = sport, Fixture = fixture };
    markets = marketManager.Get(marketRequest).ToList();

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