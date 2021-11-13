using CarpoolingProject.Data;
using CarpoolingProject.Models.Dtos;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class DriverService:IDriverService
    {
        private readonly CarpoolingContext context;
        private readonly ITravelService travelService;

        public DriverService(CarpoolingContext context,ITravelService travelService)
        {
            this.context = context;
            this.travelService = travelService;
        }
        
        public async Task<IEnumerable<DriverDto>> GetAllDriversAsync()
        {
            var drivers = await context.Users.Where(x=>x.Roles.Any(r=>r.Role.Name=="Driver")).Select(x=> new DriverDto(x)).ToListAsync();
            return drivers;
        }
        public async Task<InfoResponseModel> UpdateTimeOfDeparture(UpdateTimeOfDepartureRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            var travel = await travelService.GetTravel(requestModel.Id);
            var result = (travel.DepartureTime - requestModel.DepartureTime).TotalHours;
            if(result> 1)
            {
                travel.DepartureTime = requestModel.DepartureTime;
                response.Message = "Successfully changed the time of departure";
                response.IsSuccess = true;
                return response;
            }
            response.Message = "You cannot change the time of departure if it is below 1 hour";
            response.IsSuccess = false;
            return response;
        }
        public async Task<InfoResponseModel> SelectUsers(Selec)
    }
}
