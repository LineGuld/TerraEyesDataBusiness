﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.DBNetworking
{
    public interface IDbConnect
    {
        Task<List<TemperatureMeasurement>> GetTemperatureFromDb(string userId);
        Task<List<HumidityMeasurement>> GetHumidityFromDb(string userId);
        Task<List<CarbonMeasurement>> GetCarbonFromDb(string userId);
    }
}