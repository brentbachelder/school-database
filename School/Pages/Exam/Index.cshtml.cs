using School.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace School.Pages.Exam
{
    public class IndexModel : PageModel
    {
		private IExamAdapter _examAdapter;
		public IndexModel(IExamAdapter examAdapter)
		{
			_examAdapter = examAdapter;
		}

		public IEnumerable<School.DAL.Exam> Exams { get; set; }

		public void OnGet(int id = 0)
		{
			if(id == 0)
			{
				Exams = _examAdapter.GetAll();
			}
			else
			{
				Exams = _examAdapter.GetByStudentId(id);
			}
		}
	}
}
