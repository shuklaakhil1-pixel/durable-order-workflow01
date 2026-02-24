using Microsoft.Azure.Functions.Worker;

public class SendEmail
{
    [Function("SendEmail")]
    public string Run([ActivityTrigger] OrderModel order)
    {
        return "Email Sent";
    }
}
