using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Exceptions
{
    public class DuplicateItemException : ApplicationException
    {
        public DuplicateItemException(string name, string key) : base($"{name} ({key}) Ya existe")
        {
        }
    }
}
