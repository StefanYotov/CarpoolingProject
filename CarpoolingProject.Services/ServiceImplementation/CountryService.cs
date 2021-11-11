using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

      public async Task<CreateCountryResponseModel> CreateAsync(CreateCountryRequestModel requestModel)
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
    }
}
