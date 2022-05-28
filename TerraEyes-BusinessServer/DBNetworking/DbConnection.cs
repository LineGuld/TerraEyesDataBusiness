using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Models.OutgoingMeasurements;
using Measurement = TerraEyes_BusinessServer.Models.Measurement;

namespace TerraEyes_BusinessServer.DBNetworking
{
    public class DbConnection : IDbConnect
    {
        private string uri = "https://terraeyes-db.azurewebsites.net/";

        public async Task<List<ActivityMeasurement>> GetActivityFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}activity/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<ActivityMeasurement> measurements = JsonSerializer.Deserialize<List<ActivityMeasurement>>(
                listAsString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return measurements;
        }

        public async Task<List<ActivityMeasurement>> GetTerrariumActivityFromDb(string eui)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/activity/x/{eui}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();

            List<ActivityMeasurement> measurements = JsonSerializer.Deserialize<List<ActivityMeasurement>>(
                listAsString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return measurements;
        }

        public async Task<List<CarbondioxideMeasurement>> GetCarbonMeasurementsFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}carbondioxides/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<CarbondioxideMeasurement> carbonMeasurements = JsonSerializer.Deserialize<List<CarbondioxideMeasurement>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return carbonMeasurements;
        }

        public async Task<List<CarbondioxideMeasurement>> GetTerrariumCarbonMeasurementsFromDb(string terrariumId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}carbondioxides/x/{terrariumId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<CarbondioxideMeasurement> carbonMeasurements = JsonSerializer.Deserialize<List<CarbondioxideMeasurement>>(
                listAsString, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return carbonMeasurements;
        }
        
        public async Task<List<HumidityMeasurement>> GetHumidityFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}humidity/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<HumidityMeasurement> humidities = JsonSerializer.Deserialize<List<HumidityMeasurement>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return humidities;
        }

        public async Task<List<HumidityMeasurement>> GetTerrariumHumidityFromDb(string terrariumId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}humidity/x/{terrariumId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<HumidityMeasurement> humidities = JsonSerializer.Deserialize<List<HumidityMeasurement>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return humidities;
        }

        public async Task<List<LumenMeasurement>> GetLumenFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}lumen/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<LumenMeasurement> measurements = JsonSerializer.Deserialize<List<LumenMeasurement>>(
            listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return measurements;
        }
        
        public async Task<List<LumenMeasurement>> GetTerrariumLumenFromDb(string eui)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}lumen/x/{eui}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            
            List<LumenMeasurement> measurements = JsonSerializer.Deserialize<List<LumenMeasurement>>(
                listAsString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return measurements;
        }

        public async Task<List<ServoMeasurement>> GetServoFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/servo/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();

            List<ServoMeasurement> measurements = JsonSerializer.Deserialize<List<ServoMeasurement>>(
                listAsString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return measurements;
        }
        
        public async Task<List<ServoMeasurement>> GetTerrariumServoFromDb(string eui)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/servo/x/{eui}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();

            List<ServoMeasurement> measurements = JsonSerializer.Deserialize<List<ServoMeasurement>>(
                listAsString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return measurements;
        }

        public async Task<List<TemperatureMeasurement>> GetTemperatureFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}temperatures/{userId}");

            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(listAsString);
            List<TemperatureMeasurement> temperatures = JsonSerializer.Deserialize<List<TemperatureMeasurement>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return temperatures;
        }
        
        public async Task<List<TemperatureMeasurement>> GetTerrariumTemperaturesFromDb(string terrariumId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}temperatures/x/{terrariumId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            List<TemperatureMeasurement> temperatures = JsonSerializer.Deserialize<List<TemperatureMeasurement>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return temperatures;
        }
        
        public async Task<Terrarium> GetTerrariumInfoFromDb(string eui)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}terrarium/x/{eui}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");

            string terrariumAsJson = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(terrariumAsJson);
            Terrarium terrarium = JsonSerializer.Deserialize<Terrarium>(terrariumAsJson, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return terrarium;
        }

        public async Task<List<Terrarium>> GetTerrariumsForUser(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}terrarium/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            List<Terrarium> terrariums = JsonSerializer.Deserialize<List<Terrarium>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return terrariums;
        }

        public async Task<List<Animal>> GetAnimalsForUser(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}animals/{userId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
            }

            string listAsString = await responseMessage.Content.ReadAsStringAsync();
            List<Animal> animals = JsonSerializer.Deserialize<List<Animal>>(listAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return animals;
        }


        public async Task PostTemperatureToDb(TemperatureMeasurement measurement)
        {
            using HttpClient client = new HttpClient();
            string temperatureAsString = JsonSerializer.Serialize(measurement);
            HttpContent content = new StringContent(temperatureAsString);
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}temperatures", content);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
        }
        

        public async Task PostHumidityToDb(HumidityMeasurement measurement)
        {
            using HttpClient client = new HttpClient();
            string humidityAsJson = JsonSerializer.Serialize(measurement);
            HttpContent content = new StringContent(humidityAsJson);
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}humidity", content);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
        }

        public async Task PostMeasurementToDb(Measurement measurement)
         {
             using HttpClient client = new HttpClient();
             string measurementAsJson = JsonSerializer.Serialize(measurement, new JsonSerializerOptions
             {
                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase
             });
             Console.WriteLine(measurementAsJson);
             HttpContent content = new StringContent(measurementAsJson,
                 Encoding.UTF8,
                 "application/json");
             HttpResponseMessage responseMessage = await client.PostAsync($"{uri}measurement", content);

             if (!responseMessage.IsSuccessStatusCode)
                 throw new Exception($"StatusCode: {responseMessage.StatusCode}");
         }

        public Task AddUserToDb(User user)
        {
            throw new NotImplementedException();
        }

        public Task AddTerrariumToDb(Terrarium terrarium)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTerrariumFromDb(string eui)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTerrarium(Terrarium terrarium)
        {
            throw new NotImplementedException();
        }

        public Task AddAnimalToDb(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAnimalFromDb(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task Feed()
        {
            throw new NotImplementedException();
        }
    }
}