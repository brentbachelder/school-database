namespace School.DAL
{
	public class Exam
	{
		public int ExamId { get; set; }
		public int StudentId { get; set; }
		public decimal Score { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}