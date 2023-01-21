using School.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace School
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private IStudentAdapter _studentAdapter;
		public StudentController(IStudentAdapter studentAdapter)
		{
			_studentAdapter = studentAdapter;
		}

		[HttpGet]
		public IEnumerable<Student> GetStudents()
		{
			return _studentAdapter.GetAll();
		}

		[HttpPost]
		public IActionResult InsertStudent(Student student)
		{
			bool isSuccess = _studentAdapter.InsertStudent(student);

			if(isSuccess)
			{
				return Ok(student);
			}
			else
			{
				throw new Exception("Error inserting student");
			}
		}

		[HttpPut]
		public IActionResult UpdateStudent(Student student)
		{
			bool isSuccess = _studentAdapter.UpdateStudent(student);

			if(isSuccess)
			{
				return Ok(student);
			}
			else
			{
				throw new Exception("Error updating student");
			}
		}

		[HttpDelete]
		public IActionResult DeleteStudent(int id)
		{
			bool isSuccess = _studentAdapter.DeleteStudentById(id);

			if(isSuccess)
			{
				return Ok();
			}
			else
			{
				throw new Exception("Error deleting student");
			}
		}
	}
}
