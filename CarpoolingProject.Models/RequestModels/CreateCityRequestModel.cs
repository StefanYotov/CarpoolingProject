using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.RequestModels
{
    public class CreateCityRequestModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
