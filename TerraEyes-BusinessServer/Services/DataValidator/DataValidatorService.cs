using System;
using TerraEyes_BusinessServer.Data;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.ErrorReport;

namespace TerraEyes_BusinessServer.Services.DataValidator
{
    public class DataValidatorService : IDataValidatorService
    {
        private readonly IErrorReportService _errorReportService;
        private readonly IDataValidatorDataLink _validatorDataLink;

        public DataValidatorService()
        {
            _errorReportService = new ErrorReportService();
            _validatorDataLink = new DataValidatorDataLink();
        }

        public void ValidateMeasurementData(Measurement measurement)
        {
            Console.WriteLine(measurement.ToString());
        }
        
        
    }
}