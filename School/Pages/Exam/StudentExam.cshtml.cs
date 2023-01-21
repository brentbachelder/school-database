using School.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Formats.Asn1.AsnWriter;

namespace School.Pages.Exam
{
    public class StudentExamModel : PageModel
    {
		private IExamAdapter _examAdapter;
		public int StudentId { get; set; }
		public StudentExamModel(IExamAdapter examAdapter)
		{
			_examAdapter = examAdapter;
		}

		public IEnumerable<School.DAL.Exam> Exams { get; set; }

		public void OnGet(int id = 0)
		{
			Exams = _examAdapter.GetByStudentId(id);
		}
	}
}
