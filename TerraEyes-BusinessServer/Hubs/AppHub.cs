using System.Collections.Generic;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Models.OutgoingMeasurements;
using Hub = Microsoft.AspNetCore.SignalR.Hub;

namespace TerraEyes_BusinessServer.Hubs
{
    public class AppHub : Hub
    {
        private readonly IDbConnect _dbConnect;

        public AppHub()
        {
            _dbConnect = new DbConnection();
        }

        public override async Task OnConnectedAsync()
        {
            /*var user = await _dbConnect.GetUserByUserId(Context.User?.Identity?.Name); //TODO: IDENTIFIER SKAL GENNEMGÅES SAMMEN MED ANDROID!
            if (user is not null)
                await Groups.AddToGroupAsync(Context.ConnectionId, user.Id);
            */
            await base.OnConnectedAsync();
        }

        public async void SignIn(string userId)
        {
            var user = await _dbConnect.GetUserByUserId(userId);
            if (user is not null)
                await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            else
                AddUserToDb(userId);
        }

        public async void AddUserToDb(string userId)
        {
            var newUser = new User(userId);
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            await _dbConnect.AddUserToDb(newUser);
        }

        public async void AddTerrariumToDb(Terrarium terrarium)
        {
            await _dbConnect.AddTerrariumToDb(terrarium);
        }

        public async void UpdateTerrarium(Terrarium terrarium)
        {
            await _dbConnect.UpdateTerrarium(terrarium);
        }

        public async void AddAnimalToDb(Animal animal)
        {
            await _dbConnect.AddAnimalToDb(animal);
        }

        public async void UpdateAnimal(Animal animal, int id)
        {
            await _dbConnect.UpdateAnimal(animal, id);
        }

        public async Task<List<ActivityMeasurement>> ActivityDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetActivityFromDb(userId);
        }

        public async Task<List<ActivityMeasurement>> TerrariumActivityDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumActivityFromDb(eui);
        }


        public async Task<List<CarbondioxideMeasurement>> CarbonDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetCarbonMeasurementsFromDb(userId);
        }

        public async Task<List<CarbondioxideMeasurement>> TerrariumCarbonDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumCarbonMeasurementsFromDb(eui);
        }


        public async Task<List<HumidityMeasurement>> HumidityDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetHumidityFromDb(userId);
        }

        public async Task<List<HumidityMeasurement>> TerrariumHumidityDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumHumidityFromDb(eui);
        }

        public async Task<List<LumenMeasurement>> LumenDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetLumenFromDb(userId);
        }

        public async Task<List<LumenMeasurement>> TerrariumLumenDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumLumenFromDb(eui);
        }

        public async Task<List<ServoMeasurement>> ServoDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetServoFromDb(userId);
        }

        public async Task<List<ServoMeasurement>> TerrariumServoDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumServoFromDb(eui);
        }

        public async Task<Terrarium> TerrariumDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumInfoFromDb(eui);
        }

        public async Task<List<Terrarium>> UsersTerrariumDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetTerrariumsForUser(userId);
        }

        public async Task<List<Animal>> AnimalsDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetAnimalsForUser(userId);
        }

        public async Task<List<Animal>> TerrariumAnimalsDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetAnimalsForTerrarium(eui);
        }

        public async Task<Animal> AnimalDataFromDataToAndroid(int id)
        {
            return await _dbConnect.GetAnimalById(id);
        }

        public async Task<User> UserDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetUserByUserId(userId);
        }


        //  Henter alle af den type målinger der hører til en given user
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetTemperatureFromDb(userId);
        }

        //  Henter alle den givne type målinger for et specifikt terrarie
        public async Task<List<TemperatureMeasurement>> TerrariumTemperatureDataFromDataToAndroid(string eui)
        {
            return await _dbConnect.GetTerrariumTemperaturesFromDb(eui);
        }
    }
}