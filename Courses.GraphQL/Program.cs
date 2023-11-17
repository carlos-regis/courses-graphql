using Courses.GraphQL.Configuration;
using GraphQL.Server;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .InstallServices(
        builder.Configuration,
        typeof(IServiceInstaller).Assembly)
    .AddGraphQL().AddSystemTextJson();

builder.Host
    .UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection()
   .UseRouting()
   .UseAuthorization();

app.MapControllers();

app.Run();
