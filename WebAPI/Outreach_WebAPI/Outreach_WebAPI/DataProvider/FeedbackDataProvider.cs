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
    public class FeedbackDataProvider : IFeedbackDataProvider
    {
        private readonly string connectionString = "Server=tcp:172.18.3.194,1433;Database=FMS_OUTREACH;User ID=sa;Password=password";

        public async Task<TTtrnFeedback> GetFeedback(int Feedbackid)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Feedbackid", Feedbackid);
                return await sqlConnection.QuerySingleOrDefaultAsync<TTtrnFeedback>(
                    "spGetFeedback",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddFeedback(TTtrnFeedback feedback)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();                
                dynamicParameters.Add("@Eventid", feedback.Eventid);
                dynamicParameters.Add("@Associateid", feedback.Associateid);
                dynamicParameters.Add("@Feedbackcategory", feedback.Feedbackcategory);
                dynamicParameters.Add("@Mainfeedback", feedback.Mainfeedback);
                dynamicParameters.Add("@Optionalfeedback1", feedback.Optionalfeedback1);
                dynamicParameters.Add("@Optionalfeedback2", feedback.Optionalfeedback2);
                dynamicParameters.Add("@Associatestatus", feedback.Associatestatus);
                dynamicParameters.Add("@Createddt", DateTime.Now);

                await sqlConnection.ExecuteAsync(
                    "spAddFeedback",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TTtrnFeedback>> GetAllFeedback()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<TTtrnFeedback>(
                    "spGetAllFeedback",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
