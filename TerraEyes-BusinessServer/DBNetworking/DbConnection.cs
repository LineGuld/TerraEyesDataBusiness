using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.DBNetworking
{
    public class DbConnection : IDbConnect
    {
        private string uri = "https://terraeyes-db.azurewebsites.net/";
        public async Task<List<TemperatureMeasurement>> GetTemperatureFromDb(string userId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}temperatures/{userId}");

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
    }
}