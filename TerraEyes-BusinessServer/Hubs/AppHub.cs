using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models.OutgoingMeasurements;

namespace TerraEyes_BusinessServer.Hubs
{
    public class AppHub : Hub
    {
        private IDbConnect DbConnect;

        public AppHub()
        {
            DbConnect = new DbConnection();
        }
        
        
        public async Task<List<ActivityMeasurement>> ActivityDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetActivityFromDb(userId);
        }
        
        public async Task<List<ActivityMeasurement>> TerrariumActivityDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumActivityFromDb(eui);
        } 
        
        
        public async Task<List<CarbondioxideMeasurement>> CarbonDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetCarbonMeasurementsFromDb(userId);
        }

        public async Task<List<CarbondioxideMeasurement>> TerrariumCarbonDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumCarbonMeasurementsFromDb(eui);
        }

        
        public async Task<List<HumidityMeasurement>> HumidityDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetHumidityFromDb(userId);
        }
        
        public async Task<List<HumidityMeasurement>> TerrariumHumidityDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumHumidityFromDb(eui);
        }
        
        
        
        //  Henter alle af den type målinger der hører til en given user
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetTemperatureFromDb(userId);
        }
        
        //  Henter alle den givne type målinger for et specifikt terrarie
        public async Task<List<TemperatureMeasurement>> TerrariumTemperatureDataFromDataToAndroid(string userId, string eui)
        {
            return await DbConnect.GetTerrariumTemperaturesFromDb(userId, eui);
        }

    }
}