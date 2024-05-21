using Dapr.Actors;

namespace Sender.Actors;

public interface IHighCardinalityActor : IActor
{
    Task InvokeActor();
}