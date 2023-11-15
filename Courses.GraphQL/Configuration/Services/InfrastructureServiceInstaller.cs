using Courses.GraphQL.Data;
using Courses.GraphQL.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.GraphQL.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Database")));
        services.AddScoped<CoursesRepository>();
    }
}
