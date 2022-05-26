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



        /***************************
         *  Stefan above this line
         ***************************/


        //Terrarium settings
        Task<Terrarium> GetTerrariumInfoFromDb(string eui);


        //All measurements for a user
        Task<List<TemperatureMeasurement>> GetTemperatureFromDb(string userId);
        Task PostTemperatureToDb(TemperatureMeasurement measurement);
        Task PostHumidityToDb(HumidityMeasurement measurement);


        //Measurements for a specific terrarium when a user has multiple
        Task<List<TemperatureMeasurement>> GetTerrariumTemperaturesFromDb(string userId, string terrariumId);

        //Data Post from terrarium
        Task PostMeasurementToDb(Measurement measurement);
    }
}