using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Extensions.DurableTask;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker =>
    {
        worker.AddDurableTask();
    })
    .Build();

host.Run();
