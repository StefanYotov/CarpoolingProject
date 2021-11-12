using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Interfaces;
using CarpoolingProject.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class CountryService : ICountryService
    {
        private readonly CarpoolingContext context;

        public CountryService(CarpoolingContext context)
        {
            this.context = context;
        }

        public async Task<CreateCountryResponseModel> CreateCountryAsync(CreateCountryRequestModel requestModel)
        {
            var responseModel = new CreateCountryResponseModel();

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

        public async Task<DeleteCountryResponseModel> DeleteCountryAsync(DeleteCountryRequestModel requestModel)
        {
            var responseModel = new DeleteCountryResponseModel();
            var country = await this.context.Countries.FirstOrDefaultAsync(c => c.CountryId == requestModel.Id);

            if (country == null)
            {
                responseModel.Message = Constants.COUNTRY_NULL_ERROR;
                responseModel.IsSuccess = false;
            }

            else
            {
                responseModel.Message = Constants.COUNTRY_DELETE_SUCCESSFULL;
                responseModel.IsSuccess = true;
                this.context.Countries.Remove(country);
                await this.context.SaveChangesAsync();

            }
            return responseModel;
        }
    }
}
