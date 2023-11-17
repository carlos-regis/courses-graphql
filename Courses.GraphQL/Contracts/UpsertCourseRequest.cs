namespace Courses.GraphQL.Contracts;

public class UpsertCourseRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Review { get; set; }
}
