using System.ComponentModel.DataAnnotations;

namespace Courses.GraphQL.Data.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Review { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateUpdated { get; set; }
}
