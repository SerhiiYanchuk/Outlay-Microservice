using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CardMicroservice.Models;
using Newtonsoft.Json;

namespace ProducerMicroservice.Controllers
{
    [Route("api/kafka")]
    [ApiController]
    public class KafkaProducerController : ControllerBase
    {
        private readonly ProducerConfig config = new ProducerConfig
                                { BootstrapServers = "kafka:9092"};
        private readonly string topic = "users_topic";

        // [HttpGet]
        // public IActionResult Get()
        // {
        //     return Created(string.Empty, SendToKafka(topic, "omg"));
        // }
        // private Object SendToKafka(string topic, string message)
        // {
        //     using (var producer =
        //          new ProducerBuilder<Null, string>(config).Build())
        //     {
        //         try
        //         {
        //             return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
        //                 .GetAwaiter()
        //                 .GetResult();
        //             //producer.Produce(topic, new Message<Null, string> { Value = message });
        //         }
        //         catch (Exception e)
        //         {
        //             return $"Oops, something went wrong: {e}";
        //         }
        //     }          
        // }
        
        // localhost/api/kafka?Login= ,Password= ,Name= ,Surname= ,Age=
        [HttpPost]
        public Object Post(User user)
        {
            string serializedUser = JsonConvert.SerializeObject(user);
            
            using (var producer =
                 new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                  
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedUser })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    return $"Oops, something went wrong: {e}";
                }
            }
        }
    }
}
