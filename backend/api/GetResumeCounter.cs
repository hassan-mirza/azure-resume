using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace HassanMirza.Resume
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"Resume", collectionName: "counter", Id = "1", ConnectionStringSetting = "HmResumeCosmosDb", PartitionKey = "1")] Item item,
            [CosmosDB(databaseName:"Resume", collectionName: "counter", Id = "1", ConnectionStringSetting = "HmResumeCosmosDb", PartitionKey = "1")] out Item updatedItem,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request. Current count: ${item.Count}");

            updatedItem = item;
            updatedItem.Count += 1;

            log.LogInformation($"New run count: ${updatedItem.Count} ");

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK){
                Content = new StringContent(JsonConvert.SerializeObject(updatedItem))
            };
        }
    }
}
