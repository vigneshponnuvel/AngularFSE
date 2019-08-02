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
    public class UserDataProvider
    {
        private readonly string connectionString = "Server=tcp:172.18.3.194,1433;Database=FMS_OUTREACH;User ID=sa;Password=password";

        public TMstrUser Login(TMstrUser user)
        {
            TMstrUser userDetails = new TMstrUser();            
            
            using (var sqlConnection = new SqlConnection(connectionString))
            {                

                SqlCommand sqlCommand = new SqlCommand("spGetUser", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = user.Username;

                sqlConnection.Open();

                SqlDataReader sqlData = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlData.Read())
                {
                    userDetails.Userid = Convert.ToInt32(sqlData[0].ToString());
                    userDetails.Username = sqlData[1].ToString();
                    userDetails.Password = sqlData[5].ToString();
                }

                sqlConnection.Close();
            }

            return userDetails;
        }
    }
}
