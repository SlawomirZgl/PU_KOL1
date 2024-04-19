using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStudentRepo
    {
        StudentDTO GetStudentById(int id);
        IEnumerable<StudentDTO> GetAllStudents();
        StudentDTO AddStudent(StudentCreateDTO student);
        StudentDTO UpdateStudent(int id, StudentUpdateDTO student);
        bool DeleteStudent(int id);

        IEnumerable<HistoryDTO> GetAllHistory();

        void AddStudentDB(string firstName, string lastName, int? groupID);
    }
}
