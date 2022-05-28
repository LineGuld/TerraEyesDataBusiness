using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;
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

        public override Task OnConnectedAsync()
        {
            
            return base.OnConnectedAsync();
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

        public async Task<List<LumenMeasurement>> LumenDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetLumenFromDb(userId);
        }
        
        public async Task<List<LumenMeasurement>> TerrariumLumenDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumLumenFromDb(eui);
        }

        public async Task<List<ServoMeasurement>> ServoDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetServoFromDb(userId);
        }

        public async Task<List<ServoMeasurement>> TerrariumServoDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumServoFromDb(eui);
        }

        public async Task<Terrarium> TerrariumDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumInfoFromDb(eui);
        }

        public async Task<List<Terrarium>> UsersTerrariumDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetTerrariumsForUser(userId);
        }

        public async Task<List<Animal>> AnimalsDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetAnimalsForUser(userId);
        }

        public async Task<List<Animal>> TerrariumAnimalsDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetAnimalsForTerrarium(eui);
        }

        public async Task<Animal> AnimalDataFromDataToAndroid(int id)
        {
            return await DbConnect.GetAnimalById(id);
        }


        //  Henter alle af den type målinger der hører til en given user
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId)
        {
            return await DbConnect.GetTemperatureFromDb(userId);
        }
        
        //  Henter alle den givne type målinger for et specifikt terrarie
        public async Task<List<TemperatureMeasurement>> TerrariumTemperatureDataFromDataToAndroid(string eui)
        {
            return await DbConnect.GetTerrariumTemperaturesFromDb(eui);
        }

    }
}