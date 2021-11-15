using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.RequestModels
{
    public class UpdateUserRequestModel : CreateUserRequestModel
    {
        public int Id { get; set; }
    }
}
