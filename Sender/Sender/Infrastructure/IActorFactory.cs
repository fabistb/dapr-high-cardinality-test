namespace Sender.Infrastructure;

public interface IActorFactory<TActor>
{
    TActor CreateActor(string actorId);
}