using System;
using TerraEyes_BusinessServer.Data;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.ErrorReport;

namespace TerraEyes_BusinessServer.Services.DataValidator
{
    public class DataValidatorService : IDataValidatorService
    {
        private readonly IErrorReportService _errorReportService;
        private readonly IDbConnect _dbConnect;

        public DataValidatorService()
        {
            _errorReportService = new ErrorReportService();
            _dbConnect = new DbConnection();
        }

        public async void ValidateMeasurementData(Measurement measurement)
        {
            //TODO: A tonne of validation...


            await _dbConnect.PostMeasurementToDb(measurement);
        }
        
        
    }
}