using BuildingBlocks.Behaviors;
using JasperFx;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the container.
var assembly=typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviors<,>));

});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(options =>
{
    options.Connection("Host=localhost;Port=5432;Database=CatalogDb;Username=postgres;Password=postgres"); options.AutoCreateSchemaObjects=AutoCreate.All;

}).UseLightweightSessions();

var app = builder.Build();

//Configure the HTTP request pipeline.
app.MapCarter();

app.UseExceptionHandler(exceptionHanderApp =>
{
    exceptionHanderApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is null) return;

        var problemDetails = new ProblemDetails
        {
            Title=exception.Message,
            Status=StatusCodes.Status500InternalServerError,
            Detail=exception.StackTrace

        };
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception,exception.Message);
        context.Response.StatusCode = problemDetails.Status.Value;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);

    });
});
app.Run();
