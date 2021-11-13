using CarpoolingProject.Data;
using CarpoolingProject.Models.Dtos;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Exceptions;
using CarpoolingProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class UserService:IUserService
    {
        private readonly CarpoolingContext context;

        public UserService(CarpoolingContext context)
        {
            this.context = context;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user?? throw new EntityNotFoundException();
        }
        public async Task<IEnumerable<UserDto>> GetAllPassengers()
        {
            var passengers = await context.Users.Where(x => x.Roles.Any(x => x.Role.Name == "Passenger")).Select(x=> new UserDto(x)).ToListAsync();
            return passengers;
        }
    }
}
