using System.Collections.Generic;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Models.OutgoingMeasurements;
using Measurement = TerraEyes_BusinessServer.Models.Measurement;

namespace TerraEyes_BusinessServer.DBNetworking
{
    public interface IDbConnect
    {
        Task<List<ActivityMeasurement>> GetActivityFromDb(string userId);
        Task<List<ActivityMeasurement>> GetTerrariumActivityFromDb(string eui);
        
        Task<List<CarbondioxideMeasurement>> GetCarbonMeasurementsFromDb(string userId);
        Task<List<CarbondioxideMeasurement>> GetTerrariumCarbonMeasurementsFromDb(string terrariumId);

        Task<List<HumidityMeasurement>> GetHumidityFromDb(string userId);
        Task<List<HumidityMeasurement>> GetTerrariumHumidityFromDb(string terrariumId);

        Task<List<LumenMeasurement>> GetLumenFromDb(string userId);
        Task<List<LumenMeasurement>> GetTerrariumLumenFromDb(string userId);

        Task<List<ServoMeasurement>> GetServoFromDb(string userId);
        Task<List<ServoMeasurement>> GetTerrariumServoFromDb(string eui);
        
        Task<List<TemperatureMeasurement>> GetTemperatureFromDb(string userId);
        Task<List<TemperatureMeasurement>> GetTerrariumTemperaturesFromDb(string terrariumId);
        

        //Terrarium settings
        Task<Terrarium> GetTerrariumInfoFromDb(string eui);
        
        
        Task PostTemperatureToDb(TemperatureMeasurement measurement);
        Task PostHumidityToDb(HumidityMeasurement measurement);


        //Data Post from terrarium
        Task PostMeasurementToDb(Measurement measurement);
    }
}