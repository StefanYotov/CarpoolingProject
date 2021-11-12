using CarpoolingProject.Data;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Dtos;
using CarpoolingProject.Services.Exceptions;
using CarpoolingProject.Services.Utilities;
using CarpoolingProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class TravelService : ITravelService
    {
        private readonly CarpoolingContext context;
        public TravelService(CarpoolingContext context)
        {
            this.context = context;
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
        public async Task<InfoResponseModel> CreateTravelAsync(CreateTravelRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();
            if (requestModel.UserId < 1 ||
                requestModel.StartPoint == null ||
                requestModel.EndPoint == null ||
                requestModel.FreeSpots < 1
                )
            {
                responseModel.IsSuccess = false;
                responseModel.Message = Constants.INVALID_PARAMS;
                return responseModel;
            }
            var travel = new Travel()
            {
                UserId = requestModel.UserId,
                StartPoint = requestModel.StartPoint,
                EndPoint = requestModel.EndPoint,
                DepartureTime = requestModel.DepartureTime,
                FreeSpots = requestModel.FreeSpots

            };
            context.Travels.Add(travel);
            await context.SaveChangesAsync();

            responseModel.IsSuccess = true;
            responseModel.Message = Constants.TRAVEL_CREATE_SUCCESS;

            return responseModel;

        }
        public async Task<InfoResponseModel> DeleteTravelAsync(DeleteTravelRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();
            var travelToDelete = await context.Travels.FirstOrDefaultAsync(x => x.TravelId == requestModel.Id);
            if (travelToDelete == null)
            {
                responseModel.Message = Constants.TRAVEL_NOT_FOUND;
                responseModel.IsSuccess = false;
            }
            else
            {
                responseModel.Message = Constants.TRAVEL_DELETE_SUCCESS;
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
            if (this.GetTravel(travel.UserId) == null)
            {
                throw new EntityNotFoundException($"There is no travel with id {travel.UserId} ");
            }
        }

        public async Task<InfoResponseModel> UpdateTravelAsync(UpdateTravelRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            if (requestModel.UserId < 1 ||
                requestModel.FreeSpots < 1 ||
                requestModel.EndPoint == null ||
                requestModel.StartPoint == null
                )
            {
                response.IsSuccess = false;
                response.Message = Constants.INVALID_PARAMS;
                return response;
            }
            var travel = await context.Travels.FirstOrDefaultAsync(x => x.TravelId == requestModel.Id);
            if (travel != null)
            {
                if (requestModel.UserId != travel.UserId)
                {
                    travel.UserId = requestModel.Id;
                }
                else if (requestModel.FreeSpots != travel.FreeSpots)
                {
                    travel.FreeSpots = requestModel.FreeSpots;
                }
                else if (requestModel.EndPoint != travel.EndPoint)
                {
                    travel.EndPoint = requestModel.EndPoint;
                }
                else if (requestModel.StartPoint != travel.StartPoint)
                {
                    travel.StartPoint = requestModel.StartPoint;
                }
                else if (requestModel.DepartureTime != travel.DepartureTime)
                {
                    travel.DepartureTime = requestModel.DepartureTime;
                }
                //else if (requestModel.Id != travel.TravelId)
                //{
                //    response.Message = Constants.TRAVEL_UNATHORIZED;
                //    response.IsSuccess = false;
                //    return response;
                //}
                await context.SaveChangesAsync();
                response.Message = Constants.TRAVEL_CREATE_SUCCESS + $"{travel.TravelId}";
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Constants.TRAVEL_UPDATE_ERROR + $"{travel.TravelId} id";
            }
            return response;
        }



    }
}
