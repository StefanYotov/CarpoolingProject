using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Utilities;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<InfoResponseModel> CreateAddressAsync(CreateAddressRequestModel requestModel)
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
        public async Task<InfoResponseModel> DeleteAddressAsync(DeleteAddressRequestModel requestModel)
        {
            var respone = new InfoResponseModel();
            var addressToDelete = await context.Addresses.FirstOrDefaultAsync(x => x.AddressId == requestModel.Id);
            if (addressToDelete == null)
            {
                respone.IsSuccess = false;
                respone.Message = Constants.ADDRESS_NOT_FOUND;
                return respone;
            }
            respone.IsSuccess = true;
            respone.Message = Constants.ADDRESS_DELETED_SUCCESS;
            context.Addresses.Remove(addressToDelete);
            context.SaveChanges();
            return respone;
        }
    }
}
