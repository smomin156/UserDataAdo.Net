using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary
{
    public class IncorrectException:Exception
    {
        public IncorrectException(string message) : base(message)
        {

        }
    }
}
