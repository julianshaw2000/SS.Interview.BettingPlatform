using System;
using System.Text; 
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

Console.WriteLine("Consumer started");

channel.QueueDeclare(queue: "letterbox", durable: false, exclusive: false, autoDelete: false, arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);


    var probDict = System.Text.Json.JsonSerializer.Deserialize<List<ProbRecord>>(message);

    foreach (var item in probDict.TakeLast(4))
    {
        Console.WriteLine("Sport:{0}  Probability:{1}  Date:{2}", item.Name, item.Prob, item.UpdateTime);
    }
   // Console.WriteLine(" Sent message: {0}", message);
    Console.WriteLine("          ========================================================");
    Console.WriteLine("");

};

channel.BasicConsume(queue: "letterbox", autoAck: true, consumer: consumer);

Console.ReadKey();


public class ProbRecord
{
    public string Name { get; set; }
    public double Prob { get; set; }
    public DateTime UpdateTime { get; set; }
}
