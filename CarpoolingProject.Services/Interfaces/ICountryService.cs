using CarpoolingProject.Models.EntityModels;
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
        Task<Country> GetCountry(int id);
        Task<InfoResponseModel> CreateCountryAsync(CreateCountryRequestModel requestModel);
        Task<InfoResponseModel> DeleteCountryAsync(DeleteCountryRequestModel requestModel);
        Task<InfoResponseModel> AddCitiesToCountryAsync(AddCitiesToCountryRequestModel requestModel);
        Task<IEnumerable<City>> ShowCities(ShowCitiesRequestModel requestModel);
    }
}
