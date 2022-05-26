using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        
        /***************************
         *  Stefan above this line
         ***************************/
        
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

        

        public async Task<List<TemperatureMeasurement>> GetTerrariumTemperaturesFromDb(string userId, string terrariumId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}temperatures/{userId}/{terrariumId}");

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

        public async Task PostTemperatureToDb(TemperatureMeasurement measurement)
        {
            using HttpClient client = new HttpClient();
            string temperatureAsString = JsonSerializer.Serialize(measurement);
            HttpContent content = new StringContent(temperatureAsString);
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}temperatures", content);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"StatusCode: {responseMessage.StatusCode}");
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

          public async Task<List<HumidityMeasurement>> GetTerrariumHumidityFromDb(string userId, string terrariumId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}humidity/{userId}/{terrariumId}");

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
    }
}