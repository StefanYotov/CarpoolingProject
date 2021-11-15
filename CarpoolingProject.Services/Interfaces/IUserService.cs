using CarpoolingProject.Models.Dtos;
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
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllPassengers();
        Task<User> GetUser(int id);
        Task<InfoResponseModel> CreateUserAsync(CreateUserRequestModel requestModel);
        Task<InfoResponseModel> DeleteUserAsync(DeleteUserRequestModel requestModel);
        Task<InfoResponseModel> UpdateUserAsync(UpdateUserRequestModel requestModel);
    }
}
