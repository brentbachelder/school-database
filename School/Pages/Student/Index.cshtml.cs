using School.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace School.Pages.Student
{
    public class IndexModel : PageModel
    {
		private IStudentAdapter _studentAdapter;
		public IndexModel(IStudentAdapter studentAdapter)
		{
			_studentAdapter = studentAdapter;
		}
		public IEnumerable<School.DAL.Student> Students { get; set; }
		public void OnGet()
		{
			Students = _studentAdapter.GetAll();
		}
	}
}
