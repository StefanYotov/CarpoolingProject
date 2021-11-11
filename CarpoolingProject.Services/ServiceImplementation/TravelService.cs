using CarpoolingProject.Data;
using CarpoolingProject.Models.RequestModels;
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
        
        public Travel GetTravel(int id)
        {
            var travel = this.context.Travels.FirstOrDefault(x => x.TravelId == id);
            return travel ?? throw new EntityNotFoundException();
        }
        public async Task<IEnumerable<TravelDto>> GetAllTravels()
        {
            var travels = await context.Travels.Select(travel => new TravelDto(travel)).ToListAsync();
            return travels;
        }
        public int TravelCount()
        {
            var travelsCount = this.context.Travels.Count();
            return travelsCount;
        }
        public async Task<Travel> CreateTravel(Travel travel)
        {
            ValidateDate(travel);
            await context.Travels.AddAsync(travel);
            this.context.SaveChanges();
            return travel;
        }
        public void DeleteTravel(int id)
        {
            var travelToDelete = GetTravel(id);
            context.Travels.Remove(travelToDelete);
            this.context.SaveChanges();
        }
        public Travel UpdateTravel(int id, Travel travel)
        {
            var travelToUpdate = GetTravel(id);
            ValidateDate(travel);
            travelToUpdate.StartPoint = travel.StartPoint;
            travelToUpdate.EndPoint = travel.EndPoint;
            travelToUpdate.DepartureTime = travel.DepartureTime;
            travelToUpdate.FreeSpots = travel.FreeSpots;
            return travelToUpdate;
        }
        private void ValidateDate(Travel travel)
        {
            if(this.GetTravel(travel.UserId) == null)
            {
                throw new EntityNotFoundException($"There is no user with id {travel.UserId} ");
            }
        }
    }
}
