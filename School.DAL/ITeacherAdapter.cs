namespace School.DAL
{
    public interface ITeacherAdapter
    {
        bool DeleteTeacherById(int id);
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        bool InsertTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
    }
}