using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;

namespace CosmosDbService
{
    public class CosmosApiClient : ICosmosApiClient
    {
        private readonly CosmosClient _cosmosClient;
        private readonly ILogger<CosmosApiClient> _logger;

        public CosmosApiClient(CosmosClient cosmosClient, ILogger<CosmosApiClient> logger)
        {
            _cosmosClient = cosmosClient;
            _logger = logger;
        }

        public async Task<object> GetItemAsync(string containerName)
        {
            _logger.LogInformation("{0} method started execution", "GetItemAsync");
            var container = GetContainer("scrapeddata", containerName);

            var result = container.GetItemLinqQueryable<dynamic>(true)
                                   .AsEnumerable()
                                   .FirstOrDefault();

            return await Task.FromResult(result);
        }

        private Container GetContainer(string databaseName, string containerName)
        {
            _logger.LogInformation("{0} method started execution with DBName: {1}, ContainerName: {2}", "GetContainer", databaseName, containerName);
            return _cosmosClient.GetContainer(databaseName, containerName);
        }
    }
}
