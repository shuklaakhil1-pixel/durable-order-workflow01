using Microsoft.Azure.Functions.Worker;

public class ProcessPayment
{
    [Function("ProcessPayment")]
    public string Run([ActivityTrigger] OrderModel order)
    {
        return "Success";
    }
}
