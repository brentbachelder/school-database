using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.DAL;

namespace School.Pages.Student
{
	public class EditModel : PageModel
	{
		private IStudentAdapter _studentAdapter;
		public EditModel(IStudentAdapter studentAdapter)
		{
			_studentAdapter = studentAdapter;
		}

		[BindProperty]
		public int StudentId { get; set; }
		[BindProperty]
		public string FirstName { get; set; }
		[BindProperty]
		public string LastName { get; set; }


		public bool IsSuccess { get; set; }

		public void OnGet(int id = 0)
		{

			if(id != 0)
			{
				School.DAL.Student student = _studentAdapter.GetById(id);
				if(student != null)
				{
					FirstName = student.FirstName;
					LastName = student.LastName;
					StudentId = student.StudentId;
				}
			}
		}

		public void OnPost()
		{
			if(ModelState.IsValid)
			{
				School.DAL.Student student = new School.DAL.Student();
				student.FirstName = FirstName;
				student.LastName = LastName;
				student.StudentId = StudentId;

				if(StudentId > 0)
				{
					bool isUpdate = _studentAdapter.UpdateStudent(student);
					if(isUpdate)
					{
						IsSuccess = true;
					}
					else
					{
						IsSuccess = false;
					}
				}
				else
				{
					bool isCreate = _studentAdapter.InsertStudent(student);
					if(isCreate)
					{
						IsSuccess = true;
					}
					else
					{
						IsSuccess = false;
					}
				}
				IsSuccess = true;
			}
			else
			{
				IsSuccess = false;
			}
		}
	}
}