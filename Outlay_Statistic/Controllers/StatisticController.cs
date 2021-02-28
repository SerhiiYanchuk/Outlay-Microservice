using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Outlay_Statistic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "50", "15", "47", "68", "52", "10", "2", "4", "7", "6"
        };

        private readonly ILogger<StatisticController> _logger;

        public StatisticController(ILogger<StatisticController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5)
                            .Select(index => Summaries[rng.Next(Summaries.Length)]).ToArray();
        }
    }
}
