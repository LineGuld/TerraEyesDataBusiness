﻿namespace TerraEyes_BusinessServer.Services.ErrorReport
{
    public class ErrorReportService: IErrorReportService
    {
        public void ReportErrorToUser(ErrorTypes errorType, string boundary, string userId)
        {
            
        }
    }

    public enum ErrorTypes
    {
        Temperature,
        Humidity,
        CarbonDioxide,
        Light
    }
}