using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TerraEyes_BusinessServer.DBNetworking;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.UserRepository;
using User = TerraEyes_BusinessServer.UserRepository.User;

namespace TerraEyes_BusinessServer.Hubs
{
    [Authorize]
    public class AppHub : Hub
    {
        private readonly IDbConnect _dbConnect;

        public AppHub()
        {
            _dbConnect = new DbConnection();
        }

        public override async Task OnConnectedAsync()
        {
            await using (var db = new Repository())
            {
                var user = await db.Users
                    .Include(u => u.Groups)
                    .SingleOrDefaultAsync(u => u.UserId == Context.User.Identity.Name); //Identity.Name SKAL være UserID

                if (user is null)
                {
                    user = new User
                    {
                        UserId = Context.User?.Identity?.Name
                    };
                    user.ConnectionIds.Add(Context.ConnectionId);
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                }
                else
                {
                    if (!user.ConnectionIds.Contains(Context.ConnectionId))
                        user.ConnectionIds.Add(Context.ConnectionId);
                    
                    foreach (var group in user.Groups)
                    {
                        await Groups.AddToGroupAsync(Context.ConnectionId, group.UserType);
                    }
                }
            }

            await base.OnConnectedAsync();
        }

        public async Task AddToGroup(string groupName, string userId)
        {
            await using (var db = new Repository())
            {
                var group = await db.Groups.FindAsync(groupName);
                var user = await db.Users.FindAsync(userId);

                if (group is not null && user is not null)
                {
                    group.Users.Add(user);
                    await db.SaveChangesAsync();
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                }
            }
        }

        //Henter alle af den type målinger der hører til en given user
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetTemperatureFromDb(userId);
        }

        public async Task<List<HumidityMeasurement>> HumidityDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetHumidityFromDb(userId);
        }

        public async Task<List<CarbondioxideMeasurement>> CarbonDataFromDataToAndroid(string userId)
        {
            return await _dbConnect.GetCarbonMeasurementsFromDb(userId);
        }

        //Henter alle den givne type målinger for et specifikt terrarie
        public async Task<List<TemperatureMeasurement>> TemperatureDataFromDataToAndroid(string userId, string eui)
        {
            return await _dbConnect.GetTerrariumTemperaturesFromDb(userId, eui);
        }

        public async Task<List<HumidityMeasurement>> HumidityDataFromDataToAndroid(string userId, string eui)
        {
            return await _dbConnect.GetTerrariumHumidityFromDb(userId, eui);
        }

        public async Task<List<CarbondioxideMeasurement>> CarbonDataFromDataToAndroid(string userId, string eui)
        {
            return await _dbConnect.GetTerrariumCarbonMeasurementsFromDb(userId, eui);
        }
    }
}