using Microsoft.Azure.Functions.Worker;

public class ValidateOrder
{
    [Function("ValidateOrder")]
    public string Run([ActivityTrigger] OrderModel order)
    {
        return order.Amount > 0 ? "Valid" : "Invalid";
    }
}
