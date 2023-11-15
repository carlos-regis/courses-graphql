namespace Courses.GraphQL.Configuration;

public static class SwaggerConfiguration
{
    public static WebApplication ConfigureSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
              c.SwaggerEndpoint("v1/swagger.json", "Courses.GraphQL v1"));

        return app;
    }
}
