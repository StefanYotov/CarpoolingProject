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
        Task<InfoResponseModel> FinishedTravel(FinishedTravelRequestModel requestModel);
        Task<InfoResponseModel> ApplyForTravel(ApplyForTravelRequestModel requestModel);
        Task<IEnumerable<User>> ListApplicantsForTravel(GetTravelRequestModel requestModel);
    }
}