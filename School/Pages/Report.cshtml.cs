using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.DAL;

namespace School.Pages
{
	public class ReportModel : PageModel
	{
		private IReportAdapter _reportAdapter;
		public ReportModel(IReportAdapter reportAdapter)
		{
			_reportAdapter = reportAdapter;
		}

		public IEnumerable<Report> ReportRows { get; set; }
		public int[] AllCounts = new int[5];

		public void OnGet()
		{
			ReportRows = _reportAdapter.GetExamsByScore();

			bool ran = false;
			foreach(var report in ReportRows)
			{
				if(!ran)
				{
					AllCounts[0] = report.AGrade;
					AllCounts[1] = report.BGrade;
					AllCounts[2] = report.CGrade;
					AllCounts[3] = report.DGrade;
					AllCounts[4] = report.FGrade;
					ran = true;
				}
			}
		}
	}
}