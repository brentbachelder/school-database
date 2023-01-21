using School.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace School.Pages.Teacher
{
    public class IndexModel : PageModel
    {
		private ITeacherAdapter _teacherAdapter;
		public IndexModel(ITeacherAdapter teacherAdapter)
		{
			_teacherAdapter = teacherAdapter;
		}
		public IEnumerable<School.DAL.Teacher> Teachers { get; set; }
		public void OnGet()
		{
			Teachers = _teacherAdapter.GetAll();
		}
	}
}
