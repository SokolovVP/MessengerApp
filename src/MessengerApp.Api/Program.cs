using MessengerApp.Api.Common.Errors;
using MessengerApp.Application;
using MessengerApp.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, MessengerAppProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
   
    app.MapGet("/", () => Results.Ok(new { Text = "Hello world" }));

    app.Run();
}