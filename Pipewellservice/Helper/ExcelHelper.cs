using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Pipewellservice.Helper
{
    public class ExcelHelper
    {
        public List<string> ReadFile(string FilePath)
        {
            string connectionString = Connection(FilePath);


            var lines = new List<string>();
            DataTable Sheets = GetSheetName(FilePath);

            string query = "SELECT * FROM [" + Sheets.Rows[0]["TABLE_NAME"].ToString() + "]";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var fieldCount = reader.FieldCount;
                    var fieldIncrementor = 1;
                    var fields = new List<string>();
                    while (fieldCount >= fieldIncrementor)
                    {
                        fields.Add(reader[fieldIncrementor - 1].ToString());
                        fieldIncrementor++;
                    }
                    if (StringHelper.NullToString(fields[0]) == "" && (fieldCount > 1 && StringHelper.NullToString(fields[1]) == ""))
                        continue;
                    else
                        lines.Add(string.Join("\t", fields));
                }
                reader.Close();
            }
            return lines;
        }
        public List<string> ReadFirstLine(string FilePath)
        {
            string connectionString = Connection(FilePath);


            var lines = new List<string>();
            DataTable Sheets = GetSheetName(FilePath);

            string query = "SELECT * FROM [" + Sheets.Rows[0]["TABLE_NAME"].ToString() + "]";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var fieldCount = reader.FieldCount;
                    var fieldIncrementor = 1;
                    var fields = new List<string>();
                    while (fieldCount >= fieldIncrementor)
                    {
                        fields.Add(reader[fieldIncrementor - 1].ToString());
                        fieldIncrementor++;
                    }
                    if (StringHelper.NullToString(fields[0]) == "")
                        continue;
                    else

                        lines.Add(string.Join("\t", fields));
                    break;
                }
                reader.Close();
            }
            return lines;
        }
        private string Connection(string FilePath)
        {
            if (FilePath.EndsWith(".xls"))
            {
                return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
            }
            else if (FilePath.EndsWith(".xlsx"))
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + FilePath + "\";Extended Properties=\"Excel 12.0;ISAM=1;HDR=No;IMEX=1\"";

            }
            else
            {
                return "";
            }
        }
        private DataTable GetSheetName(string FilePath)
        {
            string connectionString = Connection(FilePath);
            DataTable Data = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                Data = connection.GetOleDbSchemaTable(
                       OleDbSchemaGuid.Tables,
                       new object[] { null, null, null, "TABLE" });
            }
            return Data;
        }
    }
}