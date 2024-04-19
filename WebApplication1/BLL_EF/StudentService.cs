using BLL;
using BLL.DTO;
using DAL;

namespace BLL_EF
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public StudentDTO GetStudentById(int id)
        {
            return _studentRepo.GetStudentById(id);
        }

        public IEnumerable<StudentDTO> GetAllStudents()
        {
            return _studentRepo.GetAllStudents();
        }

        public StudentDTO AddStudent(StudentCreateDTO student)
        {
            return _studentRepo.AddStudent(student);
        }

        public StudentDTO UpdateStudent(int id, StudentUpdateDTO student)
        {
            return _studentRepo.UpdateStudent(id, student);
        }

        public bool DeleteStudent(int id)
        {
            return _studentRepo.DeleteStudent(id);
        }
        public IEnumerable<HistoryDTO> GetAllHistory()
        {
            return _studentRepo.GetAllHistory();
        }

        public void AddStudentDB(string firstName, string lastName, int? groupID)
        {
            _studentRepo.AddStudentDB(firstName, lastName, groupID);
        }
    }

}