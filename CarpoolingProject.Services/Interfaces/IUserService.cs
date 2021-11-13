using CarpoolingProject.Models.Dtos;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
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
    }
}
