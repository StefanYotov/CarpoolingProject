using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.Exceptions
{
    public class EntityNotFoundException:ApplicationException
    {
        public EntityNotFoundException()
        {

        }
        public EntityNotFoundException(string message):base(message)
        {

        }
    }
}
