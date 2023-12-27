namespace Sender.Services;

public interface IServiceInvocationService
{
    Task InvokeAsync();

    Task InvokeDynamicPathAsync();

    Task InvokeMultipleAsync();
}