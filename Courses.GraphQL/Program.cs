using Courses.GraphQL.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .InstallServices(
        builder.Configuration,
        typeof(IServiceInstaller).Assembly);

builder.Host
    .UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger()
       .UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error")
       .UseHsts();
}

app.UseHttpsRedirection()
   .UseRouting()
   .UseAuthorization();

app.MapControllers();

app.Run();
