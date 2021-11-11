using CarpoolingProject.Data;
using CarpoolingProject.Models.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public interface ITravelService
    {
        Travel GetTravel(int id);
        Task<IEnumerable<TravelDto>> GetAllTravels();
        int TravelCount();
        Task<Travel> CreateTravel(Travel travel);
        void DeleteTravel(int id);
        Travel UpdateTravel(int id, Travel travel);
    }
}