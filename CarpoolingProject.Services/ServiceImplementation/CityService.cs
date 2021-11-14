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
        public async Task<City> GetCity(int id)
        {
            var city = await context.Cities.FirstOrDefaultAsync(x => x.CityId == id);
            return city;
        }
        public async Task<InfoResponseModel> CreateCityAsync(CreateCityRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            if (context.Cities.Any(x => x.Name == requestModel.Name))
            {
                response.Message = "City already exists";
                return response;
            }
            

            var city = new City()
            {
                Name = requestModel.Name,
                CountryId = requestModel.CountryId
            };
            response.IsSuccess = true;
            response.Message = Constants.CITY_CREATE_SUCCESS;
            this.context.Cities.Add(city);
            await this.context.SaveChangesAsync();
            return response;
        }

        public async Task<InfoResponseModel> DeleteCityAsync(DeleteCityRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            var city = await this.context.Cities.FirstOrDefaultAsync(c => c.CityId == requestModel.Id);

            if (city == null)
            {
                response.Message = Constants.CITY_NULL_ERROR;
                response.IsSuccess = false;
            }

            else
            {
                response.Message = Constants.CITY_DELETE_SUCCESSFULL;
                response.IsSuccess = true;
                this.context.Cities.Remove(city);
                await this.context.SaveChangesAsync();
            }
            return response;
        }
    }
}
  