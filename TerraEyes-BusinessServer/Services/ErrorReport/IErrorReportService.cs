namespace TerraEyes_BusinessServer.Services.ErrorReport
{
    public interface IErrorReportService
    {
        void ReportErrorToUser(ErrorTypes errorType, string boundary, string userId);
    }
}