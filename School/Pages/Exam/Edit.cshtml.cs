using School.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace School.Pages.Exam
{
    public class EditModel : PageModel
    {
		private IExamAdapter _examAdapter;
		private IStudentAdapter _studentAdapter;
		public EditModel(IExamAdapter examAdapter, IStudentAdapter studentAdapter)
		{
			_examAdapter = examAdapter;
			_studentAdapter = studentAdapter;
		}

		public List<SelectListItem> StudentOptions { get; set; }
		[BindProperty]
		[DisplayName("Student")]
		[Range(1, double.MaxValue,
		ErrorMessage = "Please select a student")]
		public int StudentId { get; set; }
		[BindProperty]
		[Range(1, 15000)]
		public decimal Score { get; set; }
		[BindProperty]
		public int ExamId { get; set; }
		public bool IsSuccess { get; set; }
		public void OnGet(int id = 0)
		{
			SetupStudentOptions();
			ExamId = id;
			if(id > 0)
			{
				School.DAL.Exam exam = _examAdapter.GetById(id);
				StudentId = exam.StudentId;
				Score = exam.Score;
			}
		}

		public void SetupStudentOptions()
		{
			StudentOptions = new List<SelectListItem>();
			IEnumerable<School.DAL.Student> students = _studentAdapter.GetAll();
			foreach(School.DAL.Student student in students)
			{
				SelectListItem itemToAdd = new SelectListItem();
				itemToAdd.Text = student.FirstName + " " + student.LastName;
				itemToAdd.Value = student.StudentId.ToString();
				StudentOptions.Add(itemToAdd);
			}
		}

		public void OnPost()
		{
			if(ModelState.IsValid)
			{
				School.DAL.Exam exam = new DAL.Exam();
				exam.ExamId = ExamId;
				exam.StudentId = StudentId;
				exam.Score = Score;

				if(ExamId > 0)
				{
					IsSuccess = _examAdapter.UpdateExam(exam);
				}
				else
				{
					IsSuccess = _examAdapter.InsertExam(exam);
				}
			}
			else
			{
				SetupStudentOptions();
				IsSuccess = false;
			}
		}
	}
}
