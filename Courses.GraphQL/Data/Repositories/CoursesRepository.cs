using Courses.GraphQL.Contracts;
using Courses.GraphQL.Data.Models;

namespace Courses.GraphQL.Data.Repositories;

public class CoursesRepository
{
    private readonly AppDbContext _context;
    public CoursesRepository(AppDbContext context) => _context = context;

    public IList<Course> GetAllCourses() => _context.Courses.ToList();

    public Course? GetCourseById(int id) => _context.Courses.FirstOrDefault(n => n.Id == id);
    public Course AddCourse(UpsertCourseRequest upsertCourseRequest)
    {
        ArgumentNullException.ThrowIfNull(upsertCourseRequest);

        var course = new Course
        {
            Name = upsertCourseRequest.Name,
            Description = upsertCourseRequest.Description,
            Review = upsertCourseRequest.Review
        };

        course.Name = upsertCourseRequest.Name;
        course.Description = upsertCourseRequest.Description;
        course.Review = upsertCourseRequest.Review;

        _context.Courses.Add(course);
        _context.SaveChanges();
        return course;
    }

    public Course UpdateCourse(int id, UpsertCourseRequest upsertCourseRequest)
    {
        ArgumentNullException.ThrowIfNull(upsertCourseRequest);

        var course = _context.Courses.FirstOrDefault(n => n.Id == id);

        if (course is null)
        {
            return default!;
        }

        course.Name = upsertCourseRequest.Name;
        course.Description = upsertCourseRequest.Description;
        course.Review = upsertCourseRequest.Review;

        _context.SaveChanges();

        return course;
    }

    public void DeleteCourse(int id)
    {
        var course = _context.Courses.FirstOrDefault(n => n.Id == id);

        if (course is null)
        {
            return;
        }

        _context.Courses.Remove(course);
        _context.SaveChanges();
    }
}
