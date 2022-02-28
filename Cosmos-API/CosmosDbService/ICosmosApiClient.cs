namespace CosmosDbService
{
    public interface ICosmosApiClient
    {
        Task<object> GetItemAsync(string containerName);
    }
}
