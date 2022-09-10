// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var consumet = new EventingBasicConsumer(channel);
consumet.Received += Consumer_Revieved;

//channel.QueueDeclare("test",true,autoDelete:false);
channel.BasicConsume("test", true, consumet);

Console.ReadLine();

void Consumer_Revieved(object? sender, BasicDeliverEventArgs e)
{
    string message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine(message);

}