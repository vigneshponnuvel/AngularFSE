using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using Outreach_WebAPI.Models;

namespace Outreach_WebAPI.DataProvider
{
    public class EventsDataProvider : IEventsDataProvider
    {
        private readonly string connectionString = "Server=tcp:172.18.3.194,1433;Database=FMS_OUTREACH;User ID=sa;Password=password";
        
        public async Task<TEventSummary> GetEvent(string eventID)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventId", eventID);
                return await sqlConnection.QuerySingleOrDefaultAsync<TEventSummary>(
                    "spGetEvent",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TEventSummary>> GetEvents()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<TEventSummary>(
                    "spGetEvents",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TEventInformation> GetEventFromIDAndAssoID(string eventID, int associateID, int feedBackType)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventId", eventID);
                dynamicParameters.Add("@AssociateID", associateID);
                dynamicParameters.Add("@FeedBackType", feedBackType);
                return await sqlConnection.QuerySingleOrDefaultAsync<TEventInformation>(
                    "spGetEventFromIDAndAssoID",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
