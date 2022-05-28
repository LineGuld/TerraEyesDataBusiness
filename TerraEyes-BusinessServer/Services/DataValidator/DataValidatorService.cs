using System;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.ErrorReport;

namespace TerraEyes_BusinessServer.Services.DataValidator
{
    public class DataValidatorService : IDataValidatorService
    {
        private readonly IErrorReportService _errorReportService;
        private readonly IDbConnect _dbConnect;
        private readonly FeedService _feedService;

        public DataValidatorService()
        {
            _errorReportService = new ErrorReportService();
            _dbConnect = new DbConnection();
            _feedService = FeedService.GetInstance();
        }

        public async void ValidateMeasurementData(Measurement measurement)
        {
            Console.WriteLine(measurement.ToString());
            Validate(measurement);
            await _dbConnect.PostMeasurementToDb(measurement);
        }

        private async void Validate(Measurement measurement)
        {
            //Terrarium terrarium = await _dbConnect.GetTerrariumInfoFromDb(measurement.Eui);
            Terrarium terrarium = await _dbConnect.GetTerrariumInfoFromDb(measurement.Eui);

            if (measurement.Temperature < terrarium.MinTemperature)
                _errorReportService.ReportErrorToUser(ErrorTypes.Temperature, "min", terrarium.UserId);
            else if (measurement.Temperature > terrarium.MaxTemperature)
                _errorReportService.ReportErrorToUser(ErrorTypes.Temperature, "max", terrarium.UserId);

            if (measurement.Humidity < terrarium.MinHumidity)
                _errorReportService.ReportErrorToUser(ErrorTypes.Humidity, "min", terrarium.UserId);
            else if (measurement.Humidity > terrarium.MaxHumidity)
                _errorReportService.ReportErrorToUser(ErrorTypes.Humidity, "max", terrarium.UserId);
            
            if (measurement.CarbonDioxide > terrarium.MaxCarbonDioxide)
                _errorReportService.ReportErrorToUser(ErrorTypes.CarbonDioxide, null, terrarium.UserId);

            if (!_feedService.HasRequestedFeeding(measurement.Eui)) return;
            if (measurement.ServoMoved)
            {
                _feedService.RemoveVerifiedRequest(measurement.Eui);
            }
            else if (_feedService.DecrementWaitTime(measurement.Eui) == 0)
            {
                _errorReportService.ReportErrorToUser(ErrorTypes.Feeding, null, terrarium.UserId);
            }
        }
    }
}