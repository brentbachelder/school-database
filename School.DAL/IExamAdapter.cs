namespace School.DAL
{
    public interface IExamAdapter
    {
        bool DeleteExamById(int id);
        IEnumerable<Exam> GetAll();
        IEnumerable<Exam> GetByStudentId(int studentId);
        Exam GetById(int id);
        bool InsertExam(Exam exam);
        bool UpdateExam(Exam exam);
    }
}