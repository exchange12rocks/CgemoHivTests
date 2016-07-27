using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgemoHivTests.BusinessLogic.Infrastructure
{
    public enum Result { Error = 0, Warning, Success }
    public class MessageBox
    {
        public Result ResultId { get; set; }
        public string Message { get; set; }
    }
}
