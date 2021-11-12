using CarpoolingProject.Data;
using CarpoolingProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class CityService : ICityService
    {
        private readonly CarpoolingContext context;

        public CityService(CarpoolingContext context)
        {
            this.context = context;
        }

        
    }
}
