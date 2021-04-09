using CardMicroservice.Models;
using CardMicroservice.UoW;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace CardMicroservice.Handlers
{
    // public class KafkaConsumerHandler : IHostedService
    // {
    //     private readonly string topic = "users_topic";
    //     private readonly IUnitOfWork _unitOfWork;
    //     public KafkaConsumerHandler(IUnitOfWork unitOfWork)
    //     {
    //         _unitOfWork = unitOfWork;
    //     }
    //     public Task StartAsync(CancellationToken cancellationToken)
    //     {
    //         var conf = new ConsumerConfig
    //         {
    //             GroupId = "st_consumer_group",
    //             BootstrapServers = "kafka:9092",
    //             AutoOffsetReset = AutoOffsetReset.Earliest
    //         };

    //         using (var builder = new ConsumerBuilder<Ignore,string>(conf).Build())
    //         {
    //             builder.Subscribe(topic);
    //             var cancelToken = new CancellationTokenSource();
    //             try
    //             {
    //                 while (true)
    //                 {
    //                     var user = builder.Consume(cancelToken.Token);
    //                     var serializedUser = JsonConvert.DeserializeObject<User>(user.Message.Value);
    //                     if (serializedUser != null)
    //                         _unitOfWork.Users.Add(serializedUser);
    //                     //Console.WriteLine($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
    //                 }
    //             }
    //             catch (Exception)
    //             {
    //                 builder.Close();
    //             }
    //         }
    //         return Task.CompletedTask;
    //     }
    //     public Task StopAsync(CancellationToken cancellationToken)
    //     {
    //         return Task.CompletedTask;
    //     }
    // }
}
