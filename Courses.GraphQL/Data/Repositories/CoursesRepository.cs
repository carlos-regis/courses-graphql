using Courses.GraphQL.Data.Models;

namespace Courses.GraphQL.Data.Repositories;

public class CoursesRepository
{
    private readonly AppDbContext _context;
    public CoursesRepository(AppDbContext context) => _context = context;

    public IList<Course> GetAllCourses() => _context.Courses.ToList();

    public Course? GetCourseById(int id) => _context.Courses.FirstOrDefault(n => n.Id == id);
    public Course AddCourse(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return course;
    }

    public Course UpdateCourse(int id, Course course)
    {
        ArgumentNullException.ThrowIfNull(course);

        var _course = _context.Courses.FirstOrDefault(n => n.Id == id);

        if (_course == null)
        {
            return default!;
        }

        _course.Name = course.Name;
        _course.Description = course.Description;
        _course.Review = course.Review;
        _course.DateUpdated = DateTime.Now;

        _context.SaveChanges();

        return course;
    }

    public void DeleteCourse(int id)
    {
        var course = _context.Courses.FirstOrDefault(n => n.Id == id);

        if (course == null)
        {
            return;
        }

        _context.Courses.Remove(course);
        _context.SaveChanges();
    }
}
