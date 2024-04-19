using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IHistoryService
    {
        IEnumerable<HistoryDTO> GetAllHistory();
        IEnumerable<HistoryDTO> GetPagedHistory(int pageNumber, int pageSize);

    }
}
