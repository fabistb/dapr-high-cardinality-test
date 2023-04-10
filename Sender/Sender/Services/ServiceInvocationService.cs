using Dapr.Client;

namespace Sender.Services;

public class ServiceInvocationService : IServiceInvocationService
{
    private readonly DaprClient _daprClient;

    public ServiceInvocationService(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task InvokeAsync()
    {
        for (var i = 0; i < 100; i++)
        {
            var number = i.ToString();
            var request = _daprClient.CreateInvokeMethodRequest(HttpMethod.Post, "receiver", $"api/Receive/{number}");
            var response = await _daprClient.InvokeMethodWithResponseAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Invalid response");
            }
        }
    }
}