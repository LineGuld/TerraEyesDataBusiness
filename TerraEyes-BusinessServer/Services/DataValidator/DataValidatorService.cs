using System;
using TerraEyes_BusinessServer.Data;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.ErrorReport;

namespace TerraEyes_BusinessServer.Services.DataValidator
{
    public class DataValidatorService : IDataValidatorService
    {
        private IErrorReportService _errorReportService;
        private IDataValidatorDataLink _validatorDataLink;

        public DataValidatorService()
        {
            _errorReportService = new ErrorReportService();
            _validatorDataLink = new DataValidatorDataLink();
        }

        public void ValidateMeasurementData(Measurement measurement)
        {
            try
            {
               Sensor sensor = _validatorDataLink.findSensor(measurement.Eui);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        
    }
}