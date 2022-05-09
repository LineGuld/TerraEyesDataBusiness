using System.Collections.Generic;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.DBNetworking
{
    public interface IDbConnect
    {
        Task<List<TemperatureMeasurement>> GetTemperaturePointFromDb(string userId);
    }
}