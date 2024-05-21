using Microsoft.AspNetCore.Mvc;
using Sender.Actors;
using Sender.Infrastructure;

namespace Sender.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorFactory<IHighCardinalityActor> _actorFactory;

    public ActorController(IActorFactory<IHighCardinalityActor> actorFactory)
    {
        _actorFactory = actorFactory;
    }

    [HttpPost("actor-invocation")]
    public async Task ActorInvocation()
    {
        for (var i = 0; i < 10; i++)
        {
            var guid = Guid.NewGuid();

            var actor = _actorFactory.CreateActor(guid.ToString());
            await actor.InvokeActor();
        }
    }
}