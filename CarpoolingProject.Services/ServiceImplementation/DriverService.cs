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
        private readonly IUserService userService;

        public DriverService(CarpoolingContext context,ITravelService travelService,IUserService userService)
        {
            this.context = context;
            this.travelService = travelService;
            this.userService = userService;
        }
        
        public async Task<IEnumerable<DriverDto>> GetAllDriversAsync()
        {
            var drivers = await context.Users.Where(x=>x.Roles.Any(r=>r.Role.Name=="Driver")).Select(x=> new DriverDto(x)).ToListAsync();
            return drivers;
        }
        public async Task<InfoResponseModel> UpdateTimeOfDepartureAsync(UpdateTimeOfDepartureRequestModel requestModel)
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
        public async Task<InfoResponseModel> SelectUser(SelectPassengerRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            var selectedPassenger = await userService.GetUser(requestModel.Id);
            var travel = await travelService.GetTravel(requestModel.TravelId);
            
            if (selectedPassenger != null && travel!=null)
            {
                var travelAplication = new TravelApplication
                {
                    ApplicantId = selectedPassenger.UserId,
                    TravelId = travel.TravelId
                };
                if (requestModel.Liked)
                {
                    response.Message = $"You liked ";
                    travel.Passengers.Add(selectedPassenger);
                    
                    travel.ApplicantsForTravel.Remove(travelAplication);
                    return response;
                }
                travel.ApplicantsForTravel.Remove(travelAplication);
                response.Message = $"You didn't like {selectedPassenger.UserId}";
                return response;
            }
            response.Message = "Invalid info";
            response.IsSuccess = false;
            return response;
        }
    }
}
