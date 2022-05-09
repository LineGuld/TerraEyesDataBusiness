using TerraEyes_BusinessServer.Models;

namespace TerraEyes_BusinessServer.Services.DataTranslator
{
    public interface IMeasurementDataTranslator
    {
        public void TranslateRawData(MeasurementRawInput input);
    }
}