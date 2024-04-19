using BLL.DTO;

namespace BLL
{
    public interface IStudentService
    {
        StudentDTO GetStudentById(int id);
        IEnumerable<StudentDTO> GetAllStudents();
        StudentDTO AddStudent(StudentCreateDTO student);
        StudentDTO UpdateStudent(int id, StudentUpdateDTO student);
        bool DeleteStudent(int id);
        void AddStudentDB(string firstName, string lastName, int? groupID);
    }
}