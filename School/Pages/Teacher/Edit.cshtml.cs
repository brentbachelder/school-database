using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.DAL;

namespace School.Pages.Teacher
{
	public class EditModel : PageModel
	{
		private ITeacherAdapter _teacherAdapter;
		public EditModel(ITeacherAdapter teacherAdapter)
		{
			_teacherAdapter = teacherAdapter;
		}

		[BindProperty]
		public int TeacherId { get; set; }
		[BindProperty]
		public string FirstName { get; set; }
		[BindProperty]
		public string LastName { get; set; }


		public bool IsSuccess { get; set; }

		public void OnGet(int id = 0)
		{

			if(id != 0)
			{
				School.DAL.Teacher teacher = _teacherAdapter.GetById(id);
				if(teacher != null)
				{
					FirstName = teacher.FirstName;
					LastName = teacher.LastName;
					TeacherId = teacher.TeacherId;
				}
			}
		}

		public void OnPost()
		{
			if(ModelState.IsValid)
			{
				School.DAL.Teacher teacher = new School.DAL.Teacher();
				teacher.FirstName = FirstName;
				teacher.LastName = LastName;
				teacher.TeacherId = TeacherId;

				if(TeacherId > 0)
				{
					bool isUpdate = _teacherAdapter.UpdateTeacher(teacher);
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
					bool isCreate = _teacherAdapter.InsertTeacher(teacher);
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