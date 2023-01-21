using School.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace School.Pages.Teacher
{
    public class DeleteModel : PageModel
    {
		private ITeacherAdapter _teacherAdapter;
		public int Id { get; set; }
		public DeleteModel(ITeacherAdapter teacherAdapter)
		{
			_teacherAdapter = teacherAdapter;
		}
		public bool IsSuccess = false;
		public void OnGet(int id = 0)
		{
			Id = id;
			if(id > 0)
			{
				bool isDelete = _teacherAdapter.DeleteTeacherById(id);
				if(isDelete)
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
				IsSuccess = false;
			}
		}
	}
}
