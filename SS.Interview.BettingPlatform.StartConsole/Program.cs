using System;
using System.Text;
using System.Collections.Generic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;
using SS.Interview.BettingPlatform.Managers;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

Console.WriteLine("Consumer started");

List<ProbRecord> probRecords = new List<ProbRecord>();

var marketManager = new MarketManagerSelector();
var markets = new List<Market>();

channel.QueueDeclare(queue: "letterbox", durable: false, exclusive: false, autoDelete: false, arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);


    probRecords = System.Text.Json.JsonSerializer.Deserialize<List<ProbRecord>>(message);

    foreach (var item in probRecords)
    {
        Console.WriteLine("{0} {1} {2}", item.Name, item.Prob, item.UpdateTime);
    }

    Console.WriteLine(" Received message: {0}", message);
};

channel.BasicConsume(queue: "letterbox", autoAck: true, consumer: consumer);


var answer = "f";

do
{
    Console.WriteLine("Select Game (f=footbal, t=tenis) or x to exit");

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



public class ProbRecord
{
    public string Name { get; set; }
    public double Prob { get; set; }
    public DateTime UpdateTime { get; set; }
}
