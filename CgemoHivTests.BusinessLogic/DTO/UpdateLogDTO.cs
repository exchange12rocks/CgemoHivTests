using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgemoHivTests.BusinessLogic.DTO
{
    public class UpdateLogDTO
    {
        public int Id { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public System.DateTime DateFirst { get; set; }
        public System.DateTime DateEnd { get; set; }
        public int TotalRecords { get; set; }
        public System.Guid UserId { get; set; }

        //public virtual User User { get; set; }
    }
}
