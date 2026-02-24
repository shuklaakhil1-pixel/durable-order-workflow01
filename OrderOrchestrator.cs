using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

public class OrderOrchestrator
{
    [Function("OrderOrchestrator")]
    public async Task<string> Run(
        [OrchestrationTrigger] TaskOrchestrationContext context)
    {
        var order = context.GetInput<OrderModel>();

        string validation = await context.CallActivityAsync<string>("ValidateOrder", order);

        if (validation != "Valid")
            return "Order Rejected";

        string payment = await context.CallActivityAsync<string>("ProcessPayment", order);

        if (payment != "Success")
            return "Payment Failed";

        string inventory = await context.CallActivityAsync<string>("ReserveInventory", order);

        if (inventory != "Reserved")
            return "Inventory Not Available";

        await context.CallActivityAsync<string>("SendEmail", order);

        return "Order Completed Successfully";
    }
}
