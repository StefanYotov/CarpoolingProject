using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public interface IAddressService
    {
        Task<InfoResponseModel> CreateAddressAsync(CreateAddressRequestModel requestModel);
        Task<InfoResponseModel> DeleteAddressAsync(DeleteAddressRequestModel requestModel);
    }
}