using Courses.GraphQL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.GraphQL.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; } = default!;
}
