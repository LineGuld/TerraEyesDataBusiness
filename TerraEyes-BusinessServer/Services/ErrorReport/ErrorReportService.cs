using Microsoft.AspNetCore.SignalR;
using TerraEyes_BusinessServer.Hubs;

namespace TerraEyes_BusinessServer.Services.ErrorReport
{
    public class ErrorReportService
    {
        private static IHubContext<AppHub> _context;

        public ErrorReportService(IHubContext<AppHub> ctx)
        {
            _context = ctx;
        }
        public static async void ReportErrorToUser(ErrorTypes errorType, string boundary, string userId, string eui)
        {
            var msg = $"{errorType} has exceeded {boundary} boundary for terrarium id: {eui}";
            await _context.Clients.Group(userId).SendAsync("ErrorReport", msg);
        }
    }

    public enum ErrorTypes
    {
        Temperature,
        Humidity,
        CarbonDioxide,
        Light,
        Feeding
    }
}