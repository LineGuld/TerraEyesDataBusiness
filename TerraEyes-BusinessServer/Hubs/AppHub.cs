using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.Hubs
{
    public class AppHub : Hub
    {
        private IDbConnect DbConnect;

        public AppHub()
        {
            DbConnect = new DbConnection();
        }
        /*
        //Henter alle af den type målinger der hører til en given user
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetTemperatureFromDb(userId);
        }

        public async Task<List<HumidityMeasurement>> HumidityDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetHumidityFromDb(userId);
        }

        public async Task<List<CarbondioxideMeasurement>> CarbonDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetCarbonMeasurementsFromDb(userId);
        }

        */
        //Henter alle den givne type målinger for et specifikt terrarie
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId, string eui)
        {
            return await DbConnect.GetTerrariumTemperaturesFromDb(userId, eui);
        }

        public async Task<List<HumidityMeasurement>> HumidityDataFromDataToAndroid(string userId, string eui)
        {
            return await DbConnect.GetTerrariumHumidityFromDb(userId, eui);
        }

        public async Task<List<CarbondioxideMeasurement>> CarbonDataFromDataToAndroid(string userId, string eui)
        {
            return await DbConnect.GetTerrariumCarbonMeasurementsFromDb(userId, eui);
        }
        
    }
}