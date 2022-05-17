using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace fhhagenberg
{
    public static class HttpFlights
    {
        [FunctionName("HttpFlights")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "flight")] HttpRequest req,
            ILogger log)
        {
   
            return new OkObjectResult(Data.Flights);
        }

        [FunctionName("HttpFlightsById")]
        public static async Task<IActionResult> RunById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "flight/{Id}")] HttpRequest req,
            ILogger log, int Id)
        {
            var flight = Data.Flights.FirstOrDefault(f => f.Id == Id);

            return new OkObjectResult(flight);
        }
    }
}
