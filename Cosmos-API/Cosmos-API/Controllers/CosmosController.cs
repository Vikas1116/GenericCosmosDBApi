using CosmosDbService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace New_Horizon_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        private readonly ICosmosApiClient _cosmosApiClient;
        private readonly ILogger<CosmosController> _logger;

        public CosmosController(ICosmosApiClient cosmosApiClient, ILogger<CosmosController> logger)
        {
            _cosmosApiClient = cosmosApiClient;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetItem")]
        public async Task<IActionResult> GetItemAsync([FromBody] Request request)
        {
            try
            {
                var result = await _cosmosApiClient.GetItemAsync(request.ContainerName);
                var strJson = JsonConvert.SerializeObject(result);
                return Ok(strJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in {nameof(GetItemAsync)}");
                return Ok(ex.Message);
            }
        }
    }
}
