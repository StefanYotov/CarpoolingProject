﻿using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCity(int id);
        Task<InfoResponseModel> CreateCityAsync(CreateCityRequestModel requestModel);
        Task<InfoResponseModel> DeleteCityAsync(DeleteCityRequestModel requestModel);
    }
}
