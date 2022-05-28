using System;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.ErrorReport;

namespace TerraEyes_BusinessServer.Services.DataValidator
{
    public class DataValidatorService : IDataValidatorService
    {
        private readonly IDbConnect _dbConnect;
        private readonly FeedService _feedService;

        public DataValidatorService()
        {
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
            Terrarium terrarium = await _dbConnect.GetTerrariumInfoFromDb(measurement.Eui);

            if (measurement.Temperature < terrarium.MinTemperature)
                ErrorReportService.ReportErrorToUser(
                    ErrorTypes.Temperature, "minimum", terrarium.UserId, terrarium.Eui);
            else if (measurement.Temperature > terrarium.MaxTemperature)
                ErrorReportService.ReportErrorToUser(
                    ErrorTypes.Temperature, "maximum", terrarium.UserId, terrarium.Eui);

            if (measurement.Humidity < terrarium.MinHumidity)
                ErrorReportService.ReportErrorToUser(
                    ErrorTypes.Humidity, "minimum", terrarium.UserId, terrarium.Eui);
            else if (measurement.Humidity > terrarium.MaxHumidity)
                ErrorReportService.ReportErrorToUser(
                    ErrorTypes.Humidity, "maximum", terrarium.UserId, terrarium.Eui);
            
            if (measurement.CarbonDioxide > terrarium.MaxCarbonDioxide)
                ErrorReportService.ReportErrorToUser(
                    ErrorTypes.CarbonDioxide, "maximum", terrarium.UserId, terrarium.Eui);

            if (!_feedService.HasRequestedFeeding(measurement.Eui)) return;
            if (measurement.ServoMoved)
            {
                _feedService.RemoveVerifiedRequest(measurement.Eui);
            }
            else if (_feedService.DecrementWaitTime(measurement.Eui) == 0)
            {
                ErrorReportService.ReportErrorToUser(
                    ErrorTypes.Feeding, "wait time", terrarium.UserId, terrarium.Eui);
            }
        }
    }
}