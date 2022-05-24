using System.Collections.Generic;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.DBNetworking
{
    public interface IDbConnect
    {
        //Terrarium settings
        Task<Terrarium> GetTerrariumInfoFromDb(string eui);
        //All measurements for a user
        Task<List<TemperatureMeasurement>> GetTemperatureFromDb(string userId);
        Task PostTemperatureToDb(TemperatureMeasurement measurement);
        Task<List<HumidityMeasurement>> GetHumidityFromDb(string userId);
        Task PostHumidityToDb(HumidityMeasurement measurement);
        Task<List<CarbondioxideMeasurement>> GetCarbonMeasurementsFromDb(string userId);

        //Measurements for a specific terrarium when a user has multiple
        Task<List<TemperatureMeasurement>> GetTerrariumTemperaturesFromDb(string userId, string terrariumId);
        Task<List<HumidityMeasurement>> GetTerrariumHumidityFromDb(string userId, string terrariumId);
        Task<List<CarbondioxideMeasurement>> GetTerrariumCarbonMeasurementsFromDb(string userId, string terrariumId);
        
        //Data Post from terrarium
        Task PostMeasurementToDb(Measurement measurement);
    }
}