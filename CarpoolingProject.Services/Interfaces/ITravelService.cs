using CarpoolingProject.Data;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public interface ITravelService
    {
        Task<Travel> GetTravel(int id);
        Task<IEnumerable<TravelDto>> GetAllTravelsAsync();
        int TravelCount();
        Task<InfoResponseModel> CreateTravelAsync(Travel travel);
        Task<InfoResponseModel> DeleteTravelAsync(DeleteTravelRequestModel requestModel);
        //Travel UpdateTravel(int id, Travel travel);
    }
}