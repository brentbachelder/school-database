namespace School.DAL
{
	public interface IReportAdapter
	{
		IEnumerable<Report> GetExamsByScore();
	}
}