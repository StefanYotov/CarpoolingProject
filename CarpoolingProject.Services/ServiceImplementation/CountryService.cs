using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Interfaces;
using CarpoolingProject.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class CountryService : ICountryService
    {
        private readonly CarpoolingContext context;
        private readonly ICityService cityService;

        public CountryService(CarpoolingContext context,ICityService cityService)
        {
            this.context = context;
            this.cityService = cityService;
        }
        public async Task<Country> GetCountry(int id)
        {
            var country = await this.context.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
            return country;
        }
        public async Task<InfoResponseModel> CreateCountryAsync(CreateCountryRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();

            var country = new Country()
            {
                Name = requestModel.Name
            };
            responseModel.IsSuccess = true;
            responseModel.Message = "City Successfully created";
            this.context.Countries.Add(country);
            await this.context.SaveChangesAsync();
            return responseModel;
        }

        public async Task<InfoResponseModel> DeleteCountryAsync(DeleteCountryRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            var country = await GetCountry(requestModel.Id);

            if (country == null)
            {
                response.Message = Constants.COUNTRY_NULL_ERROR;
                response.IsSuccess = false;
            }

            else
            {
                response.Message = Constants.COUNTRY_DELETE_SUCCESSFULL;
                response.IsSuccess = true;
                this.context.Countries.Remove(country);
                await this.context.SaveChangesAsync();

            }
            return response;
        }
        public async Task<InfoResponseModel> AddCitiesToCountryAsync(AddCitiesToCountryRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            var country = await GetCountry(requestModel.Id);
            var city = await cityService.GetCity(requestModel.CityId);
            country.Cities.Add(city);
            await context.SaveChangesAsync();
            response.Message = "City added to Country";
            response.IsSuccess = true;
            return response;
        }
        public async Task<IEnumerable<City>> ShowCities(ShowCitiesRequestModel requestModel)
        {
            var country = await GetCountry(requestModel.Id);
            return country.Cities;
        }
    }
}
