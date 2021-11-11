using CarpoolingProject.Data;
using CarpoolingProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class AddressService:IAddressService
    {
        private readonly CarpoolingContext context;

        public AddressService(CarpoolingContext context)
        {
            this.context = context;
        }
        public Address GetAddress(int id)
        {
            var address = this.context.Addresses.FirstOrDefault(x => x.AddressId == id);
            return address;
        }
        public async Task<Address> CreateTravel(Address address)
        {
            await context.Addresses.AddAsync(address);
            this.context.SaveChanges();
            return address;
        }
    }
}
