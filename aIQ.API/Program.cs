using aIQ.Application.Features.Settings.ChangePassword;
using aIQ.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Endpoints
app.MapChangePasswordEndpoint();

app.Run();
