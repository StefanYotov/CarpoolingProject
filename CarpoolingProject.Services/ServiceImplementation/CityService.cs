using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Interfaces;
using CarpoolingProject.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class CityService : ICityService
    {
        private readonly CarpoolingContext context;

        public CityService(CarpoolingContext context)
        {
            this.context = context;
        }

        public async Task<InfoResponseModel> CreateCityAsync(CreateCityRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();

            var city = new City()
            {
                Name = requestModel.Name
            };
            responseModel.IsSuccess = true;
            responseModel.Message = Constants.CITY_CREATE_SUCCESS;
            this.context.Cities.Add(city);
            await this.context.SaveChangesAsync();
            return responseModel;
        }

        public async Task<InfoResponseModel> DeleteCityAsync(DeleteCityRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();
            var city = await this.context.Cities.FirstOrDefaultAsync(c => c.CityId == requestModel.Id);

            if (city == null)
            {
                responseModel.Message = Constants.CITY_NULL_ERROR;
                responseModel.IsSuccess = false;
            }

            else
            {
                responseModel.Message = Constants.CITY_DELETE_SUCCESSFULL;
                responseModel.IsSuccess = true;
                this.context.Cities.Remove(city);
                await this.context.SaveChangesAsync();
            }
            return responseModel;
        }
    }
}
  