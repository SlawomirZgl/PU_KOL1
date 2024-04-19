using BLL.DTO;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentsDb _context;

        public StudentRepo(StudentsDb context)
        {
            _context = context;
        }
        public StudentDTO GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return null;
            }

            return new StudentDTO
            {
                ID = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupID = student.GroupID
            };
        }

        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var students = _context.Students.ToList();
            return students.Select(student => new StudentDTO
            {
                ID = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupID = student.GroupID
            });
        }

        public StudentDTO AddStudent(StudentCreateDTO student)
        {
            var entity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupID = student.GroupID
            };

            _context.Students.Add(entity);
            _context.SaveChanges();

            return new StudentDTO
            {
                ID = entity.ID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                GroupID = entity.GroupID
            };
        }

        public StudentDTO UpdateStudent(int id, StudentUpdateDTO student)
        {
            var entity = _context.Students.Find(id);
            if (entity == null)
            {
                return null;
            }

            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.GroupID = student.GroupID;

            _context.SaveChanges();

            return new StudentDTO
            {
                ID = entity.ID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                GroupID = entity.GroupID
            };
        }

        public bool DeleteStudent(int id)
        {
            var entity = _context.Students.Find(id);
            if (entity == null)
            { 
                return false;
            }

            _context.Students.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<HistoryDTO> GetAllHistory()
        {
            var histories = _context.History.ToList();

            var historyDTOs = histories.Select(history => new HistoryDTO
            {
                ID = history.ID,
                FirstName = history.FirstName,
                LastName = history.LastName,
                GroupID = history.GroupID,
                ActionType = history.ActionType,
                Date = history.Date
            });

            return historyDTOs;
        }

        public void AddStudentDB(string firstName, string lastName, int? groupID)
        {
            _context.Database.ExecuteSqlRaw("EXEC AddStudent @FirstName={0}, @LastName={1}, @GroupID={2}", firstName, lastName, groupID);
        }

        public IEnumerable<HistoryDTO> GetPagedHistory(int pageNumber, int pageSize)
        {
            var histories = _context.History
                .FromSqlRaw("EXEC GetPagedHistory @PageNumber={0}, @PageSize={1}", pageNumber, pageSize)
                .ToList();

            var historyDTOs = histories.Select(history => new HistoryDTO
            {
                ID = history.ID,
                FirstName = history.FirstName,
                LastName = history.LastName,
                GroupID = history.GroupID,
                ActionType = history.ActionType,
                Date = history.Date
            });

            return historyDTOs;
        }
    }

}
