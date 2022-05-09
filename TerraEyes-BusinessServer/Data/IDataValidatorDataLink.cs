
using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.Data
{
    public interface IDataValidatorDataLink
    {
        public Sensor findSensor(string sensorId);
    }
}