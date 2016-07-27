using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgemoHivTests.BusinessLogic.Infrastructure
{
    class XmlDataIncorrectNumberException : Exception
    {
        public XmlDataIncorrectNumberException(string message)
            : base(message) { }
    }
}
