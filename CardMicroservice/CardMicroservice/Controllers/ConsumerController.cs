using CardMicroservice.UoW;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using CardMicroservice.Models;
using Newtonsoft.Json;

namespace CardMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumerController : ControllerBase
    {
        private readonly string topic = "users_topic";
        private readonly IUnitOfWork _unitOfWork;
        public ConsumerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "st_consumer_group",
                BootstrapServers = "kafka:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var builder = new ConsumerBuilder<Ignore,string>(conf).Build())
            {
                builder.Subscribe(topic);
                try
                {

                    var user = builder.Consume();
                    var serializedUser = JsonConvert.DeserializeObject<User>(user.Message.Value);
                    if (serializedUser != null)
                    {
                        _unitOfWork.Users.Add(serializedUser);
                        _unitOfWork.Save();
                        return new OkObjectResult("Good )))");
                    }                      
                    //Console.WriteLine($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
                }
                catch (Exception)
                {
                    builder.Close();
                }
            }
            return new OkObjectResult("Not (((");
        }

    }
}
