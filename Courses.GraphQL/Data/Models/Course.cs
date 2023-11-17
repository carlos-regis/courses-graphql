using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.GraphQL.Data.Models;

[Table("course")]
public class Course
{
    [Key]
    [Column("id")]
    public int Id { get; internal set; }
    [Column("name")]
    public string Name { get; internal set; } = default!;
    [Column("description")]
    public string Description { get; internal set; } = default!;
    [Column("review")]
    public int Review { get; internal set; }
    [Column("date_added")]
    public DateTime DateAdded { get; internal set; }
    [Column("date_updated")]
    public DateTime DateUpdated { get; internal set; }
}
