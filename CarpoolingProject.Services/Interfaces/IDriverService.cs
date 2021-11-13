using CarpoolingProject.Models.Dtos;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDto>> GetAllDriversAsync();
        Task<InfoResponseModel> UpdateTimeOfDepartureAsync(UpdateTimeOfDepartureRequestModel requestModel);
        Task<InfoResponseModel> SelectUser(SelectPassengerRequestModel requestModel);
    }
}