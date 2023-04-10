var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddDaprClient();
builder.Services.AddControllers().AddDapr();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDaprSidekick(builder.Configuration);
}

// Configure the HTTP request pipeline
var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();