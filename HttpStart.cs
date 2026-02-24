using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;
using System.Net;

public class HttpStart
{
    [Function("HttpStart")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
        [DurableClient] DurableTaskClient client)
    {
        var order = await req.ReadFromJsonAsync<OrderModel>();

        string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
            "OrderOrchestrator", order);

        var response = req.CreateResponse(HttpStatusCode.Accepted);
        await response.WriteStringAsync($"Started orchestration with ID = '{instanceId}'.");

        return response;
    }
}
