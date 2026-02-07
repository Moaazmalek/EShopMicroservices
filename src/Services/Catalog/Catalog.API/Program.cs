using BuildingBlocks.Behaviors;
using JasperFx;

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

app.Run();
