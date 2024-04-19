using BLL;
using BLL.DTO;
using DAL;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class HistoryService : IHistoryService
    {
        private readonly IStudentRepo _studentRepo;

        public HistoryService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public IEnumerable<HistoryDTO> GetAllHistory()
        {
            return _studentRepo.GetAllHistory();
        }
        public IEnumerable<HistoryDTO> GetPagedHistory(int pageNumber, int pageSize)
        {
            return _studentRepo.GetPagedHistory(pageNumber, pageSize);
        }
    }
}
