using CarpoolingProject.Data;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class TravelService:ITravelService
    {
        private readonly CarpoolingContext context;
        public TravelService(CarpoolingContext context)
        {
            this.context=context;
        }
        
        public async Task<Travel> GetTravel(int id)
        {
            var travel = await context.Travels.FirstOrDefaultAsync(x => x.TravelId == id);
            return travel ?? throw new EntityNotFoundException();
        }
        public async Task<IEnumerable<TravelDto>> GetAllTravelsAsync()
        {
            var travels = await context.Travels.Select(travel => new TravelDto(travel)).ToListAsync();
            return travels;
        }
        public int TravelCount()
        {
            var travelsCount = this.context.Travels.Count();
            return travelsCount;
        }
        public async Task<InfoResponseModel> CreateTravelAsync(Travel travel)
        {
            var responseModel = new InfoResponseModel();
            responseModel.Message = "Travel created successfully";
            await context.Travels.AddAsync(travel);
            this.context.SaveChanges();
            return responseModel;
            
        }
        public async Task<InfoResponseModel> DeleteTravelAsync(DeleteTravelRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();
            var travelToDelete = await context.Travels.FirstOrDefaultAsync(x=>x.TravelId==requestModel.Id);
            if(travelToDelete == null)
            {
                responseModel.Message = "Travel was not found";
                responseModel.IsSuccess = false;
            }
            else
            {
                responseModel.Message = $"Travel with {requestModel.Id} was successfully deleted.";
                responseModel.IsSuccess = true;
                this.context.Travels.Remove(travelToDelete);
                this.context.SaveChanges();
            }
            return responseModel;
            
        }
        //public Travel UpdateTravel(int id, Travel travel)
        //{
        //    var travelToUpdate = GetTravel(id);
        //    ValidateDate(travel);
        //    travelToUpdate.StartPoint = travel.StartPoint;
        //    travelToUpdate.EndPoint = travel.EndPoint;
        //    travelToUpdate.DepartureTime = travel.DepartureTime;
        //    travelToUpdate.FreeSpots = travel.FreeSpots;
        //    return travelToUpdate;
        //}
        private void ValidateDate(Travel travel)
        {
            if(this.GetTravel(travel.UserId) == null)
            {
                throw new EntityNotFoundException($"There is no user with id {travel.UserId} ");
            }
        }
    }
}
