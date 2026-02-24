using Microsoft.Azure.Functions.Worker;

public class ReserveInventory
{
    [Function("ReserveInventory")]
    public string Run([ActivityTrigger] OrderModel order)
    {
        return "Reserved";
    }
}
