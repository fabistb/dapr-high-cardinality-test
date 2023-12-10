namespace Sender.Services;

public interface IServiceInvocationService
{
    Task InvokeAsync();

    Task InvokeDynamicPathAsync();
}