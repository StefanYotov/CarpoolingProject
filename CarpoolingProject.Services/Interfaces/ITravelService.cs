using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.Interfaces
{
    public interface ITravelService
    {
        Task<Travel> GetTravel(int id);
        Task<IEnumerable<TravelDto>> GetAllTravelsAsync();
        int TravelCount();
        Task<InfoResponseModel> CreateTravelAsync(CreateTravelRequestModel requestModel);
        Task<InfoResponseModel> DeleteTravelAsync(DeleteTravelRequestModel requestModel);
        Task<InfoResponseModel> UpdateTravelAsync(UpdateTravelRequestModel requestModel);
        //Travel UpdateTravel(int id, Travel travel);
    }
}