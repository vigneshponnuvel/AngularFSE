using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace DataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //string eventsSummary = @"C:\Users\Administrator\Desktop\DOCS\Outreach Events Summary.xlsx";

            //readDataToDB(eventsSummary);

            string eventsInfo = @"C:\Users\Administrator\Desktop\DOCS\OutReach Event Information.xlsx";

            readDataToDB(eventsInfo);

        }

        private static void readDataToDB(string path)
        {
            bool headerRow = true;
            DataTable valueFromExcel = new DataTable();

            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    package.Load(stream);
                }
                var worksheet = package.Workbook.Worksheets.First();

                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    valueFromExcel.Columns.Add(headerRow ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }

                var startRow = headerRow ? 2 : 1;

                for (int rowNum = startRow; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                {
                    var worksheetRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];

                    DataRow row = valueFromExcel.Rows.Add();

                    foreach (var cell in worksheetRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
            }


            if (path.Contains("OutReach Event Information"))
            {
                addToEventsInfo(valueFromExcel);
            }
            else
            {
                addToEventsSummary(valueFromExcel);
            }
        }

        private static void addToEventsSummary(DataTable valueFromExcel)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnStringDb"].ConnectionString;

            foreach (DataRow row in valueFromExcel.Rows)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstring);

                SqlCommand sqlCommand = new SqlCommand("spAddEventSummary", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@EVENTID", SqlDbType.VarChar).Value = row[0].ToString();
                sqlCommand.Parameters.Add("@MONTH", SqlDbType.VarChar).Value = row[1].ToString();
                sqlCommand.Parameters.Add("@BASELOCATION", SqlDbType.VarChar).Value = row[2].ToString();
                sqlCommand.Parameters.Add("@BENEFICIARYNAME", SqlDbType.VarChar).Value = row[3].ToString();
                sqlCommand.Parameters.Add("@VENUEADDRESS", SqlDbType.VarChar).Value = row[4].ToString();
                sqlCommand.Parameters.Add("@COUNCILNAME", SqlDbType.VarChar).Value = row[5].ToString();
                sqlCommand.Parameters.Add("@PROJECT", SqlDbType.VarChar).Value = row[6].ToString();
                sqlCommand.Parameters.Add("@CATEGORY", SqlDbType.VarChar).Value = row[7].ToString();
                sqlCommand.Parameters.Add("@EVENTNAME", SqlDbType.VarChar).Value = row[8].ToString();
                sqlCommand.Parameters.Add("@EVENTDESCRIPTION", SqlDbType.VarChar).Value = row[9].ToString();
                sqlCommand.Parameters.Add("@EVENTDATE", SqlDbType.DateTime).Value = DateTime.ParseExact(row[10].ToString(), "dd-MM-yy", null);
                sqlCommand.Parameters.Add("@TOTALNOOFVOLUNTEERS", SqlDbType.Int).Value = Convert.ToInt32(row[11].ToString());
                sqlCommand.Parameters.Add("@TOTALVOLUNTEERHOURS", SqlDbType.Int).Value = Convert.ToInt32(row[12].ToString());
                sqlCommand.Parameters.Add("@TOTALTRAVELHOURS", SqlDbType.Int).Value = Convert.ToInt32(row[13].ToString());
                sqlCommand.Parameters.Add("@OVERALLVOLUNTEERINGHOURS", SqlDbType.Int).Value = Convert.ToInt32(row[14].ToString());
                sqlCommand.Parameters.Add("@LIVESIMPACTED", SqlDbType.Int).Value = Convert.ToInt32(row[15].ToString());
                sqlCommand.Parameters.Add("@ACTIVITYTYPE", SqlDbType.Int).Value = Convert.ToInt32(row[16].ToString());
                sqlCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = row[17].ToString();
                sqlCommand.Parameters.Add("@POCID", SqlDbType.Int).Value = Convert.ToInt32(row[18].ToString());
                sqlCommand.Parameters.Add("@POCNAME", SqlDbType.VarChar).Value = row[19].ToString();
                sqlCommand.Parameters.Add("@POCCONTACTNUMBER", SqlDbType.Int).Value = Convert.ToInt32(row[20].ToString());

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        private static void addToEventsInfo(DataTable valueFromExcel)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnStringDb"].ConnectionString;

            foreach (DataRow row in valueFromExcel.Rows)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstring);

                SqlCommand sqlCommand = new SqlCommand("spAddEventInfo", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@EVENTID", SqlDbType.VarChar).Value = row[0].ToString();
                sqlCommand.Parameters.Add("@BASELOCATION", SqlDbType.VarChar).Value = row[1].ToString();
                sqlCommand.Parameters.Add("@BENEFICIARYNAME", SqlDbType.VarChar).Value = row[2].ToString();
                sqlCommand.Parameters.Add("@COUNCILNAME", SqlDbType.VarChar).Value = row[3].ToString();
                sqlCommand.Parameters.Add("@EVENTNAME", SqlDbType.VarChar).Value = row[4].ToString();
                sqlCommand.Parameters.Add("@EVENTDESCRIPTION", SqlDbType.VarChar).Value = row[5].ToString();
                sqlCommand.Parameters.Add("@EVENTDATE", SqlDbType.DateTime).Value = DateTime.ParseExact(row[6].ToString(), "dd-MM-yy", null);
                sqlCommand.Parameters.Add("@EMPLOYEEID", SqlDbType.Int).Value = Convert.ToInt32(row[7].ToString());
                sqlCommand.Parameters.Add("@EMPLOYEENAME", SqlDbType.VarChar).Value = row[8].ToString();
                sqlCommand.Parameters.Add("@VOLUNTEERHOURS", SqlDbType.Int).Value = Convert.ToInt32(row[9].ToString());
                sqlCommand.Parameters.Add("@TRAVELHOURS", SqlDbType.Int).Value = Convert.ToInt32(row[10].ToString());
                sqlCommand.Parameters.Add("@LIVESIMPACTED", SqlDbType.Int).Value = Convert.ToInt32(row[11].ToString());
                sqlCommand.Parameters.Add("@BUSINESSUNIT", SqlDbType.VarChar).Value = row[12].ToString();
                sqlCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = row[13].ToString();
                sqlCommand.Parameters.Add("@IIEPCATEGORY", SqlDbType.VarChar).Value = row[14].ToString();


                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
