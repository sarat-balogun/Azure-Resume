using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Data.Common;
using Microsoft.Azure.Cosmos;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "Azureresume",
                containerName: "counter",
                Connection = "AzureResumeConnectionString",
                Id = "1",
                PartitionKey = "1")] Counter counter,
            [CosmosDB(
                databaseName: "Azureresume",
                containerName: "counter",
                Connection = "AzureResumeConnectionString",
                Id = "1",
                PartitionKey = "1")] IAsyncCollector<Counter> updatedCounter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Increment the count
            counter.Count++;

            // Update the counter in Cosmos DB
            await updatedCounter.AddAsync(counter);

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
