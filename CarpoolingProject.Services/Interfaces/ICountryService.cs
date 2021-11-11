using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.Interfaces
{
    public interface ICountryService
    {
        Task<CreateCountryResponseModel> CreateCountryAsync(CreateCountryRequestModel requestModel);
    }
}
