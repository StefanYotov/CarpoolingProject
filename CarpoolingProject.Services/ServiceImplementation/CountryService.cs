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
        private readonly CarpoolingContext db;

        public CountryService(CarpoolingContext db)
        {
            this.db = db;
        }

        public async Task<CreateCountryResponseModel> CreateCountryAsync(CreateCountryRequestModel requestModel)
        {
            var responseModel = new CreateCountryResponseModel();

            var country = new Country()
            {
                Id = requestModel.Id,
                Name = requestModel.Name
            };
            this.db.Countries.Add(country);
            await this.db.SaveChangesAsync();
            return responseModel;
        }

        public async Task<DeleteCountryResponseModel> DeleteCountryAsync(DeleteCountryRequestModel requestModel)
        {
            var responseModel = new DeleteCountryResponseModel();
            var country = await this.db.Countries.FirstOrDefaultAsync(c => c.Id == requestModel.Id);

            if (country == null)
            {
                responseModel.Message =Constants.COUNTRY_NULL_ERROR;
                responseModel.IsSuccess = false;
            }

            else
            {
                responseModel.Message = Constants.COUNTRY_DELETE_SUCCESSFULL;
                responseModel.IsSuccess = true;
                this.db.Countries.Remove(country);
                await this.db.SaveChangesAsync();

            }
            return responseModel;
        }
    }
}
