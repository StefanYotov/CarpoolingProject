using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.RequestModels
{
    public class CreateAddressRequestModel
    {
        public string StreetName { get; set; }
        public int CityId { get; set; }

    }
}
