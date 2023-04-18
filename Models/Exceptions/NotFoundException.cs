using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16.Models.Exceptions
{
    internal class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {

        }
    }
}
