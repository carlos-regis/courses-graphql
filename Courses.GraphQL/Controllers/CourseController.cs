using Courses.GraphQL.Contracts;
using Courses.GraphQL.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Courses.GraphQL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CoursesRepository _coursesRepository;

    public CourseController(CoursesRepository coursesRepository) => _coursesRepository = coursesRepository;

    [HttpGet]
    public IActionResult GetAll()
    {
        var allCourses = _coursesRepository.GetAllCourses();
        return Ok(allCourses);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _coursesRepository.GetCourseById(id);
        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook(UpsertCourseRequest upsertCourseRequest)
    {
        var addedCourse = _coursesRepository.AddCourse(upsertCourseRequest);
        return Ok(addedCourse);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpsertCourseRequest upsertCourseRequest)
    {
        var updatedCourse = _coursesRepository.UpdateCourse(id, upsertCourseRequest);
        return Ok(updatedCourse);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _coursesRepository.DeleteCourse(id);
        return Ok();
    }
}
