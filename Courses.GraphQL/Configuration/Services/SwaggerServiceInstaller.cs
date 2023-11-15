namespace Courses.GraphQL.Configuration;

public class SwaggerServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
            => services.AddSwaggerGen(c
                => c.SwaggerDoc(
                   "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Courses.GraphQL",
                        Version = "v1"
                    }));
}
