using Sender.Actors;
using Sender.Infrastructure;
using Sender.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddDaprClient();
builder.Services.AddControllers().AddDapr();

builder.Services.AddTransient<IServiceInvocationService, ServiceInvocationService>();
builder.Services.AddTransient<IActorFactory<IHighCardinalityActor>, ActorFactory<IHighCardinalityActor>>();

builder.Services.AddActors(actors =>
{
    actors.Actors.RegisterActor<HighCardinalityActor>();
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDaprSidekick(builder.Configuration);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapActorsHandlers();
});

app.Run();