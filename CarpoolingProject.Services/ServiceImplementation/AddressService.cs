using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class AddressService : IAddressService
    {
        private readonly CarpoolingContext context;

        public AddressService(CarpoolingContext context)
        {
            this.context = context;
        }
        
        public async Task<InfoResponseModel> CreateAddress(CreateAddressRequestModel requestModel)
        {
            var response = new InfoResponseModel();
            if (requestModel.StreetName == null || requestModel.CityId < 1)
            {
                response.IsSuccess = false;
                response.Message = Constants.INVALID_PARAMS;
                return response;
            }
            var address = new Address()
            {
                StreetName = requestModel.StreetName,
                CityId=requestModel.CityId
            };
            response.IsSuccess = true;
            response.Message = Constants.ADDRESS_CREATE_SUCCESS;
            context.Addresses.Add(address);
            await context.SaveChangesAsync();
            return response;
            
        }
    }
}
