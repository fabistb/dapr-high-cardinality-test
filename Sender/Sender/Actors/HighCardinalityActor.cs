using Dapr.Actors.Runtime;

namespace Sender.Actors;

public class HighCardinalityActor : Actor, IHighCardinalityActor
{
    public HighCardinalityActor(ActorHost host) 
        : base(host)
    {
    }

    public async Task InvokeActor()
    {
        return;
    }
}