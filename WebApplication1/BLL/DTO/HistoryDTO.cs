using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class HistoryDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GroupID { get; set; }
        public ActionTypeEnum ActionType { get; set; }
        public DateTime Date { get; set; }
    }

}
